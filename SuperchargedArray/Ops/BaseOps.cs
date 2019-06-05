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

    public class BaseOps
    {
        [NonSerialized]
        public float EPSILON = 1e-07f;

        /// <summary>
        /// Fill one hot label
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="labelCount">The label count.</param>
        /// <param name="labels">The labels.</param>
        /// <exception cref="InvalidOperationException">
        /// result must be a 2D array
        /// or
        /// first dimension of result must equal the number of samples
        /// or
        /// second dimension of result must be at least as large as labelCount
        /// or
        /// label at index " + i + " is out of range 0 <= x < labelCount
        /// </exception>
        public void FillOneHot(SuperArray src, int labelCount, int[] labels)
        {
            if (src.DimensionCount != 2) throw new InvalidOperationException("result must be a 2D array");
            if (src.Shape[0] != labels.Length) throw new InvalidOperationException("first dimension of result must equal the number of samples");
            if (src.Shape[1] > labelCount) throw new InvalidOperationException("second dimension of result must be at least as large as labelCount");

            for (int i = 0; i < labels.Length; ++i)
            {
                if (labels[i] < 0 || labels[i] >= labelCount)
                    throw new InvalidOperationException("label at index " + i + " is out of range 0 <= x < labelCount");

                src.SetElementAsFloat(1.0f, i, labels[i]);
            }
        }


        /// <summary>
        /// Tiles the specified tensor.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="repetitions">The repetitions.</param>
        /// <returns></returns>
        public SuperArray Tile(SuperArray x, long repetitions)
        {
            long[] shape = new long[x.DimensionCount];
            for (int i = 0; i < shape.Length; i++)
            {
                shape[i] = 1;
            }

            shape[shape.Length - 1] = repetitions;

            return x.RepeatTensor(shape);
        }

        /// <summary>
        /// Repeats the specified tensor.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="reps">The reps.</param>
        /// <returns></returns>
        public SuperArray Repeat(SuperArray x, int reps)
        {
            x = x.View(x.ElementCount(), 1).Tile(reps);
            return x.View(1, x.ElementCount());
        }

        /// <summary>Broadcasts the tensor.</summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public Tuple<SuperArray, SuperArray> BroadcastTensor(SuperArray lhs, SuperArray rhs)
        {
            if (!lhs.IsSameSizeAs(rhs))
            {
                if (lhs.Shape[0] == rhs.Shape[0] && (lhs.Shape[1] == 1 || rhs.Shape[1] == 1))
                {
                    if (lhs.Shape[1] == 1)
                    {
                        lhs = lhs.RepeatTensor(1, rhs.Shape[1]);
                    }

                    if (rhs.Shape[1] == 1)
                    {
                        rhs = rhs.RepeatTensor(1, lhs.Shape[1]);
                    }
                }

                if (lhs.Shape[1] == rhs.Shape[1] && (lhs.Shape[0] == 1 || rhs.Shape[0] == 1))
                {
                    if (lhs.Shape[0] == 1)
                    {
                        lhs = lhs.RepeatTensor(rhs.Shape[0], 1);
                    }

                    if (rhs.Shape[0] == 1)
                    {
                        rhs = rhs.RepeatTensor(lhs.Shape[0], 1);
                    }
                }

                if (lhs.Shape[1] == 1 && rhs.Shape[0] == 1)
                {
                    if (lhs.Shape[1] == 1)
                    {
                        lhs = lhs.RepeatTensor(1, rhs.Shape[1]);
                    }

                    if (rhs.Shape[0] == 1)
                    {
                        rhs = rhs.RepeatTensor(lhs.Shape[0], 1);
                    }
                }

                if (lhs.Shape[0] == 1 || rhs.Shape[1] == 1)
                {
                    if (lhs.Shape[0] == 1)
                    {
                        lhs = lhs.RepeatTensor(rhs.Shape[0], 1);
                    }

                    if (rhs.Shape[1] == 1)
                    {
                        rhs = rhs.RepeatTensor(1, lhs.Shape[1]);
                    }
                }
            }

            return new Tuple<SuperArray, SuperArray>(lhs, rhs);
        }
    }
}
