using System;
using SuperchargedArray;

namespace SuperNeruro.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = SuperArray.Create(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            var b = SuperArray.Create(new float[] { 3, 4 });

            var c = b + a;
            BostonHousing.Run();

            Console.ReadLine();
        }
    }
}
