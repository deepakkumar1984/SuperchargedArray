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
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Class TOps.
    /// </summary>
    public class ArrayOps : BaseOps
    {
        /// <summary>
        /// Fills the specified result.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="value">The value.</param>
        public virtual void Fill(SuperArray x, float value)
        {
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { x[i] = value; });
        }

        /// <summary>
        /// Create constant array with the specified value.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="value">The value.</param>
        public virtual SuperArray Constant(float value, long[] shape)
        {
            SuperArray x = new SuperArray(shape);
            Fill(x, value);
            return x;
        }

        /// <summary>
        /// Dots the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Dot(SuperArray a, SuperArray b)
        {
            if (a.Shape[1] != b.Shape[0])
            {
                throw new Exception("a->Cols must be equal to b->Rows");
            }

            long m = a.Shape[0];
            long q = b.Shape[1];
            long n = a.Shape[1];
            SuperArray r = new SuperArray(m, q);

            Parallel.For(0, m, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, i =>
            {
                Parallel.For(0, q, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, j =>
                {
                    Parallel.For(0, n, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, k =>
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    });
                });
            });

            return r;
        }

        /// <summary>
        /// Abses the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Abs(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = Math.Abs(x[i]); });

            return result;
        }

        /// <summary>
        /// Negs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Neg( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] =-x[i]; });
            return result;
        }

        /// <summary>
        /// Signs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Sign(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = Math.Sign(x[i]); });
            return result;
        }

        /// <summary>
        /// SQRTs the specified result.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Sqrt(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Sqrt(x[i]); });

            return result;
        }

        /// <summary>
        /// Exps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Exp( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Exp(x[i]); });

            return result;
        }

        /// <summary>
        /// Logs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Log( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Log(x[i]); });

            return result;
        }

        /// <summary>
        /// Log1ps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Log10( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Log10(x[i]); });

            return result;
        }
        
        /// <summary>
        /// Floors the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Floor( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Floor(x[i]); });

            return result;
        }

        /// <summary>
        /// Ceils the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Ceil( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Ceiling(x[i]); });

            return result;
        }

        /// <summary>
        /// Rounds the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Round( SuperArray x, int decimals = 0)
        {
            SuperArray result = new SuperArray(x.Shape);
            if (decimals > 0)
                Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Round(x[i], decimals); });
            else
                Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Round(x[i]); });

            return result;
        }

        /// <summary>
        /// Truncs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Trunc(SuperArray x) {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Truncate(x[i]); });

            return result;
        }

        /// <summary>
        /// Fracs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Frac(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = x[i] - (float)Math.Truncate(x[i]); });

            return result;
        }

        /// <summary>
        /// Sins the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Sin(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Sin(x[i]); });

            return result;
        }

        /// <summary>
        /// Coses the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Cos( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Cos(x[i]); });

            return result;
        }

        /// <summary>
        /// Tans the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Tan(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Tan(x[i]); });

            return result;
        }

        /// <summary>
        /// Asins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Asin(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Asin(x[i]); });

            return result;
        }

        /// <summary>
        /// Acoses the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Acos( SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Acos(x[i]); });

            return result;
        }

        /// <summary>
        /// Atans the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Atan(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Atan(x[i]); });

            return result;
        }

        /// <summary>
        /// Sinhes the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Sinh(SuperArray x) {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Sinh(x[i]); });

            return result;
        }

        /// <summary>
        /// Coshes the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Cosh(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Cosh(x[i]); });

            return result;
        }

        /// <summary>
        /// Tanhes the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Tanh(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Tanh(x[i]); });

            return result;
        }

        /// <summary>
        /// Sigmoids the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Sigmoid(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => 
            {
                var exp = (float)Math.Exp(x[i]);

                result[i] = exp / (exp + 1);
            });

            return result;
        }

        /// <summary>
        /// Atan2s the specified result.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Atan2(SuperArray y,SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = (float)Math.Atan2(y[i], x[i]);
            });

            return result;
        }

        /// <summary>
        /// Pows the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Pow(SuperArray x, float value)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = (float)Math.Pow(x[i], value);
            });

            return result;
        }

        /// <summary>
        /// Squares the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Square(SuperArray x)
        {
            return Pow(x, 2);
        }

        /// <summary>
        /// Tpows the specified result.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="x">The x.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray TPow(float value, SuperArray x)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = (float)Math.Pow(value, x[i]);
            });

            return result;
        }

        /// <summary>
        /// Lerps the specified result.
        /// </summary>
        /// <param name="x0">The x0.</param>
        /// <param name="x1">The x1.</param>
        /// <param name="weight">The weight.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Lerp(SuperArray x0, SuperArray x1, float weight)
        {
            SuperArray result = new SuperArray(x0.Shape);
            Parallel.For(0, x0.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = x0[i] + weight * (x1[i] - x0[i]);
            });

            return result;
        }

        /// <summary>
        /// Clamps the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Clip(SuperArray x, float min, float max)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = (x[i] < min) ? min : (x[i] > max) ? max : x[i];
            });

            return result;
        }

        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Add(SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] + rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Add(SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] + rhs;
            });

            return result;
        }

        /// <summary>
        /// Adds the specified result.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Add(float lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(rhs.Shape);
            Parallel.For(0, rhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs + rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Subs the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Sub(SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] - rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Subs the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Sub(SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] - rhs;
            });

            return result;
        }

        /// <summary>
        /// Subs the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Sub(float lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(rhs.Shape);
            Parallel.For(0, rhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs - rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Muls the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Mul(SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] * rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Muls the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Mul(SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] * rhs;
            });

            return result;
        }

        /// <summary>
        /// Muls the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Mul(float lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(rhs.Shape);
            Parallel.For(0, rhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs * rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Divs the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Div(SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] / rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Divs the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Div(SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] / rhs;
            });

            return result;
        }

        /// <summary>
        /// Divide the specified LHS.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns></returns>
        public virtual SuperArray Div(float lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(rhs.Shape);
            Parallel.For(0, rhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs / rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Mods the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Mod(SuperArray x, float scalar)
        {
            SuperArray result = new SuperArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = x[i] % scalar;
            });

            return result;
        }

        /// <summary>
        /// Mods the specified result.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Mod(SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] % rhs[i];
            });

            return result;
        }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray GreaterThan( SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] > rhs ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray LessThan( SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] < rhs ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Greaters the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray GreaterOrEqual( SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] >= rhs ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Lesses the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray LessOrEqual( SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] <= rhs ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Equals to.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray EqualTo( SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] == rhs ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Nots the equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray NotEqual( SuperArray lhs, float rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] != rhs ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray GreaterThan( SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] > rhs[i] ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray LessThan( SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] < rhs[i] ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Greaters the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray GreaterOrEqual( SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] >= rhs[i] ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Lesses the or equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray LessOrEqual( SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] <= rhs[i] ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Equals to.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray EqualTo( SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] == rhs[i] ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Nots the equal.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray NotEqual( SuperArray lhs, SuperArray rhs)
        {
            SuperArray result = new SuperArray(lhs.Shape);
            Parallel.For(0, lhs.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i] = lhs[i] != rhs[i] ? 1 : 0;
            });

            return result;
        }

        /// <summary>
        /// Sums the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public float Sum(SuperArray x)
        {
            float result = 0;
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result += x[i];
            });

            return result;
        }

        /// <summary>
        /// Sums the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>
        /// SuperArray.
        /// </returns>
        public virtual SuperArray Sum(SuperArray x, int dimension)
        {
            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);
            if (dimension > 0)
                x = x.Transpose();

            Parallel.For(0, x.Shape[0], (i) =>
            {
                result[i] = x.Select(0, i).DataFloat.Sum();
            });

            return result;
        }

        /// <summary>
        /// Minuses the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public float Minus(SuperArray x)
        {
            float result = 0;
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result -= x[i];
            });

            return result;
        }

        /// <summary>
        /// Minuses the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual SuperArray Minus(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();
            Parallel.For(0, x.Shape[0], (i) =>
            {
                Parallel.ForEach(x.Select(0, i).DataFloat, (d) => {
                    result[i] -= d;
                });
            });

            return result;
        }

        /// <summary>
        /// Product the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public float Prod(SuperArray x)
        {
            float result = 1;
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result *= x[i];
            });

            return result;
        }

        /// <summary>
        /// Product the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual SuperArray Prod(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(1);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();
            Parallel.For(0, x.Shape[0], (i) =>
            {
                Parallel.ForEach(x.Select(0, i).DataFloat, (d) => {
                    result[i] *= d;
                });
            });

            return result;
        }

        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public float Min(SuperArray x)
        {
            return x.DataFloat.Min();
        }

        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual SuperArray Min(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();

            Parallel.For(0, x.Shape[0], (i) =>
            {
                result[i] = x.Select(0, i).DataFloat.Min();
            });

            return result;
        }

        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public float Max(SuperArray x)
        {
            return x.DataFloat.Max();
        }

        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual SuperArray Max(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();

            Parallel.For(0, x.Shape[0], (i) =>
            {
                result[i] = x.Select(0, i).DataFloat.Max();
            });

            return result;
        }

        /// <summary>
        /// Argmins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Argmin(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();

            Parallel.For(0, x.Shape[0], (i) =>
            {
                var d = x.Select(0, i).DataFloat;
                result[i] = d.IndexOf(d.Min());
            });

            return result;
        }

        /// <summary>
        /// Argmaxes the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Argmax(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();

            Parallel.For(0, x.Shape[0], (i) =>
            {
                var d = x.Select(0, i).DataFloat;
                result[i] = d.IndexOf(d.Max());
            });

            return result;
        }

        /// <summary>
        /// Means the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public float Mean(SuperArray x)
        {
            return x.DataFloat.Average();
        }

        /// <summary>
        /// Means the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual SuperArray Mean(SuperArray x, int dimension)
        {
            SuperArray result = new SuperArray(x.Shape[0]);
            result.Fill(0);

            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            if (dimension > 0)
                x = x.Transpose();

            Parallel.For(0, x.Shape[0], (i) =>
            {
                result[i] = x.Select(0, i).DataFloat.Average();
            });
            
            return result;
        }

        /// <summary>
        /// Maximums the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public virtual SuperArray Maximum(SuperArray a, SuperArray b)
        {
            var t1 = (a >= b);
            var t2 = (a > b);

            return (t1 * a + t2 * b);
        }

        /// <summary>
        /// Maximums the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public virtual SuperArray Maximum(SuperArray a, float b)
        {
            var b_t = new SuperArray(a.Shape, a.ElementType);
            b_t.Fill(b);
            return Maximum(a, b_t);
        }

        /// <summary>
        /// Maximums the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public virtual SuperArray Maximum(float a, SuperArray b)
        {
            var a_t = new SuperArray(b.Shape, b.ElementType);
            a_t.Fill( a);
            return Maximum(a_t, b);
        }

        /// <summary>
        /// Diags the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public virtual SuperArray Diag(SuperArray x)
        {
            SuperArray result = new SuperArray(x.Elements, x.Elements);
            result.Fill(0);

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                result[i, i] = x[i];
            });

            return result;
        }

        /// <summary>
        /// Randoms the uniform.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="seedSource">The seed source.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public void RandomUniform(SuperArray x, float min, float max, int? seed = null)
        {
            Random rnd = null;
            if (seed.HasValue)
                rnd = new Random(seed.Value);

            rnd = new Random();

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                x[i] = (float)rnd.NextDouble() * (max - min) + min;
            });
        }

        /// <summary>
        /// Randoms the normal.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="stdv">The STDV.</param>
        /// <param name="seed">The seed.</param>
        public void RandomNormal(SuperArray x, float mean, float stdv, int? seed = null)
        {
            Random rnd = null;
            if (seed.HasValue)
                rnd = new Random(seed.Value);

            rnd = new Random();

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                var normal_x = rnd.NextDouble();
                var normal_y = rnd.NextDouble();
                var normal_rho = Math.Sqrt(-2 * Math.Log(1.0 - normal_y));
                if (i%2 == 0)
                {
                    x[i] = (float)(normal_rho * Math.Cos(2 * Math.PI * normal_x) * stdv + mean);
                }
                else
                {
                    x[i] = (float)(normal_rho * Math.Sin(2 * Math.PI * normal_x) * stdv + mean);
                }
            });
        }

        /// <summary>
        /// Randoms the exponential.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="lambda">The lambda.</param>
        /// <param name="seed">The seed.</param>
        public void RandomExponential(SuperArray x, float lambda, int? seed = null)
        {
            Random rnd = null;
            if (seed.HasValue)
                rnd = new Random(seed.Value);

            rnd = new Random();

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                x[i] = (float)(-1.0 / lambda * Math.Log(1.0 - rnd.NextDouble()));
            });
        }

        /// <summary>
        /// Randoms the cauchy.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="median">The median.</param>
        /// <param name="sigma">The sigma.</param>
        /// <param name="seed">The seed.</param>
        public void RandomCauchy(SuperArray x, float median, float sigma, int? seed = null)
        {
            Random rnd = null;
            if (seed.HasValue)
                rnd = new Random(seed.Value);

            rnd = new Random();

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                x[i] = (float)(median + sigma * Math.Tan(Math.PI * (rnd.NextDouble() - 0.5)));
            });
        }

        /// <summary>
        /// Randoms the geometric.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="p">The p.</param>
        /// <param name="seed">The seed.</param>
        public void RandomGeometric(SuperArray x, float p, int? seed = null)
        {
            Random rnd = null;
            if (seed.HasValue)
                rnd = new Random(seed.Value);

            rnd = new Random();

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                x[i] = (float)(Math.Log(1 - rnd.NextDouble()) / Math.Log(p) + 1);
            });
        }

        /// <summary>
        /// Randoms the bernoulli.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="p">The p.</param>
        /// <param name="seed">The seed.</param>
        /// <exception cref="System.ArgumentException">p should be between 0 and 1</exception>
        public void RandomBernoulli(SuperArray x, float p, int? seed = null)
        {
            if (p <= 0 || p > 1)
            {
                throw new ArgumentException("p should be between 0 and 1");
            }

            Random rnd = null;
            if (seed.HasValue)
                rnd = new Random(seed.Value);

            rnd = new Random();

            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) =>
            {
                x[i] = rnd.NextDouble() <= p ? 0 : 1;
            });
        }

        /// <summary>
        /// Randoms the log normal.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="mean">The mean.</param>
        /// <param name="stdv">The STDV.</param>
        /// <param name="seed">The seed.</param>
        public void RandomLogNormal(SuperArray x, float mean, float stdv, int? seed = null)
        {
            double zm = mean * mean;
            double zs = stdv * stdv;

            double lmean = Math.Log(zm / Math.Sqrt(zs + zm));
            double lstdv = Math.Sqrt(Math.Log(zs / zm + 1));

            RandomNormal(x, (float)lmean, (float)lstdv, seed);
            x = Exp(x);
        }

        /*
        /// <summary>
        /// Norms the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="value">The value.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Norm(SuperArray x, int dimension, float value) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (SuperArray)OpRegistry.Invoke("norm", null, src, dimension, value); }

        /// <summary>
        /// Standards the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Std(SuperArray x, int dimension, bool normByN) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (SuperArray)OpRegistry.Invoke("std", null, src, dimension, normByN); }
        /// <summary>
        /// Variables the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Var(SuperArray x, int dimension, bool normByN) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (SuperArray)OpRegistry.Invoke("var", null, src, dimension, normByN); }

        /// <summary>
        /// Norms all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Norm(SuperArray x, float value) { return (SuperArray)OpRegistry.Invoke("normall", null, src, value); }
        /// <summary>
        /// Standards all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Std(SuperArray x) { return (SuperArray)OpRegistry.Invoke("stdall", null, src); }
        /// <summary>
        /// Variables all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>SuperArray.</returns>
        public virtual SuperArray Var(SuperArray x) { return (SuperArray)OpRegistry.Invoke("varall", null, src); }
        */
    }
}
