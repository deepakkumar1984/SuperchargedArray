using System;
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
                new PerfTest().Run();
                //System.ArrayExtension.Accelerated.Global.UseDefault();

                //NDArray x = new NDArray(new long[] { 3, 3 }, DType.Single);
                //x.LoadFrom(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

                //NDArray y = new float[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };

                //var r = x + y;
                //r.Print();

                //BasicExample.RunStandard();
                //BasicExample.RunArraySimplified();
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.ReadLine();
        }
        
    }
}

