using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ArrayExtension
{
    /// <summary>
    /// Class TensorFormatting.
    /// </summary>
    internal static class Formatter
    {
        /// <summary>
        /// Repeats the character.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.String.</returns>
        private static string RepeatChar(char c, int count)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                builder.Append(c);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Gets the int format.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        private static string GetIntFormat(int length)
        {
            var padding = RepeatChar('#', length - 1);
            return string.Format(" {0}0;-{0}0", padding);
        }

        /// <summary>
        /// Gets the float format.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        private static string GetFloatFormat(int length)
        {
            var padding = RepeatChar('#', length - 1);
            return string.Format(" {0}0.0000;-{0}0.0000", padding);
        }

        /// <summary>
        /// Gets the scientific format.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        private static string GetScientificFormat(int length)
        {
            var padCount = length - 6;
            var padding = RepeatChar('0', padCount);
            return string.Format(" {0}.0000e+00;-0.{0}e+00", padding);
        }




        /// <summary>
        /// Determines whether [is int only] [the specified storage].
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="array">The array.</param>
        /// <returns><c>true</c> if [is int only] [the specified storage]; otherwise, <c>false</c>.</returns>
        private static bool IsIntOnly(Storage storage, NDArray array)
        {
            // HACK this is a hacky way of iterating over the elements of the array.
            // if the array has holes, this will incorrectly include those elements
            // in the iteration.
            var minOffset = array.StorageOffset;
            var maxOffset = minOffset + Helper.GetStorageSize(array.Shape, array.Strides) - 1;
            for (long i = minOffset; i <= maxOffset; ++i)
            {
                var value = Convert.ToDouble((object)storage.GetElementAsFloat(i));
                if (value != Math.Ceiling(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Abses the minimum maximum.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="array">The array.</param>
        /// <returns>Tuple<System.Double, System.Double&gt;.</returns>
        private static Tuple<double, double> AbsMinMax(Storage storage, NDArray array)
        {
            if (storage.ElementCount == 0)
                return Tuple.Create(0.0, 0.0);

            double min = storage.GetElementAsFloat(0);
            double max = storage.GetElementAsFloat(0);

            // HACK this is a hacky way of iterating over the elements of the array.
            // if the array has holes, this will incorrectly include those elements
            // in the iteration.
            var minOffset = array.StorageOffset;
            var maxOffset = minOffset + Helper.GetStorageSize(array.Shape, array.Strides) - 1;

            for (long i = minOffset; i <= maxOffset; ++i)
            {
                var item = storage.GetElementAsFloat(i);
                if (item < min)
                    min = item;
                if (item > max)
                    max = item;
            }

            return Tuple.Create(Math.Abs(min), Math.Abs(max));
        }

        /// <summary>
        /// Enum FormatType
        /// </summary>
        private enum FormatType
        {
            /// <summary>
            /// The int
            /// </summary>
            Int,
            /// <summary>
            /// The scientific
            /// </summary>
            Scientific,
            /// <summary>
            /// The float
            /// </summary>
            Float,
        }
        /// <summary>
        /// Gets the size of the format.
        /// </summary>
        /// <param name="minMax">The minimum maximum.</param>
        /// <param name="intMode">if set to <c>true</c> [int mode].</param>
        /// <returns>Tuple<FormatType, System.Double, System.Int32&gt;.</returns>
        private static Tuple<FormatType, double, int> GetFormatSize(Tuple<double, double> minMax, bool intMode)
        {
            var expMin = minMax.Item1 != 0 ?
                    (int)Math.Floor(Math.Log10(minMax.Item1)) + 1 :
                    1;
            var expMax = minMax.Item2 != 0 ?
                    (int)Math.Floor(Math.Log10(minMax.Item2)) + 1 :
                    1;

            if (intMode)
            {
                if (expMax > 9)
                    return Tuple.Create(FormatType.Scientific, 1.0, 11);
                else
                    return Tuple.Create(FormatType.Int, 1.0, expMax + 1);
            }
            else
            {
                if (expMax - expMin > 4)
                {
                    var sz = Math.Abs(expMax) > 99 || Math.Abs(expMin) > 99 ?
                        12 : 11;
                    return Tuple.Create(FormatType.Scientific, 1.0, sz);
                }
                else
                {
                    if (expMax > 5 || expMax < 0)
                    {
                        return Tuple.Create(FormatType.Float,
                            Math.Pow(10, expMax - 1), 7);
                    }
                    else
                    {
                        return Tuple.Create(FormatType.Float, 1.0,
                            expMax == 0 ? 7 : expMax + 6);
                    }
                }
            }
        }

        /// <summary>
        /// Builds the format string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="size">The size.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">Invalid format type " + type</exception>
        private static string BuildFormatString(FormatType type, int size)
        {
            switch (type)
            {
                case FormatType.Int: return GetIntFormat(size);
                case FormatType.Float: return GetFloatFormat(size);
                case FormatType.Scientific: return GetScientificFormat(size);
                default: throw new InvalidOperationException("Invalid format type " + type);
            }
        }

        /// <summary>
        /// Gets the storage format.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="array">The array.</param>
        /// <returns>Tuple<System.String, System.Double, System.Int32&gt;.</returns>
        private static Tuple<string, double, int> GetStorageFormat(Storage storage, NDArray array)
        {
            if (storage.ElementCount == 0)
                return Tuple.Create("", 1.0, 0);

            bool intMode = IsIntOnly(storage, array);
            var minMax = AbsMinMax(storage, array);

            var formatSize = GetFormatSize(minMax, intMode);
            var formatString = BuildFormatString(formatSize.Item1, formatSize.Item3);

            return Tuple.Create("{0:" + formatString + "}", formatSize.Item2, formatSize.Item3);
        }

        /// <summary>
        /// Formats the size of the array type and.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>System.String.</returns>
        public static string FormatTensorTypeAndSize(NDArray array)
        {
            var result = new StringBuilder();
            result
                .Append("[Type: ")
                .Append(array.ElementType);

            if (array.DimensionCount == 0)
            {
                result.Append(" 0 Dimension");
            }
            else
            {
                result
                .Append(", Shape: ")
                .Append(array.Shape[0]);

                for (int i = 1; i < array.DimensionCount; ++i)
                {
                    result.Append("x").Append(array.Shape[i]);
                }
            }

            result.Append("]");
            return result.ToString();
        }

        /// <summary>
        /// Formats the vector.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="array">The array.</param>
        private static void FormatVector(StringBuilder builder, NDArray array)
        {
            var storageFormat = GetStorageFormat(array.Storage, array);
            var format = storageFormat.Item1;
            var scale = storageFormat.Item2;

            if (scale != 1)
            {
                builder.AppendLine(scale + " *");
                for (int i = 0; i < array.Shape[0]; ++i)
                {
                    var value = Convert.ToDouble((object)array.GetElementAsFloat(i)) / scale;
                    builder.AppendLine(string.Format(format, value));
                }
            }
            else
            {
                for (int i = 0; i < array.Shape[0]; ++i)
                {
                    var value = Convert.ToDouble((object)array.GetElementAsFloat(i));
                    builder.AppendLine(string.Format(format, value));
                }
            }
        }

        /// <summary>
        /// Formats the matrix.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="array">The array.</param>
        /// <param name="indent">The indent.</param>
        private static void FormatMatrix(StringBuilder builder, NDArray array, string indent)
        {
            var storageFormat = GetStorageFormat(array.Storage, array);
            var format = storageFormat.Item1;
            var scale = storageFormat.Item2;
            var sz = storageFormat.Item3;

            builder.Append(indent);

            var nColumnPerLine = (int)Math.Floor((80 - indent.Length) / (double)(sz + 1));
            long firstColumn = 0;
            long lastColumn = -1;
            while (firstColumn < array.Shape[1])
            {
                if (firstColumn + nColumnPerLine - 2 < array.Shape[1])
                {
                    lastColumn = firstColumn + nColumnPerLine - 2;
                }
                else
                {
                    lastColumn = array.Shape[1] - 1;
                }

                if (nColumnPerLine < array.Shape[1])
                {
                    if (firstColumn != 1)
                    {
                        builder.AppendLine();
                    }
                    builder.Append("Columns ").Append(firstColumn).Append(" to ").Append(lastColumn).AppendLine();
                }

                if (scale != 1)
                {
                    builder.Append(scale).AppendLine(" *");
                }

                for (long l = 0; l < array.Shape[0]; ++l)
                {
                    using (var row = array.Select(0, l))
                    {
                        for (long c = firstColumn; c <= lastColumn; ++c)
                        {
                            var value = Convert.ToDouble((object)row.GetElementAsFloat(c)) / scale;
                            builder.Append(string.Format(format, value));
                            if (c == lastColumn)
                            {
                                builder.AppendLine();
                                if (l != array.Shape[0])
                                {
                                    builder.Append(scale != 1 ? indent + " " : indent);
                                }
                            }
                            else
                            {
                                builder.Append(' ');
                            }
                        }
                    }
                }
                firstColumn = lastColumn + 1;
            }
        }

        /// <summary>
        /// Formats the array.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="array">The array.</param>
        private static void FormatTensor(StringBuilder builder, NDArray array)
        {
            var storageFormat = GetStorageFormat(array.Storage, array);
            var format = storageFormat.Item1;
            var scale = storageFormat.Item2;
            var sz = storageFormat.Item3;

            var startingLength = builder.Length;
            var counter = Enumerable.Repeat((long)0, array.DimensionCount - 2).ToArray();
            bool finished = false;
            counter[0] = -1;
            while (true)
            {
                for (int i = 0; i < array.DimensionCount - 2; ++i)
                {
                    counter[i]++;
                    if (counter[i] >= array.Shape[i])
                    {
                        if (i == array.DimensionCount - 3)
                        {
                            finished = true;
                            break;
                        }
                        counter[i] = 0;
                    }
                    else
                    {
                        break;
                    }
                }

                if (finished)
                    break;

                if (builder.Length - startingLength > 1)
                {
                    builder.AppendLine();
                }

                builder.Append('(');
                var tensorCopy = array.CopyRef();
                for (int i = 0; i < array.DimensionCount - 2; ++i)
                {
                    var newCopy = tensorCopy.Select(0, counter[i]);
                    tensorCopy.Dispose();
                    tensorCopy = newCopy;
                    builder.Append(counter[i]).Append(',');
                }

                builder.AppendLine(".,.) = ");
                FormatMatrix(builder, tensorCopy, " ");

                tensorCopy.Dispose();
            }
        }

        /// <summary>
        /// Formats the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>System.String.</returns>
        public static string Format(NDArray array)
        {
            var result = new StringBuilder();
            if (array.DimensionCount == 0)
            {
            }
            else if (array.DimensionCount == 1)
            {
                FormatVector(result, array);
            }
            else if (array.DimensionCount == 2)
            {
                FormatMatrix(result, array, "");
            }
            else
            {
                FormatTensor(result, array);
            }

            result.AppendLine(FormatTensorTypeAndSize(array));
            return result.ToString();
        }
    }
}
