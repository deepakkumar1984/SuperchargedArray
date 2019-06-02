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
            Accelerator.Init(1);
            foreach (var item in Accelerator.Kernels)
            {
                    Console.WriteLine(item);
            }
            Console.ReadLine();

        }
        
    }
}

