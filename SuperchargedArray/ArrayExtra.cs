using System;
using System.Collections.Generic;
using System.Text;

namespace SuperchargedArray
{
    public static class ArrayExtra
    {
        public static long[] GetShape(this Array x)
        {
            long[] shape = new long[x.Rank];
            for (int i = 0; i < shape.Length; i++)
                shape[i] = x.GetLength(i);

            return shape;
        }

        public static DType GetDType(this Array x)
        {
            DType result = DType.Single;
            if(x.GetType().Name.StartsWith("Single"))
            {
                result = DType.Single;
            }
            else if (x.GetType().Name.StartsWith("Double"))
            {
                result = DType.Double;
            }

            return result;
        }
    }
}
