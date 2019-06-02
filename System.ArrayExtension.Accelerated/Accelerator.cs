using System.ArrayExtension.Accelerated.Kernels;
using System.ArrayExtension.Accelerated.OpenCL;
using System.ArrayExtension.Accelerated.OpenCL.Bindings;
using System.Collections.Generic;
using System.Linq;

namespace System.ArrayExtension.Accelerated
{
    public class Accelerator
    {
        static List<ComputeDevice> devices = new List<ComputeDevice>();

        internal static ComputeDevice DefaultDevice = null;

        internal static ComputePlatform DefaultPlatorm = null;

        internal static List<ComputeKernel> Kernels = null;

        private static ComputeContext context = null;


        public static Dictionary<int, string> Devices
        {
            get
            {
                Dictionary<int, string> result = new Dictionary<int, string>();

                for (int i = 0; i < devices.Count; i++)
                {
                    result.Add(i, devices[i].Name);
                }

                return result;
            }
        }

        public static void Init(int id = 0)
        {
            devices = new List<ComputeDevice>();
            
            foreach (var item in ComputePlatform.Platforms)
            {
                devices.AddRange(item.Devices);
            }
            
            UseDevice(id);
            LoadKernels();
        }

        public static void UseDevice(int id = 0)
        {
            if(devices.Count == 0)
                throw new Exception("No device found. Please check OpenCL is installed.");
            
            DefaultDevice = devices[id];
            DefaultPlatorm = DefaultDevice.Platform;
            ComputeContextPropertyList properties = new ComputeContextPropertyList(DefaultPlatorm);
            context = new ComputeContext(new ComputeDevice[] { DefaultDevice }, properties, null, IntPtr.Zero);
        }

        public static void LoadKernels()
        {
            Kernels = new List<ComputeKernel>();
            CreateKernels(CLCode.ArithmeticKernel);
        }

        private static void CreateKernels(string code)
        {
            try
            {
                var program = new ComputeProgram(context, code);
                
                program.Build(null, null, null, IntPtr.Zero);
                Kernels.AddRange(program.CreateAllKernels());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed creating kernals with error: " + ex.Message);
            }
        }
    }
}