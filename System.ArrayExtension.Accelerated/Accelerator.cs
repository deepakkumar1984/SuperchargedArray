using System.ArrayExtension.Accelerated.Kernels;
using System.ArrayExtension.Accelerated.OpenCL;
using System.ArrayExtension.Accelerated.OpenCL.Bindings;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace System.ArrayExtension.Accelerated
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
                _devices.Clear();
                foreach (var item in ComputePlatform.Platforms)
                {
                    _devices.AddRange(item.Devices);
                }

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
            if (_devices.Count == 0)
            {
                _devices = new List<ComputeDevice>();
                foreach (var item in ComputePlatform.Platforms)
                {
                    _devices.AddRange(item.Devices);
                }
            }

            ChangeDevice(id);
            LoadInternalKernels();
            Global.K = new ArrayOps();
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
#if DEBUG
            Console.WriteLine("Selected device: " + _defaultDevice.Name);
#endif
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

            var arr = ExecuteInternalArray(functionName, inputs, dType, returnResult);

            NDArray result = null;

            if (!returnResult.HasValue)
            {
                result = new NDArray(outputShape, dType);
                result.LoadFrom(arr);
            }
            else
            {
                result = (NDArray)inputs[returnResult.Value];
                result.LoadFrom(arr);
            }

            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Loads the internal kernels.
        /// </summary>
        private static void LoadInternalKernels()
        {
            _compiledKernels = new List<ComputeKernel>();

            CreateKernels("Arithmetic", CLCode.Arithmetic);
            CreateKernels("Trigonometry", CLCode.Trignometry);
            CreateKernels("General", CLCode.General);
            CreateKernels("LogExpPow", CLCode.LogExpPow);
            CreateKernels("Rounding", CLCode.Rounding);
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
        private static Array ExecuteInternalArray(string functionName, object[] inputs, DType dType, int? returnResult = null)
        {
            ComputeKernel kernel = _compiledKernels.FirstOrDefault(x => (x.FunctionName == functionName));
            ComputeEventList eventList = new ComputeEventList();
            ComputeCommandQueue commands = new ComputeCommandQueue(_context, _defaultDevice, ComputeCommandQueueFlags.None);

            if (kernel == null)
                throw new ExecutionException(string.Format("Kernal function {0} not found", functionName));

            try
            {
                var ndobject = (NDArray)inputs.FirstOrDefault(x => (x.GetType() == typeof(NDArray)));

                long length = ndobject != null ? ndobject.Elements : 1;
                Array resultArray = null;

                if (dType == DType.Single)
                {
                    ComputeBuffer<float> result = null;
                    float[] r = new float[length];
                    result = BuildFloatKernelArguments(inputs, kernel, length, returnResult);
                    commands.Execute(kernel, null, new long[] { length }, null, eventList);
                    commands.ReadFromBuffer(result, ref r, false, eventList);
                    resultArray = r;
                    result.Dispose();
                }
                else if (dType == DType.Double)
                {
                    ComputeBuffer<double> result = null;
                    double[] r = new double[length];
                    result = BuildDoubleKernelArguments(inputs, kernel, length, returnResult);
                    commands.Execute(kernel, null, new long[] { length }, null, eventList);
                    if (!returnResult.HasValue)
                    {
                        commands.ReadFromBuffer(result, ref r, false, eventList);
                        resultArray = r;
                        result.Dispose();
                    }
                }

                return resultArray;
            }
            catch (Exception ex)
            {
                throw new ExecutionException(ex.Message);
            }
            finally
            {
                commands.Finish();
                commands.Dispose();
                foreach (ComputeEventBase eventBase in eventList)
                {
                    eventBase.Dispose();
                }

                eventList.Clear();
                kernel.Dispose();
            }
        }

        private static ComputeBuffer<float> BuildFloatKernelArguments(object[] inputs, ComputeKernel kernel, long length, int? returnResult = null)
        {
            int i = 0;
            var result = new ComputeBuffer<float>(_context, ComputeMemoryFlags.WriteOnly, length);

            foreach (var item in inputs)
            {
                if (item.GetType() == typeof(NDArray))
                    if (returnResult.HasValue && returnResult.Value == i)
                    {
                        result = new ComputeBuffer<float>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<float>());
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

        private static ComputeBuffer<double> BuildDoubleKernelArguments(object[] inputs, ComputeKernel kernel, long length, int? returnResult = null)
        {
            int i = 0;
            var result = new ComputeBuffer<double>(_context, ComputeMemoryFlags.WriteOnly, length);

            foreach (var item in inputs)
            {
                if (item.GetType() == typeof(NDArray))
                {
                    if(returnResult.HasValue && returnResult.Value == i)
                    {
                        result = new ComputeBuffer<double>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<double>());
                        kernel.SetMemoryArgument(i, result);
                    }
                    else
                        kernel.SetMemoryArgument(i, new ComputeBuffer<double>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<double>()));
                }
                else if (item.GetType().IsPrimitive)
                    kernel.SetValueArgument(i, (double)item);

                i++;
            }

            if (!returnResult.HasValue)
                kernel.SetMemoryArgument(i++, result);

            return result;
        }

        private static ComputeBuffer<int> BuildInt32KernelArguments(object[] inputs, ComputeKernel kernel, long length)
        {
            int i = 0;

            foreach (var item in inputs)
            {
                if (item.GetType() == typeof(NDArray))
                    kernel.SetMemoryArgument(i, new ComputeBuffer<int>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<int>()));
                else if (item.GetType().IsPrimitive)
                    kernel.SetValueArgument(i, (int)item);

                i++;
            }

            var result = new ComputeBuffer<int>(_context, ComputeMemoryFlags.WriteOnly, length);
            kernel.SetMemoryArgument(i++, result);

            return result;
        }

        private static ComputeBuffer<long> BuildLongKernelArguments(object[] inputs, ComputeKernel kernel, long length)
        {
            int i = 0;

            foreach (var item in inputs)
            {
                if (item.GetType() == typeof(NDArray))
                    kernel.SetMemoryArgument(i, new ComputeBuffer<long>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<long>()));
                else if (item.GetType().IsPrimitive)
                    kernel.SetValueArgument(i, (long)item);

                i++;
            }

            var result = new ComputeBuffer<long>(_context, ComputeMemoryFlags.WriteOnly, length);
            kernel.SetMemoryArgument(i++, result);

            return result;
        }

        private static ComputeBuffer<byte> BuildByteKernelArguments(object[] inputs, ComputeKernel kernel, long length)
        {
            int i = 0;

            foreach (var item in inputs)
            {
                if (item.GetType() == typeof(NDArray))
                    kernel.SetMemoryArgument(i, new ComputeBuffer<byte>(_context, ComputeMemoryFlags.CopyHostPointer, ((NDArray)item).Data<byte>()));
                else if (item.GetType().IsPrimitive)
                    kernel.SetValueArgument(i, (byte)item);

                i++;
            }

            var result = new ComputeBuffer<byte>(_context, ComputeMemoryFlags.WriteOnly, length);
            kernel.SetMemoryArgument(i++, result);

            return result;
        }

        #endregion
    }
}