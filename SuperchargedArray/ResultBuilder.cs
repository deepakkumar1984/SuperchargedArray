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
    /// Class SuperArrayResultBuilder.
    /// </summary>
    internal static class ArrayResultBuilder
    {
        // If a maybeResult is null, a new array will be constructed using the device id and element type of newTemplate
        /// <summary>
        /// Gets the write target.
        /// </summary>
        /// <param name="maybeResult">The maybe result.</param>
        /// <param name="newTemplate">The new template.</param>
        /// <param name="requireContiguous">if set to <c>true</c> [require contiguous].</param>
        /// <param name="requiredSizes">The required sizes.</param>
        /// <returns>SuperArray.</returns>
        public static SuperArray GetWriteTarget(SuperArray maybeResult, SuperArray newTemplate, bool requireContiguous, params long[] requiredSizes)
        {
            return GetWriteTarget(maybeResult, newTemplate.ElementType, requireContiguous, requiredSizes);
        }

        /// <summary>
        /// Gets the write target.
        /// </summary>
        /// <param name="maybeResult">The maybe result.</param>
        /// <param name="elementTypeForNew">The element type for new.</param>
        /// <param name="requireContiguous">if set to <c>true</c> [require contiguous].</param>
        /// <param name="requiredSizes">The required sizes.</param>
        /// <returns>SuperArray.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static SuperArray GetWriteTarget(SuperArray maybeResult, DType elementTypeForNew, bool requireContiguous, params long[] requiredSizes)
        {
            if (maybeResult != null)
            {
                if (!MatchesRequirements(maybeResult, requireContiguous, requiredSizes))
                {
                    var message = string.Format("output array does not match requirements. SuperArray must have sizes {0}{1}",
                        string.Join(", ", requiredSizes),
                        requireContiguous ? "; and must be contiguous" : "");

                    throw new InvalidOperationException(message);
                }
                return maybeResult;
            }
            else
            {
                return new SuperArray(requiredSizes, elementTypeForNew);
            }
        }

        /// <summary>
        /// Matcheses the requirements.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="requireContiguous">if set to <c>true</c> [require contiguous].</param>
        /// <param name="requiredSizes">The required sizes.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool MatchesRequirements(SuperArray array, bool requireContiguous, params long[] requiredSizes)
        {
            if (requireContiguous && !array.IsContiguous())
            {
                return false;
            }

            return ArrayEqual(array.Shape, requiredSizes);
        }

        /// <summary>
        /// Arrays the equal.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ArrayEqual<T>(T[] a, T[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; ++i)
            {
                if (!a[i].Equals(b[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Arrays the equal except.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="ignoreIndex">Index of the ignore.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ArrayEqualExcept<T>(T[] a, T[] b, int ignoreIndex)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; ++i)
            {
                if (i == ignoreIndex)
                    continue;

                if (!a[i].Equals(b[i]))
                    return false;
            }

            return true;
        }
    }
}
