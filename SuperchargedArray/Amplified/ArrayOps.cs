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
using Amplifier;
using System;

namespace SuperchargedArray.Amplified
{
    public class ArrayOps : SuperchargedArray.ArrayOps
    {
        private string GetFuncName(string name, DType dType)
        {
            if (dType == DType.Single)
                return string.Format("{0}_float", name);
            else if (dType == DType.Double)
                return string.Format("{0}_double", name);

            return name;
        }

        private dynamic floatExec = Global.Compiler.GetExec();
        private dynamic doubleExec = Global.Compiler.GetExec();

        private SuperArray ExecuteReturn(string name, SuperArray x)
        {
            Array r = null;
            if (x.ElementType == DType.Single)
            {
                r = new float[x.Elements];
                Global.Compiler.Execute(name, x.Data<float>(), r);
            }
            else
            {
                r = new double[x.Elements];
                Global.Compiler.Execute(name, x.Data<double>(), r);
            }

            SuperArray result = new SuperArray(x.Shape);
            result.LoadFrom(r);

            return result;
        }

        private SuperArray ExecuteReturn(string name, SuperArray x, SuperArray y)
        {
            Array r = null;
            if (x.ElementType == DType.Single)
            {
                r = new float[x.Elements];
                Global.Compiler.Execute(name, x.Data<float>(), y.Data<float>(), r);
            }
            else
            {
                r = new double[x.Elements];
                Global.Compiler.Execute(name, x.Data<double>(), y.Data<double>(), r);
            }

            SuperArray result = new SuperArray(x.Shape);
            result.LoadFrom(r);

            return result;
        }

        public override void Fill(SuperArray x, float value)
        {
            Array data = null;
            if (x.ElementType == DType.Single)
            {
                data = x.Data<float>();
                floatExec.ndarr_fill_float(data, value);
            }
            else
            {
                data = x.Data<double>();
                doubleExec.ndarr_fill_double(data, value);
            }

            x.LoadFrom(data);
        }

        /// <summary>
        /// Create constant array with the specified value.
        /// </summary>
        /// <param name="src">The source array.</param>
        /// <param name="value">The value.</param>
        public override SuperArray Constant(float value, long[] shape)
        {
            SuperArray x = new SuperArray(shape);
            Fill(x, value);
            return x;
        }

        public override SuperArray Abs(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_abs", x.ElementType), x);
        }

        public override SuperArray Sin(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_sin", x.ElementType), x);
        }

        public override SuperArray Cos(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_cos", x.ElementType), x);
        }

        public override SuperArray Tan(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_tan", x.ElementType), x);
        }

        public override SuperArray Sinh(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_sinh", x.ElementType), x);
        }

        public override SuperArray Cosh(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_cosh", x.ElementType), x);
        }

        public override SuperArray Tanh(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_tanh", x.ElementType), x);
        }

        public override SuperArray Asin(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_arcsin", x.ElementType), x);
        }

        public override SuperArray Acos(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_arccos", x.ElementType), x);
        }

        public override SuperArray Atan(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_arctan", x.ElementType), x);
        }

        public override SuperArray Atan2(SuperArray y, SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_arctan2", x.ElementType), x, y);
        }

        public override SuperArray Add(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return ExecuteReturn(GetFuncName("ndarr_add", rhs.ElementType), lhs_arr, rhs);
        }

        public override SuperArray Add(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_add", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray Add(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_add", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray Sub(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return ExecuteReturn(GetFuncName("ndarr_sub", rhs.ElementType), lhs_arr, rhs);
        }

        public override SuperArray Sub(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_sub", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray Sub(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_sub", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray Mul(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return ExecuteReturn(GetFuncName("ndarr_mul", rhs.ElementType), lhs_arr, rhs);
        }

        public override SuperArray Mul(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_mul", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray Mul(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_mul", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray Div(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return ExecuteReturn(GetFuncName("ndarr_div", rhs.ElementType), lhs_arr, rhs);
        }

        public override SuperArray Div(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_div", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray Div(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_div", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray GreaterThan(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_gt", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray GreaterThan(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_gt", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray GreaterOrEqual(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_ge", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray GreaterOrEqual(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_ge", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray LessThan(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_lt", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray LessThan(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_lt", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray LessOrEqual(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_le", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray LessOrEqual(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_le", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray EqualTo(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_eq", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray EqualTo(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_eq", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray NotEqual(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return ExecuteReturn(GetFuncName("ndarr_ne", lhs.ElementType), lhs, rhs_arr);
        }

        public override SuperArray NotEqual(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_ne", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray Ceil(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_ceil", x.ElementType), x);
        }

        public override SuperArray Clip(SuperArray x, float min, float max)
        {
            return ExecuteReturn(GetFuncName("ndarr_clip", x.ElementType), new object[] { x, min, max });
        }

        public override SuperArray Diag(SuperArray x)
        {
            //ToDo: Need to implement with OpenCL
            return base.Diag(x);
        }

        public override SuperArray Argmax(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Argmax(x, dimension);
        }

        public override SuperArray Argmin(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Argmin(x, dimension);
        }

        public override SuperArray Dot(SuperArray a, SuperArray b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Dot(a, b);
        }

        public override SuperArray Exp(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_exp", x.ElementType), x);
        }

        public override SuperArray Floor(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_floor", x.ElementType), x);
        }

        public override SuperArray Frac(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_frac", x.ElementType), x);
        }

        public override SuperArray Lerp(SuperArray x0, SuperArray x1, float weight)
        {
            //ToDo: Need to implement with OpenCL
            return base.Lerp(x0, x1, weight);
        }

        public override SuperArray Log(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_log", x.ElementType), x);
        }

        public override SuperArray Log10(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_log10", x.ElementType), x);
        }

        public override SuperArray Max(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Max(x, dimension);
        }

        public override SuperArray Maximum(float a, SuperArray b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Maximum(a, b);
        }

        public override SuperArray Maximum(SuperArray a, float b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Maximum(a, b);
        }

        public override SuperArray Maximum(SuperArray a, SuperArray b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Maximum(a, b);
        }

        public override SuperArray Mean(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Mean(x, dimension);
        }

        public override SuperArray Min(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Min(x, dimension);
        }

        public override SuperArray Minus(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Minus(x, dimension);
        }

        public override SuperArray Mod(SuperArray lhs, SuperArray rhs)
        {
            return ExecuteReturn(GetFuncName("ndarr_mod", lhs.ElementType), lhs, rhs);
        }

        public override SuperArray Mod(SuperArray x, float scalar)
        {
            SuperArray rhs_arr = new SuperArray(x.Shape);
            rhs_arr.Fill(scalar);
            return ExecuteReturn(GetFuncName("ndarr_mod", x.ElementType), new object[] { x, rhs_arr });
        }

        public override SuperArray Neg(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_neg", x.ElementType), x);
        }

        public override SuperArray Pow(SuperArray x, float value)
        {
            return ExecuteReturn(GetFuncName("ndarr_pow", x.ElementType), new object[] { x, value });
        }

        public override SuperArray Prod(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Prod(x, dimension);
        }

        public override SuperArray Round(SuperArray x, int decimals = 0)
        {
            return ExecuteReturn(GetFuncName("ndarr_round", x.ElementType), x);
        }

        public override SuperArray Sigmoid(SuperArray x)
        {
            //ToDo: Need to implement with OpenCL
            return base.Sigmoid(x);
        }

        public override SuperArray Sign(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_sign", x.ElementType), x);
        }

        public override SuperArray Sqrt(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_sqrt", x.ElementType), x);
        }

        public override SuperArray Square(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_square", x.ElementType), x);
        }

        public override SuperArray Sum(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Sum(x, dimension);
        }

        public override SuperArray TPow(float value, SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_tpow", x.ElementType), new object[] { value, x });
        }

        public override SuperArray Trunc(SuperArray x)
        {
            return ExecuteReturn(GetFuncName("ndarr_trunc", x.ElementType), x);
        }
    }
}
