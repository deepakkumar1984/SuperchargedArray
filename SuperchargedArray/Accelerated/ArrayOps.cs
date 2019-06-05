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
namespace SuperchargedArray.Accelerated
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

        public override void Fill(SuperArray x, float value)
        {
            Accelerator.Execute(GetFuncName("ndarr_fill", x.ElementType), new object[] { x, value }, null, 0);
        }

        public override SuperArray Abs(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_abs", x.ElementType), new object[] { x });
        }

        public override SuperArray Sin(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sin", x.ElementType), new object[] { x });
        }

        public override SuperArray Cos(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_cos", x.ElementType), new object[] { x });
        }

        public override SuperArray Tan(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_tan", x.ElementType), new object[] { x });
        }

        public override SuperArray Sinh(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sinh", x.ElementType), new object[] { x });
        }

        public override SuperArray Cosh(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_cosh", x.ElementType), new object[] { x });
        }

        public override SuperArray Tanh(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_tanh", x.ElementType), new object[] { x });
        }

        public override SuperArray Asin(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arcsin", x.ElementType), new object[] { x });
        }

        public override SuperArray Acos(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arccos", x.ElementType), new object[] { x });
        }

        public override SuperArray Atan(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arctan", x.ElementType), new object[] { x });
        }

        public override SuperArray Atan2(SuperArray y, SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arctan2", x.ElementType), new object[] { x, y });
        }

        public override SuperArray Add(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_add", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override SuperArray Add(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_add", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray Add(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_add", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray Sub(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_sub", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override SuperArray Sub(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_sub", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray Sub(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sub", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray Mul(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_mul", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override SuperArray Mul(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_mul", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray Mul(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_mul", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray Div(float lhs, SuperArray rhs)
        {
            SuperArray lhs_arr = new SuperArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_div", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override SuperArray Div(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_div", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray Div(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_div", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray GreaterThan(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_gt", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray GreaterThan(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_gt", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray GreaterOrEqual(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_ge", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray GreaterOrEqual(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_ge", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray LessThan(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_lt", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray LessThan(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_lt", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray LessOrEqual(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_le", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray LessOrEqual(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_le", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray EqualTo(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_eq", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray EqualTo(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_eq", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray NotEqual(SuperArray lhs, float rhs)
        {
            SuperArray rhs_arr = new SuperArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_ne", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override SuperArray NotEqual(SuperArray lhs, SuperArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_ne", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray Ceil(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_ceil", x.ElementType), new object[] { x });
        }

        public override SuperArray Clip(SuperArray x, float min, float max)
        {
            return Accelerator.Execute(GetFuncName("ndarr_clip", x.ElementType), new object[] { x, min, max });
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
            return Accelerator.Execute(GetFuncName("ndarr_exp", x.ElementType), new object[] { x });
        }

        public override SuperArray Floor(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_floor", x.ElementType), new object[] { x });
        }

        public override SuperArray Frac(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_frac", x.ElementType), new object[] { x });
        }

        public override SuperArray Lerp(SuperArray x0, SuperArray x1, float weight)
        {
            //ToDo: Need to implement with OpenCL
            return base.Lerp(x0, x1, weight);
        }

        public override SuperArray Log(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_log", x.ElementType), new object[] { x });
        }

        public override SuperArray Log10(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_log10", x.ElementType), new object[] { x });
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
            return Accelerator.Execute(GetFuncName("ndarr_mod", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override SuperArray Mod(SuperArray x, float scalar)
        {
            SuperArray rhs_arr = new SuperArray(x.Shape);
            rhs_arr.Fill(scalar);
            return Accelerator.Execute(GetFuncName("ndarr_mod", x.ElementType), new object[] { x, rhs_arr });
        }

        public override SuperArray Neg(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_neg", x.ElementType), new object[] { x });
        }

        public override SuperArray Pow(SuperArray x, float value)
        {
            return Accelerator.Execute(GetFuncName("ndarr_pow", x.ElementType), new object[] { x, value });
        }

        public override SuperArray Prod(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Prod(x, dimension);
        }

        public override SuperArray Round(SuperArray x, int decimals = 0)
        {
            return Accelerator.Execute(GetFuncName("ndarr_round", x.ElementType), new object[] { x });
        }

        public override SuperArray Sigmoid(SuperArray x)
        {
            //ToDo: Need to implement with OpenCL
            return base.Sigmoid(x);
        }

        public override SuperArray Sign(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sign", x.ElementType), new object[] { x });
        }

        public override SuperArray Sqrt(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sqrt", x.ElementType), new object[] { x });
        }

        public override SuperArray Square(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_square", x.ElementType), new object[] { x });
        }

        public override SuperArray Sum(SuperArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Sum(x, dimension);
        }

        public override SuperArray TPow(float value, SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_tpow", x.ElementType), new object[] { value, x });
        }

        public override SuperArray Trunc(SuperArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_trunc", x.ElementType), new object[] { x });
        }
    }
}
