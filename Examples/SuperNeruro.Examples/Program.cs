using System;
using SuperchargedArray;
using SuperchargedArray.Backend;

namespace SuperNeruro.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = SuperArray.Create(new float[] { 1, 2, 3, 4 });
            var y = SuperArray.Create(new float[] { 4, 3, 2, 1 }).Reshape(4, 1);

            //var c = x + y;

            SuperchargedArray.Device.SetBackend(SuperchargedArray.Backend.Interop.BackendType.CPU);
            XOR.Run();

            Console.ReadLine();
        }
    }
}
