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

        internal static List<ComputeKernel> compiledKernels = null;

        private static ComputeContext context = null;

        public static List<Device> Devices
        {
            get
            {
                List<Device> result = new List<Device>();

                for (int i = 0; i < devices.Count; i++)
                {
                    result.Add(new Device()
                    {
                        ID = i,
                        Name = devices[i].Name,
                        Type = (DeviceType)devices[i].Type,
                        Vendor = devices[i].Vendor
                    });
                }

                return result;
            }
        }

        public static List<string> Kernels
        {
            get { return compiledKernels.Select(x => x.FunctionName).ToList(); }
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
            compiledKernels = new List<ComputeKernel>();
            
            CreateKernels(CLCode.ArithmeticKernel);
            CreateKernels(CLCode.TrignometryKernel);
            CreateKernels(CLCode.General);
            CreateKernels(CLCode.LogExpPow);
            CreateKernels(CLCode.Rounding);
        }

        public static void CustomKernel(string code)
        {
            CreateKernels(code);
        }
        
        private static void CreateKernels(string code)
        {
            try
            {
                var program = new ComputeProgram(context, code);
                
                program.Build(null, null, null, IntPtr.Zero);
                compiledKernels.AddRange(program.CreateAllKernels());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed creating kernals with error: " + ex.Message);
            }
        }
    }
}