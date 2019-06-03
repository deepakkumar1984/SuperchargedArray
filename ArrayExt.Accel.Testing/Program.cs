using System;
using System.ArrayExtension.Accelerated;
using System.Collections.Generic;
using System.IO;

namespace ArrayExt.Accel.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Accelerator.Init(1);
                var devices = Accelerator.Devices;
                foreach (var item in Accelerator.Kernels)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.ReadLine();

        }
        
    }
}

