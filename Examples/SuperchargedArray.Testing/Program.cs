using SuperchargedArray;
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
                //Global.UseAmplifier(0);
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

