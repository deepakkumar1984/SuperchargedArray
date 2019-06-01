using System.ArrayExtension.Accelerated.OpenCL;
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
        }

        public static void UseDevice(int id = 0)
        {
            if(devices.Count == 0)
                throw new Exception("No device found. Please check OpenCL is installed.");
            
            DefaultDevice = devices[id];
            DefaultPlatorm = DefaultDevice.Platform;
        }

        public static void LoadKernels()
        {
            
        }
    }
}