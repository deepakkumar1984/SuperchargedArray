using System;
using System.ArrayExtension.Accelerated;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension.Accelerated
{
    public partial class Global : ArrayExtension.Global
    {
        public static void UseAccelerator(int deviceId = 0)
        {
            Accelerator.UseDevice(deviceId);
        }

        public static void UseDefault(int processorPercentage = 100)
        {
            double ratio = (double)processorPercentage / 100;
            ParallelThread = (int)(Environment.ProcessorCount * ratio);
            OP = new ArrayOps();
            Console.WriteLine("Selecting {0}% of CPU processing", processorPercentage);
        }
    }
}
