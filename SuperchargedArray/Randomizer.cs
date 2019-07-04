using SuperchargedArray.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperchargedArray
{
    public partial class SuperArray
    {
        public static SuperArray RandomUniform<T>(Shape shape, float min, float max, int? seed = null) where T : struct
        {
            if (seed.HasValue)
                Data.RandSeed = (ulong)seed.Value;
            else
                Data.RandSeed = (ulong)new Random().Next(1, 1000);

            SuperArray result = Data.RandUniform<T>(shape.Dims);
            if (min != 0 || max != 1)
            {
                result = (max - min) * result + min;
            }

            return result;
        }

        public static SuperArray RandomNormal<T>(Shape shape, float mean, float stddev, int? seed = null) where T : struct
        {
            if (seed.HasValue)
                Data.RandSeed = (ulong)seed.Value;
            else
                Data.RandSeed = (ulong)new Random().Next(1, 1000);

            SuperArray result = Data.RandNormal<T>(shape.Dims);
            if (mean != 0 || stddev != 1)
            {
                result = stddev * result + mean;
            }

            return result;
        }

        public static SuperArray RandomExponential<T>(Shape shape, float lambda, int? seed = null) where T : struct
        {
            if (seed.HasValue)
                Data.RandSeed = (ulong)seed.Value;
            else
                Data.RandSeed = (ulong)new Random().Next(1, 1000);

            SuperArray result = Data.RandUniform<T>(shape.Dims);
            return (-1 / lambda) * Ops.Log(1 - result);
        }

        public static SuperArray RandomCauchy<T>(Shape shape, float median, float sigma, int? seed = null) where T : struct
        {
            if (seed.HasValue)
                Data.RandSeed = (ulong)seed.Value;
            else
                Data.RandSeed = (ulong)new Random().Next(1, 1000);

            SuperArray result = Data.RandUniform<T>(shape.Dims);
            return (median + sigma) * Ops.Tan((float)Math.PI * (result - 0.5f));
        }

        public static SuperArray RandomGeometric<T>(Shape shape, float p, int? seed = null) where T : struct
        {
            if (seed.HasValue)
                Data.RandSeed = (ulong)seed.Value;
            else
                Data.RandSeed = (ulong)new Random().Next(1, 1000);

            SuperArray result = Data.RandUniform<T>(shape.Dims);
            return Ops.Log(1 - result) / (float)Math.Log(p) + 1;
        }

        public static SuperArray RandomBernoulli<T>(Shape shape, float p, int? seed = null) where T : struct
        {
            if (seed.HasValue)
                Data.RandSeed = (ulong)seed.Value;
            else
                Data.RandSeed = (ulong)new Random().Next(1, 1000);

            SuperArray result = Data.RandUniform<T>(shape.Dims);
            return result <= p;
        }
    }
}
