using System;

namespace OpenCL.Tensor.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NDArray a = new NDArray(10, 10);
            //a.LoadFrom(new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9});
            //a.Print();

            //var d = a.Select(1, 2);
            Global.Ops.RandomLogNormal(a, 0.1f, 1);
            a.Print();
            Console.ReadLine();
        }
    }
}
