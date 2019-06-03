using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenCL.Tensor
{
    /// <summary>
    /// Class TensorDimensionHelpers.
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// Elements the count.
        /// </summary>
        /// <param name="sizes">The sizes.</param>
        /// <returns>System.Int64.</returns>
        public static long ElementCount(long[] sizes)
        {
            if (sizes.Length == 0)
                return 0;

            var total = 1L;
            for (int i = 0; i < sizes.Length; ++i)
                total *= sizes[i];
            return total;
        }

        /// <summary>
        /// Gets the size of the storage.
        /// </summary>
        /// <param name="sizes">The sizes.</param>
        /// <param name="strides">The strides.</param>
        /// <returns>System.Int64.</returns>
        public static long GetStorageSize(long[] sizes, long[] strides)
        {
            long offset = 0;
            for (int i = 0; i < sizes.Length; ++i)
            {
                offset += (sizes[i] - 1) * strides[i];
            }
            return offset + 1; // +1 to count last element, which is at *index* equal to offset
        }

        // Returns the stride required for a array to be contiguous.
        // If a array is contiguous, then the elements in the last dimension are contiguous in memory,
        // with lower numbered dimensions having increasingly large strides.
        /// <summary>
        /// Gets the contiguous stride.
        /// </summary>
        /// <param name="dims">The dims.</param>
        /// <returns>System.Int64[].</returns>
        public static long[] GetContiguousStride(long[] dims)
        {
            long acc = 1;
            var stride = new long[dims.Length];
            for (int i = dims.Length - 1; i >= 0; --i)
            {
                stride[i] = acc;
                acc *= dims[i];
            }

            return stride;
        }

        /// <summary>
        /// Creates new contiguous.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public static NDArray NewContiguous(NDArray src)
        {
            var result = new NDArray((long[])src.Shape.Clone(), src.ElementType);
            Copy(result, src);
            return result;
        }

        /// <summary>
        /// Ases the contiguous.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public static NDArray AsContiguous(NDArray src)
        {
            if (src.IsContiguous())
                return src.CopyRef();
            else
                return NewContiguous(src);
        }

        /// <summary>
        /// Copies the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        public static void Copy(NDArray result, NDArray src)
        {
            var r = src.ToArray();
            if (src.DimensionCount == 2)
            {
                Parallel.For(0, src.Shape[0], (i) =>
                {
                    Parallel.For(0, src.Shape[1], (j) =>
                    {
                        result[i, j] = src[i, j];
                    });
                });
            }
            else if (src.DimensionCount == 3)
            {
                Parallel.For(0, src.Shape[0], (i) =>
                {
                    Parallel.For(0, src.Shape[1], (j) =>
                    {
                        Parallel.For(0, src.Shape[2], (k) =>
                        {
                            result[i, j, k] = src[i, j, k];
                        });
                    });
                });
            }
            else if (src.DimensionCount == 4)
            {
                Parallel.For(0, src.Shape[0], (i) =>
                {
                    Parallel.For(0, src.Shape[1], (j) =>
                    {
                        Parallel.For(0, src.Shape[2], (k) =>
                        {
                            Parallel.For(0, src.Shape[3], (l) =>
                            {
                                result[i, j, k, l] = src[i, j, k, l];
                            });
                        });
                    });
                });
            }
        }
    }
}
