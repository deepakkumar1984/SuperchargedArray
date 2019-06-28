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
    using System.Threading.Tasks;

    /// <summary>
    /// Class TensorDimensionHelpers.
    /// </summary>
    public static class Helper
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
        public static SuperArray NewContiguous(SuperArray src)
        {
            var result = new SuperArray((long[])src.Shape.Clone(), src.ElementType);
            Copy(result, src);
            return result;
        }

        /// <summary>
        /// Ases the contiguous.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public static SuperArray AsContiguous(SuperArray src)
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
        public static void Copy(SuperArray result, SuperArray src)
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
            else if (src.DimensionCount == 5)
            {
                Parallel.For(0, src.Shape[0], (i) =>
                {
                    Parallel.For(0, src.Shape[1], (j) =>
                    {
                        Parallel.For(0, src.Shape[2], (k) =>
                        {
                            Parallel.For(0, src.Shape[3], (l) =>
                            {
                                Parallel.For(0, src.Shape[4], (m) =>
                                {
                                    result[i, j, k, l, m] = src[i, j, k, l, m];
                                });
                            });
                        });
                    });
                });
            }
        }
    }
}
