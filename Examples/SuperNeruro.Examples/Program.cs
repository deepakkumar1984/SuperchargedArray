using System;
using SuperchargedArray;
using SuperchargedArray.Backend;

namespace SuperNeruro.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperchargedArray.Device.SetBackend(SuperchargedArray.Backend.Interop.BackendType.CUDA);
            var x = SuperArray.Create(new float[,] { { 1, 2 },{ 3, 4 } } );
            //var y = AFArray.Exp(x) / (Data.Constant<float>(1, x.Dimensions) + AFArray.Exp(x));
            var y = Ops.Sqrt(x);
            y.Print();
            var (dx, dy) = Ops.Grad(y);
            dx.Print();

            XOR.Run();

            Console.ReadLine();
        }
    }
}
