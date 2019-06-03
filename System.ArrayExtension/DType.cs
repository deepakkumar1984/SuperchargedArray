using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.ArrayExtension
{
    /// <summary>
    /// Enum DType
    /// </summary>
    public enum DType
    {
        /// <summary>
        /// The float32
        /// </summary>
        Single = 0,
       
        /// <summary>
        /// The float64
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
