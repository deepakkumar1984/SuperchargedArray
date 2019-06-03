using System.ArrayExtension.Accelerated.Kernels;
using System.ArrayExtension.Accelerated.OpenCL;
using System.ArrayExtension.Accelerated.OpenCL.Bindings;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace System.ArrayExtension.Accelerated
{
    public static class Accelerator
    {
        static List<ComputeDevice> _devices = new List<ComputeDevice>();

        private static ComputeDevice _defaultDevice = null;

        private static ComputePlatform _defaultPlatorm = null;

        private static List<ComputeKernel> _compiledKernels = null;

        private static ComputeContext _context = null;

        public static List<Device> Devices
        {
            get
            {
                List<Device> result = new List<Device>();

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

        public static List<string> Kernels
        {
            get { return _compiledKernels.Select(x => x.FunctionName).ToList(); }
        }

        public static void Init(int id = 0)
        {
            _devices = new List<ComputeDevice>();
            
            foreach (var item in ComputePlatform.Platforms)
            {
                _devices.AddRange(item.Devices);
            }
            
            UseDevice(id);
            LoadInternalKernels();
        }

        public static void UseDevice(int id = 0)
        {
            if(_devices.Count == 0)
                throw new Exception("No device found. Please check OpenCL is installed.");
            
            _defaultDevice = _devices[id];
            _defaultPlatorm = _defaultDevice.Platform;
            ComputeContextPropertyList properties = new ComputeContextPropertyList(_defaultPlatorm);
            _context = new ComputeContext(new ComputeDevice[] { _defaultDevice }, properties, null, IntPtr.Zero);
        }

        private static void LoadInternalKernels()
        {
            _compiledKernels = new List<ComputeKernel>();
            
            CreateKernels("Arithmetic", CLCode.Arithmetic);
            CreateKernels("Trigonometry", CLCode.Trignometry);
            CreateKernels("General", CLCode.General);
            CreateKernels("LogExpPow", CLCode.LogExpPow);
            CreateKernels("Rounding", CLCode.Rounding);
        }

        public static void LoadKernel(string sourceCode)
        {
            CreateKernels("custom", sourceCode);
        }
        
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

    }
}