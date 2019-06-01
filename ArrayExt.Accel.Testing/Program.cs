using System;
using System.ArrayExtension.Accelerated.OpenCL;
using System.Collections.Generic;
using System.IO;

namespace ArrayExt.Accel.Testing
{
    class Program
    {
        static ComputeProgram program;

        static string clProgramSource = @"
                            kernel void VectorAdd(
                                global  read_only float* a,
                                global  read_only float* b,
                                global write_only float* c )
                            {
                                int index = get_global_id(0);
                                c[index] = a[index] + b[index];
                            }
                            ";
        
        static void Main(string[] args)
        {
            System.ArrayExtension.Accelerated.OpenCL.cl_mem_migration_flags_ext
            var devices = new List<ComputeDevice>();
            var platforms = ComputePlatform.Platforms;
            var platform = platforms[0];
            ComputeContextPropertyList properties = new ComputeContextPropertyList(platform);
            ComputeContext context = new ComputeContext(new ComputeDevice[]{platform.Devices[1]}, properties, null, IntPtr.Zero);
            Run(context);
            Console.ReadLine();

        }
        
        static void Run(ComputeContext context)
        {
            try
            {
                // Create the arrays and fill them with random data.
                int count = 100;
                float[] arrA = new float[count];
                float[] arrB = new float[count];
                float[] arrC = new float[count];

                Random rand = new Random();
                for (int i = 0; i < count; i++)
                {
                    arrA[i] = (float)(rand.NextDouble() * 100);
                    arrB[i] = (float)(rand.NextDouble() * 100);
                }

                // Create the input buffers and fill them with data from the arrays.
                // Access modifiers should match those in a kernel.
                // CopyHostPointer means the buffer should be filled with the data provided in the last argument.
                ComputeBuffer<float> a = new ComputeBuffer<float>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.CopyHostPointer, arrA);
                ComputeBuffer<float> b = new ComputeBuffer<float>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.CopyHostPointer, arrB);
                
                // The output buffer doesn't need any data from the host. Only its size is specified (arrC.Length).
                ComputeBuffer<float> c = new ComputeBuffer<float>(context, ComputeMemoryFlags.WriteOnly, arrC.Length);

                // Create and build the opencl program.
                program = new ComputeProgram(context, clProgramSource);
                program.Build(null, null, null, IntPtr.Zero);

                // Create the kernel function and set its arguments.
                ComputeKernel kernel = program.CreateKernel("VectorAdd");
                kernel.SetMemoryArgument(0, a);
                kernel.SetMemoryArgument(1, b);
                kernel.SetMemoryArgument(2, c);

                // Create the event wait list. An event list is not really needed for this example but it is important to see how it works.
                // Note that events (like everything else) consume OpenCL resources and creating a lot of them may slow down execution.
                // For this reason their use should be avoided if possible.
                ComputeEventList eventList = new ComputeEventList();
                
                // Create the command queue. This is used to control kernel execution and manage read/write/copy operations.
                ComputeCommandQueue commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);

                // Execute the kernel "count" times. After this call returns, "eventList" will contain an event associated with this command.
                // If eventList == null or typeof(eventList) == ReadOnlyCollection<ComputeEventBase>, a new event will not be created.
                commands.Execute(kernel, null, new long[] { count }, null, eventList);
                
                // Read back the results. If the command-queue has out-of-order execution enabled (default is off), ReadFromBuffer 
                // will not execute until any previous events in eventList (in our case only eventList[0]) are marked as complete 
                // by OpenCL. By default the command-queue will execute the commands in the same order as they are issued from the host.
                // eventList will contain two events after this method returns.
                commands.ReadFromBuffer(c, ref arrC, false, eventList);

                // A blocking "ReadFromBuffer" (if 3rd argument is true) will wait for itself and any previous commands
                // in the command queue or eventList to finish execution. Otherwise an explicit wait for all the opencl commands 
                // to finish has to be issued before "arrC" can be used. 
                // This explicit synchronization can be achieved in two ways:

                // 1) Wait for the events in the list to finish,
                //eventList.Wait();

                // 2) Or simply use
                commands.Finish();

                // Print the results to a log/console.
                for (int i = 0; i < count; i++)
                    Console.WriteLine("{0} + {1} = {2}", arrA[i], arrB[i], arrC[i]);

                // cleanup commands
                commands.Dispose();

                // cleanup events
                foreach (ComputeEventBase eventBase in eventList)
                {
                    eventBase.Dispose();
                }
                eventList.Clear();

                // cleanup kernel
                kernel.Dispose();

                // cleanup program
                program.Dispose();

                // cleanup buffers
                a.Dispose();
                b.Dispose();
                c.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}