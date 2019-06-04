using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ArrayExtension
{
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
        public virtual void Fill(NDArray x, float value)
        {
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { x[i] = value; });
        }

        /// <summary>
        /// Dots the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Dot(NDArray a, NDArray b)
        {
            if (a.Shape[1] != b.Shape[0])
            {
                throw new Exception("a->Cols must be equal to b->Rows");
            }

            long m = a.Shape[0];
            long q = b.Shape[1];
            long n = a.Shape[1];
            NDArray r = new NDArray(m, q);

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
        /// NDArray.
        /// </returns>
        public virtual NDArray Abs(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = Math.Abs(x[i]); });

            return result;
        }


        /// <summary>
        /// Negs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Neg( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] =-x[i]; });
            return result;
        }

        /// <summary>
        /// Signs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Sign(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = Math.Sign(x[i]); });
            return result;
        }

        /// <summary>
        /// SQRTs the specified result.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Sqrt(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Sqrt(x[i]); });

            return result;
        }

        /// <summary>
        /// Exps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Exp( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Exp(x[i]); });

            return result;
        }

        /// <summary>
        /// Logs the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Log( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Log(x[i]); });

            return result;
        }

        /// <summary>
        /// Log1ps the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Log10( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Log10(x[i]); });

            return result;
        }
        
        /// <summary>
        /// Floors the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Floor( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Floor(x[i]); });

            return result;
        }

        /// <summary>
        /// Ceils the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Ceil( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Ceiling(x[i]); });

            return result;
        }

        /// <summary>
        /// Rounds the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="decimals">The decimals.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Round( NDArray x, int decimals = 0)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Trunc(NDArray x) {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Truncate(x[i]); });

            return result;
        }

        /// <summary>
        /// Fracs the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Frac(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = x[i] - (float)Math.Truncate(x[i]); });

            return result;
        }

        /// <summary>
        /// Sins the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Sin(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Sin(x[i]); });

            return result;
        }

        /// <summary>
        /// Coses the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Cos( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Cos(x[i]); });

            return result;
        }

        /// <summary>
        /// Tans the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Tan(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Tan(x[i]); });

            return result;
        }

        /// <summary>
        /// Asins the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Asin(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Asin(x[i]); });

            return result;
        }

        /// <summary>
        /// Acoses the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Acos( NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Acos(x[i]); });

            return result;
        }

        /// <summary>
        /// Atans the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Atan(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Atan(x[i]); });

            return result;
        }

        /// <summary>
        /// Sinhes the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Sinh(NDArray x) {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Sinh(x[i]); });

            return result;
        }

        /// <summary>
        /// Coshes the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Cosh(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Cosh(x[i]); });

            return result;
        }

        /// <summary>
        /// Tanhes the specified result.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray Tanh(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
            Parallel.For(0, x.Elements, new ParallelOptions() { MaxDegreeOfParallelism = Global.ParallelThread }, (i) => { result[i] = (float)Math.Tanh(x[i]); });

            return result;
        }

        /// <summary>
        /// Sigmoids the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Sigmoid(NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Atan2(NDArray y,NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Pow(NDArray x, float value)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Square(NDArray x)
        {
            return Pow(x, 2);
        }

        /// <summary>
        /// Tpows the specified result.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="x">The x.</param>
        /// <returns>
        /// NDArray.
        /// </returns>
        public virtual NDArray TPow(float value, NDArray x)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Lerp(NDArray x0, NDArray x1, float weight)
        {
            NDArray result = new NDArray(x0.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Clip(NDArray x, float min, float max)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Add(NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Add(NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Add(float lhs, NDArray rhs)
        {
            NDArray result = new NDArray(rhs.Shape);
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
        public virtual NDArray Sub(NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        public virtual NDArray Sub(NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        public virtual NDArray Sub(float lhs, NDArray rhs)
        {
            NDArray result = new NDArray(rhs.Shape);
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
        public virtual NDArray Mul(NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        public virtual NDArray Mul(NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        public virtual NDArray Mul(float lhs, NDArray rhs)
        {
            NDArray result = new NDArray(rhs.Shape);
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
        public virtual NDArray Div(NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        public virtual NDArray Div(NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        public virtual NDArray Div(float lhs, NDArray rhs)
        {
            NDArray result = new NDArray(rhs.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Mod(NDArray x, float scalar)
        {
            NDArray result = new NDArray(x.Shape);
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Mod(NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray GreaterThan( NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray LessThan( NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray GreaterOrEqual( NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray LessOrEqual( NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray EqualTo( NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray NotEqual( NDArray lhs, float rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray GreaterThan( NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray LessThan( NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray GreaterOrEqual( NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray LessOrEqual( NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray EqualTo( NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray NotEqual( NDArray lhs, NDArray rhs)
        {
            NDArray result = new NDArray(lhs.Shape);
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
        /// NDArray.
        /// </returns>
        public float Sum(NDArray x)
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
        /// NDArray.
        /// </returns>
        public virtual NDArray Sum(NDArray x, int dimension)
        {
            dimension = dimension < 0 ? x.DimensionCount + dimension : dimension;
            NDArray result = new NDArray(x.Shape[0]);
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
        public float Minus(NDArray x)
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
        public virtual NDArray Minus(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        public float Prod(NDArray x)
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
        public virtual NDArray Prod(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        public float Min(NDArray x)
        {
            return x.DataFloat.Min();
        }

        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual NDArray Min(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        public float Max(NDArray x)
        {
            return x.DataFloat.Max();
        }

        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual NDArray Max(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray Argmin(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        /// <returns>NDArray.</returns>
        public virtual NDArray Argmax(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        public float Mean(NDArray x)
        {
            return x.DataFloat.Average();
        }

        /// <summary>
        /// Means the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dimension">The dimension.</param>
        /// <returns></returns>
        public virtual NDArray Mean(NDArray x, int dimension)
        {
            NDArray result = new NDArray(x.Shape[0]);
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
        public virtual NDArray Maximum(NDArray a, NDArray b)
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
        public virtual NDArray Maximum(NDArray a, float b)
        {
            var b_t = new NDArray(a.Shape, a.ElementType);
            b_t.Fill(b);
            return Maximum(a, b_t);
        }

        /// <summary>
        /// Maximums the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public virtual NDArray Maximum(float a, NDArray b)
        {
            var a_t = new NDArray(b.Shape, b.ElementType);
            a_t.Fill( a);
            return Maximum(a_t, b);
        }

        /// <summary>
        /// Diags the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public virtual NDArray Diag(NDArray x)
        {
            NDArray result = new NDArray(x.Elements, x.Elements);
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
        public void RandomUniform(NDArray x, float min, float max, int? seed = null)
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
        public void RandomNormal(NDArray x, float mean, float stdv, int? seed = null)
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
        public void RandomExponential(NDArray x, float lambda, int? seed = null)
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
        public void RandomCauchy(NDArray x, float median, float sigma, int? seed = null)
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
        public void RandomGeometric(NDArray x, float p, int? seed = null)
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
        public void RandomBernoulli(NDArray x, float p, int? seed = null)
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
        public void RandomLogNormal(NDArray x, float mean, float stdv, int? seed = null)
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
        /// <returns>NDArray.</returns>
        public virtual NDArray Norm(NDArray x, int dimension, float value) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (NDArray)OpRegistry.Invoke("norm", null, src, dimension, value); }

        /// <summary>
        /// Standards the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Std(NDArray x, int dimension, bool normByN) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (NDArray)OpRegistry.Invoke("std", null, src, dimension, normByN); }
        /// <summary>
        /// Variables the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="dimension">The dimension.</param>
        /// <param name="normByN">if set to <c>true</c> [norm by n].</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Var(NDArray x, int dimension, bool normByN) { dimension = dimension < 0 ? src.DimensionCount + dimension : dimension; return (NDArray)OpRegistry.Invoke("var", null, src, dimension, normByN); }

        /// <summary>
        /// Norms all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Norm(NDArray x, float value) { return (NDArray)OpRegistry.Invoke("normall", null, src, value); }
        /// <summary>
        /// Standards all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Std(NDArray x) { return (NDArray)OpRegistry.Invoke("stdall", null, src); }
        /// <summary>
        /// Variables all.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="src">The source.</param>
        /// <returns>NDArray.</returns>
        public virtual NDArray Var(NDArray x) { return (NDArray)OpRegistry.Invoke("varall", null, src); }
        */
    }
}
