using System;

namespace xTensor.Scratchapd
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = XArray.Ones(2, 2);
            var dims = x.Dimension();
            Console.WriteLine("Hello World!");
        }
    }
}
