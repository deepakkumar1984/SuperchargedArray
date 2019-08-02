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
                BasicExample.RunStandard();
                //BasicExample.RunArraySimplified();

                SuperArray.RandomBernoulli<float>((5, 5), 0.5f).Print();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            Console.ReadLine();
        }
        
    }
}

