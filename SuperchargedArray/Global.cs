namespace SuperchargedArray
{
    using System;
    using SuperchargedArray.Accelerated;

    /// <summary>
    /// Global setting for the SuperArray
    /// </summary>
    public partial class Global
    {
        /// <summary>
        /// Gets or sets the number of parallel thread.
        /// </summary>
        /// <value>
        /// The parallel thread.
        /// </value>
        public static int ParallelThread { get; set; } = Environment.ProcessorCount;

        /// <summary>
        /// Gets or sets the operation which will be globally used by the SuperArray.
        /// </summary>
        /// <value>
        /// The op.
        /// </value>
        public static ArrayOps OP { get; set; } = new ArrayOps();

        /// <summary>
        /// Uses the accelerated device.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        public static void UseAccelerator(int deviceId = 0)
        {
            Accelerator.UseDevice(deviceId);
        }

        /// <summary>
        /// Uses the default CPU processing power by regulating the parallel of CPU to use.
        /// </summary>
        /// <param name="processorPercentage">The processor percentage.</param>
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
