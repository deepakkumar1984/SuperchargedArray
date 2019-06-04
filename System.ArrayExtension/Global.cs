using System;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension
{
    public partial class Global
    {
        public static int ParallelThread { get; set; } = Environment.ProcessorCount;

        public static ArrayOps OP { get; set; } = new ArrayOps();

        public static void UseDefault(int processorPercentage = 100)
        {
            double ratio = (double)processorPercentage / 100;
            ParallelThread = (int)(Environment.ProcessorCount * ratio);
            OP = new ArrayOps();
            Console.WriteLine("Selecting {0}% of CPU processing", processorPercentage);
        }
    }
}
