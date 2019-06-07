namespace SuperchargedArray
{
    using System;
    using Amplifier;
    using SuperchargedArray.Accelerated;
    using SuperchargedArray.Amplified.Kernels;

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
        /// Gets or sets the compiler OpenCL or CUDA.
        /// </summary>
        /// <value>
        /// The compiler.
        /// </value>
        public static BaseCompiler Compiler { get; } = new OpenCLCompiler();

        /// <summary>
        /// Uses the accelerated device.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        public static void UseAmplifier(int deviceId = 0)
        {
            Compiler.UseDevice(deviceId);
            Compiler.CompileKernel(typeof(InternalFloatKernels));
            
            Compiler.CompileKernel(typeof(InternalDoubleKernels));
            OP = new Amplified.ArrayOps();
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
