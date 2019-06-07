using SuperchargedArray;
using System;
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

            RunStandardLoop(count, a, b);
            Console.WriteLine();

            var devices = Global.Compiler.Devices;
            foreach (var item in devices)
            {
                RunArrayAccelerated(count, a, b, item.ID);
                Console.WriteLine();
            }

            RunArrayDefault(count, a, b, 33);
            RunArrayDefault(count, a, b, 66);
            RunArrayDefault(count, a, b, 100);
            Console.WriteLine();
        }

        public void RunStandardLoop(int count, Array a, Array b)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Execute math operation Truncate(a * Sin(b) + Cos(a) * Exp(b)) and store the result to R
            Array r = new float[count];
            for (int i = 0; i < count; i++)
            {
                var rv = MathF.Truncate((float)a.GetValue(i) * MathF.Sin((float)b.GetValue(i)) + MathF.Cos((float)a.GetValue(i)) * MathF.Exp((float)b.GetValue(i)));
                r.SetValue(rv, i);
            }

            sw.Stop();
            Console.WriteLine(".NET For Loop Time (in ms): " + sw.ElapsedMilliseconds);
        }

        public void RunArrayDefault(int count, SuperArray a, SuperArray b, int cpu)
        {
            Global.UseDefault(cpu);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var K = Global.OP;

            var r = K.Trunc(a * K.Sin(b) + K.Cos(a) * K.Exp(b));
            sw.Stop();

            Console.WriteLine("With Parallel Thread Time (in ms): {1}", cpu, sw.ElapsedMilliseconds);
        }

        public void RunArrayAccelerated(int count, SuperArray a, SuperArray b, int deviceid)
        {
            try
            {
                Global.UseAmplifier(deviceid);
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var K = Global.OP;

                var r = K.Trunc(a * K.Sin(b) + K.Cos(a) * K.Exp(b));
                sw.Stop();

                Console.WriteLine("With Accelerator (in ms): " + sw.ElapsedMilliseconds);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Global.Compiler.Dispose();
        }
    }
}