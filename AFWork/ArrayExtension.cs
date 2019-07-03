using SiaNet.Backend.ArrayFire.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFWork
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Gets the shape of the .NET array.
        /// </summary>
        /// <param name="x">The array.</param>
        /// <returns></returns>
        public static int[] GetShape(this Array x)
        {
            int[] shape = new int[x.Rank];
            for (int i = 0; i < shape.Length; i++)
                shape[i] = x.GetLength(i);

            return shape;
        }

        /// <summary>
        /// Gets the datatype of the .NET array
        /// </summary>
        /// <param name="x">The array.</param>
        /// <returns></returns>
        public static DataType GetDType(this Array x)
        {
            DataType result = DataType.Float32;
            if (x.GetType().Name.StartsWith("Single"))
            {
                result = DataType.Float32;
            }
            else if (x.GetType().Name.StartsWith("Double"))
            {
                result = DataType.Float64;
            }
            else if (x.GetType().Name.StartsWith("Int32"))
            {
                result = DataType.Int32;
            }
            else if (x.GetType().Name.StartsWith("Int64"))
            {
                result = DataType.Int64;
            }
            else if (x.GetType().Name.StartsWith("UInt32"))
            {
                result = DataType.UInt32;
            }
            else if (x.GetType().Name.StartsWith("UInt64"))
            {
                result = DataType.UInt64;
            }
            else if (x.GetType().Name.StartsWith("Byte"))
            {
                result = DataType.Byte;
            }

            return result;
        }
    }
}
