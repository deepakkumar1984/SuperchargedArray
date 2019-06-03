using System;
using System.ArrayExtension;
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
                //var devices = Accelerator.Devices;
                Accelerator.UseDevice(0);
                

                NDArray x = new NDArray(new long[] { 3, 3 }, DType.Single);
                x.LoadFrom(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                NDArray y = new float[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

                var r = Global.K.Add(x, 1);
                r.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.ReadLine();
        }
        
    }
}

