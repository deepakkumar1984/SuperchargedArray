/*
MIT License

Copyright (c) 2019 Tech Quantum

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 
*/
namespace SuperchargedArray
{
    using System;

    /// <summary>
    /// Extension methods for the .NET array
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Gets the shape of the .NET array.
        /// </summary>
        /// <param name="x">The array.</param>
        /// <returns></returns>
        public static long[] GetShape(this Array x)
        {
            long[] shape = new long[x.Rank];
            for (int i = 0; i < shape.Length; i++)
                shape[i] = x.GetLength(i);

            return shape;
        }

        /// <summary>
        /// Gets the datatype of the .NET array
        /// </summary>
        /// <param name="x">The array.</param>
        /// <returns></returns>
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
