using System;
using System.ArrayExtension;
using System.ArrayExtension.Accelerated;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExt.Accel.Testing
{
    public class PerfTest
    {
        public void Run()
        {
            int count = 10000000;
            Random rnd = new Random();

            //Create variable A with random values
            float[] a = new float[count];
            Parallel.For(0, count, (i) => {
                a[i] = (float)rnd.NextDouble();
            });

            //Create variable B with constant value 0.5
            float[] b = new float[count];
            Parallel.For(0, count, (i) => {
                b[i] = 0.5f;
            });

            RunStandard(count, a, b);
            Console.WriteLine();
            RunArrayNonAccelerated(count, a, b);
            Console.WriteLine();
            //RunArrayAccelerated(count, a, b, 0);
            Console.WriteLine();
            RunArrayAccelerated(count, a, b, 1);
            Console.WriteLine();
            RunArrayAccelerated(count, a, b, 2);
        }

        public void RunStandard(int count, Array a, Array b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Execute math operation Sqrt(Sin(a) + Cos(b) * Exp(a)) and store the result to R
            Array r = new float[count];
            for (int i = 0; i < count; i++)
            {
                var rv = MathF.Sqrt(MathF.Sin((float)a.GetValue(i)) + MathF.Cos((float)b.GetValue(i)) * MathF.Exp((float)a.GetValue(i)));

                r.SetValue(rv, i);
            }

            sw.Stop();
            Console.WriteLine("RunStandard Time (in ms): " + sw.ElapsedMilliseconds);
        }

        public void RunArrayNonAccelerated(int count, Array a, Array b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var K = Global.OP;

            var r = K.Sqrt(K.Sin(a) + K.Cos(b) * K.Exp(a));
            sw.Stop();
            Console.WriteLine("RunArrayNonAccelerated Time (in ms): " + sw.ElapsedMilliseconds);
            
        }

        public void RunArrayAccelerated(int count, Array a, Array b, int deviceid)
        {
            Accelerator.UseDevice(deviceid);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            var K = Global.OP;

            var r = K.Sqrt(K.Sin(a) + K.Cos(b) * K.Exp(a));
            sw.Stop();
            Console.WriteLine("RunArrayAccelerated Time (in ms): " + sw.ElapsedMilliseconds);
            Accelerator.Dispose();
        }
    }
}