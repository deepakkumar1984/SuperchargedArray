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
    using System.Runtime.InteropServices;

    /// <summary>
    /// Enum DType
    /// </summary>
    public enum DType
    {
        /// <summary>
        /// The Single (float32) datatype
        /// </summary>
        Single = 0,
       
        /// <summary>
        /// The Double (float64) datatype
        /// </summary>
        Double = 2,
    }

    /// <summary>
    /// Struct Half
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Half
    {
        /// <summary>
        /// The value
        /// </summary>
        public ushort value;
    }


    /// <summary>
    /// Class DTypeExtensions.
    /// </summary>
    internal static class DTypeExtensions
    {
        /// <summary>
        /// Sizes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="NotSupportedException">Element type " + value + " not supported.</exception>
        public static int Size(this DType value)
        {
            switch (value)
            {
                case DType.Single: return 4;
                case DType.Double: return 8;
                default:
                    throw new NotSupportedException("Element type " + value + " not supported.");
            }
        }

        /// <summary>
        /// Converts to clrtype.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Type.</returns>
        /// <exception cref="NotSupportedException">Element type " + value + " not supported.</exception>
        public static Type ToCLRType(this DType value)
        {
            switch (value)
            {
                case DType.Single: return typeof(float);
                case DType.Double: return typeof(double);
                default:
                    throw new NotSupportedException("Element type " + value + " not supported.");
            }
        }
    }

    /// <summary>
    /// Class DTypeBuilder.
    /// </summary>
    internal static class DTypeBuilder
    {
        /// <summary>
        /// Froms the type of the color.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>DType.</returns>
        /// <exception cref="NotSupportedException">No corresponding DType value for CLR type " + type</exception>
        public static DType FromCLRType(Type type)
        {
            if (type == typeof(float)) return DType.Single;
            else if (type == typeof(double)) return DType.Double;
            else
                throw new NotSupportedException("No corresponding DType value for CLR type " + type);
        }
    }
}
