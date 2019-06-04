using SuperchargedArray.Accelerated.OpenCL;
using SuperchargedArray.Accelerated.OpenCL.Bindings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SuperchargedArray.Accelerated
{
    /// <summary>
    /// Accelerator is a high level API for building and executing built-in or your own kernels. 
    /// </summary>
    public static class Accelerator
    {
        #region Private Variables
        /// <summary>
        /// The device list
        /// </summary>
        private static List<ComputeDevice> _devices = new List<ComputeDevice>();

        /// <summary>
        /// The default device for the accelerator
        /// </summary>
        private static ComputeDevice _defaultDevice = null;

        /// <summary>
        /// The default platorm for the accelerator
        /// </summary>
        private static ComputePlatform _defaultPlatorm = null;

        /// <summary>
        /// List of all compiled kernels
        /// </summary>
        private static List<ComputeKernel> _compiledKernels = null;

        /// <summary>
        /// The computer context with 
        /// </summary>
        private static ComputeContext _context = null;
        #endregion

        #region Public Variables
        /// <summary>
        /// Gets the list of all available devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        public static List<Device> Devices
        {
            get
            {
                List<Device> result = new List<Device>();
                LoadDevices();

                for (int i = 0; i < _devices.Count; i++)
                {
                    result.Add(new Device()
                    {
                        ID = i,
                        Name = _devices[i].Name,
                        Type = (DeviceType)_devices[i].Type,
                        Vendor = _devices[i].Vendor
                    });
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the kernels compiled with the selected device.
        /// </summary>
        /// <value>
        /// The kernels.
        /// </value>
        public static List<string> Kernels
        {
            get { return _compiledKernels.Select(x => x.FunctionName).ToList(); }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes the accelerator with default device and compile the in-built kernels.
        /// </summary>
        /// <param name="id">The device id.</param>
        public static void UseDevice(int id = 0)
        {
            LoadDevices();

            ChangeDevice(id);
            LoadInternalKernels();
            Global.OP = new ArrayOps();
        }

        /// <summary>
        /// Loads the devices.
        /// </summary>
        private static void LoadDevices()
        {
            if (_devices.Count == 0)
            {
                _devices = new List<ComputeDevice>();
                foreach (var item in ComputePlatform.Platforms)
                {
                    _devices.AddRange(item.Devices);
                }
            }
        }

        /// <summary>
        /// Change the device to be used with the accelerator
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">No device found. Please invoke Accelerator.Init with a device id to initialize. If you have done the Init and still getting the error please check if OpenCL is installed.</exception>
        /// <exception cref="System.ArgumentException">Device ID out of range.</exception>
        public static void ChangeDevice(int id = 0)
        {
            if(_devices.Count == 0)
                throw new Exception("No device found. Please invoke Accelerator.Init with a device id to initialize. " +
                    "If you have done the Init and still getting the error please check if OpenCL is installed.");

            if (id >= _devices.Count)
                throw new ArgumentException("Device ID out of range.");

            _defaultDevice = _devices[id];
            _defaultPlatorm = _defaultDevice.Platform;
            ComputeContextPropertyList properties = new ComputeContextPropertyList(_defaultPlatorm);
            _context = new ComputeContext(new ComputeDevice[] { _defaultDevice }, properties, null, IntPtr.Zero);
            LoadInternalKernels();
            Console.WriteLine("Selected device: " + _defaultDevice.Name);
        }

        /// <summary>
        /// Load custom kernel. 
        /// </summary>
        /// <param name="sourceCode">The source code.</param>
        public static void LoadKernel(string sourceCode)
        {
            CreateKernels("custom", sourceCode);
        }

        /// <summary>
        /// Load all the kernels from a folder, specified with a filter
        /// </summary>
        /// <param name="folderWithSourceCodes">The folder with source codes.</param>
        /// <param name="filter">The filter.</param>
        public static void LoadKernals(string folderWithSourceCodes, string filter = "*.*")
        {
            var files = Directory.EnumerateFiles(folderWithSourceCodes, filter);
            foreach (var file in files)
            {
                string name = System.IO.Path.GetFileName(file);
                string code = File.ReadAllText(file);
                CreateKernels(name, code);
            }
        }

        /// <summary>
        /// Executes the specified kernal function name with ordered inputs.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="inputs">The inputs.</param>
        /// <param name="outputShape">The output shape.</param>
        /// <returns></returns>
        public static NDArray Execute(string functionName, object[] inputs, long[] outputShape = null, int? returnResult = null)
        {
            DType dType = DType.Single;
            if (outputShape == null)
            {
                var ndobject = (NDArray)inputs.FirstOrDefault(x => (x.GetType() == typeof(NDArray)));
                if (ndobject == null)
                {
                    outputShape = new long[] { 1 };
                }
                else
                {
                    outputShape = ndobject.Shape;
                    dType = ndobject.ElementType;
                }
            }

            Array resultArray = null;

            if(dType == DType.Single)
                resultArray = ExecuteInternalArray<float>(functionName, inputs, dType, returnResult);
            else if (dType == DType.Double)
                resultArray = ExecuteInternalArray<double>(functionName, inputs, dType, returnResult);

            NDArray result = null;

            if (!returnResult.HasValue)
            {
                result = new NDArray(outputShape, dType);
                result.LoadFrom(resultArray);
            }
            else
            {
                result = (NDArray)inputs[returnResult.Value];
                result.LoadFrom(resultArray);
            }

            return result;
        }

        public static void Dispose()
        {
            foreach (var item in _compiledKernels)
            {
                item.Dispose();   
            }

            _context.Dispose();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Loads the internal kernels.
        /// </summary>
        private static void LoadInternalKernels()
        {
            _compiledKernels = new List<ComputeKernel>();

            CreateKernels("InternalFloatKernels", SuperchargedArray.Properties.Resources.InternalFloatKernels);
            CreateKernels("InternalDoubleKernels", SuperchargedArray.Properties.Resources.InternalDoubleKernels);
        }

        /// <summary>
        /// Creates the kernels.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="code">The code.</param>
        /// <exception cref="CompileException"></exception>
        private static void CreateKernels(string name, string code)
        {
            var program = new ComputeProgram(_context, code);
            
            try
            {
                program.Build(null, null, null, IntPtr.Zero);
                _compiledKernels.AddRange(program.CreateAllKernels());
            }
            catch(Exception ex)
            {
                string log = program.GetBuildLog(_defaultDevice);
                throw new CompileException(string.Format("Failed building {0} with error code: {1} \n Message: {2}", name, ex.Message, log));
            }
        }

        /// <summary>
        /// Execute the kernel.
        /// </summary>
        /// <typeparam name="T">Supports float and double</typeparam>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="inputs">The inputs.</param>
        /// <param name="outputs">The outputs.</param>
        /// <exception cref="ExecutionException"></exception>
        private static Array ExecuteInternalArray<TSource>(string functionName, object[] inputs, DType dType, int? returnResult = null) where TSource : struct
        {
            ComputeKernel kernel = _compiledKernels.FirstOrDefault(x => (x.FunctionName == functionName));
            ComputeCommandQueue commands = new ComputeCommandQueue(_context, _defaultDevice, ComputeCommandQueueFlags.None);

            if (kernel == null)
                throw new ExecutionException(string.Format("Kernal function {0} not found", functionName));

            try
            {
                var ndobject = (NDArray)inputs.FirstOrDefault(x => (x.GetType() == typeof(NDArray)));

                long length = ndobject != null ? ndobject.Elements : 1;
                Array resultArray = null;

                ComputeBuffer<TSource> result = null;
                TSource[] r = new TSource[length];
                result = BuildKernelArguments<TSource>(inputs, kernel, length, returnResult);
                commands.Execute(kernel, null, new long[] { length }, null, null);
                commands.ReadFromBuffer(result, ref r, true, null);
                commands.Finish();
                resultArray = r;
                r = null;
                result.Dispose();

                return resultArray;
            }
            catch (Exception ex)
            {
                throw new ExecutionException(ex.Message);
            }
            finally
            {
                commands.Dispose();
            }
        }

        private static ComputeBuffer<TSource> BuildKernelArguments<TSource>(object[] inputs, ComputeKernel kernel, long length, int? returnResult = null) where TSource : struct
        {
            int i = 0;
            var result = new ComputeBuffer<TSource>(_context, ComputeMemoryFlags.WriteOnly, length);

            foreach (var item in inputs)
            {
                if (item.GetType() == typeof(NDArray))
                    if (returnResult.HasValue && returnResult.Value == i)
                    {
                        result = new ComputeBuffer<TSource>(_context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<TSource>());
                        kernel.SetMemoryArgument(i, result);
                    }
                    else
                        kernel.SetMemoryArgument(i, new ComputeBuffer<float>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<float>()));
                else if (item.GetType().IsPrimitive)
                    kernel.SetValueArgument(i, (float)item);

                i++;
            }

            if (!returnResult.HasValue)
                kernel.SetMemoryArgument(i++, result);

            return result;
        }

        #endregion
    }
}