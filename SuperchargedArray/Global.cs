using System;
using SuperchargedArray.Accelerated;
using System.Collections.Generic;
using System.Text;

namespace SuperchargedArray
{
    public partial class Global
    {
        public static int ParallelThread { get; set; } = Environment.ProcessorCount;

        public static ArrayOps OP { get; set; } = new ArrayOps();

        public static void UseAccelerator(int deviceId = 0)
        {
            Accelerator.UseDevice(deviceId);
        }

        public static void UseDefault(int processorPercentage = 100)
        {
            double ratio = (double)processorPercentage / 100;
            ParallelThread = (int)(Environment.ProcessorCount * ratio);
            ParallelThread = ParallelThread == 0 ? 1 : ParallelThread;
            OP = new ArrayOps();
            Console.WriteLine("Selecting {0}% of CPU processing", processorPercentage);
        }
    }
}
