using System;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension.Accelerated
{
    public class ArrayOps : ArrayExtension.ArrayOps
    {
        private string GetFuncName(string name, DType dType)
        {
            if (dType == DType.Single)
                return string.Format("{0}_float", name);
            else if (dType == DType.Double)
                return string.Format("{0}_double", name);

            return name;
        }

        public override void Fill(NDArray x, float value)
        {
            Accelerator.Execute(GetFuncName("ndarr_fill", x.ElementType), new object[] { x, value }, null, 0);
        }

        public override NDArray Abs(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_abs", x.ElementType), new object[] { x });
        }

        public override NDArray Sin(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sin", x.ElementType), new object[] { x });
        }

        public override NDArray Cos(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_cos", x.ElementType), new object[] { x });
        }

        public override NDArray Tan(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_tan", x.ElementType), new object[] { x });
        }

        public override NDArray Sinh(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sinh", x.ElementType), new object[] { x });
        }

        public override NDArray Cosh(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_cosh", x.ElementType), new object[] { x });
        }

        public override NDArray Tanh(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_tanh", x.ElementType), new object[] { x });
        }

        public override NDArray Asin(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arcsin", x.ElementType), new object[] { x });
        }

        public override NDArray Acos(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arccos", x.ElementType), new object[] { x });
        }

        public override NDArray Atan(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arctan", x.ElementType), new object[] { x });
        }

        public override NDArray Atan2(NDArray y, NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_arctan2", x.ElementType), new object[] { x, y });
        }

        public override NDArray Add(float lhs, NDArray rhs)
        {
            NDArray lhs_arr = new NDArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_add", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override NDArray Add(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_add", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray Add(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_add", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray Sub(float lhs, NDArray rhs)
        {
            NDArray lhs_arr = new NDArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_sub", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override NDArray Sub(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_sub", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray Sub(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sub", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray Mul(float lhs, NDArray rhs)
        {
            NDArray lhs_arr = new NDArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_mul", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override NDArray Mul(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_mul", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray Mul(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_mul", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray Div(float lhs, NDArray rhs)
        {
            NDArray lhs_arr = new NDArray(rhs.Shape);
            lhs_arr.Fill(lhs);

            return Accelerator.Execute(GetFuncName("ndarr_div", rhs.ElementType), new object[] { lhs_arr, rhs });
        }

        public override NDArray Div(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_div", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray Div(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_div", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray GreaterThan(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_gt", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray GreaterThan(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_gt", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray GreaterOrEqual(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_ge", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray GreaterOrEqual(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_ge", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray LessThan(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_lt", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray LessThan(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_lt", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray LessOrEqual(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_le", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray LessOrEqual(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_le", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray EqualTo(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_eq", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray EqualTo(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_eq", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray NotEqual(NDArray lhs, float rhs)
        {
            NDArray rhs_arr = new NDArray(lhs.Shape);
            rhs_arr.Fill(rhs);

            return Accelerator.Execute(GetFuncName("ndarr_ne", lhs.ElementType), new object[] { lhs, rhs_arr });
        }

        public override NDArray NotEqual(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_ne", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray Ceil(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_ceil", x.ElementType), new object[] { x });
        }

        public override NDArray Clip(NDArray x, float min, float max)
        {
            return Accelerator.Execute(GetFuncName("ndarr_clip", x.ElementType), new object[] { x, min, max });
        }

        public override NDArray Diag(NDArray x)
        {
            //ToDo: Need to implement with OpenCL
            return base.Diag(x);
        }

        public override NDArray Argmax(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Argmax(x, dimension);
        }

        public override NDArray Argmin(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Argmin(x, dimension);
        }

        public override NDArray Dot(NDArray a, NDArray b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Dot(a, b);
        }

        public override NDArray Exp(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_exp", x.ElementType), new object[] { x });
        }

        public override NDArray Floor(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_floor", x.ElementType), new object[] { x });
        }

        public override NDArray Frac(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_frac", x.ElementType), new object[] { x });
        }

        public override NDArray Lerp(NDArray x0, NDArray x1, float weight)
        {
            //ToDo: Need to implement with OpenCL
            return base.Lerp(x0, x1, weight);
        }

        public override NDArray Log(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_log", x.ElementType), new object[] { x });
        }

        public override NDArray Log10(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_log10", x.ElementType), new object[] { x });
        }

        public override NDArray Max(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Max(x, dimension);
        }

        public override NDArray Maximum(float a, NDArray b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Maximum(a, b);
        }

        public override NDArray Maximum(NDArray a, float b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Maximum(a, b);
        }

        public override NDArray Maximum(NDArray a, NDArray b)
        {
            //ToDo: Need to implement with OpenCL
            return base.Maximum(a, b);
        }

        public override NDArray Mean(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Mean(x, dimension);
        }

        public override NDArray Min(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Min(x, dimension);
        }

        public override NDArray Minus(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Minus(x, dimension);
        }

        public override NDArray Mod(NDArray lhs, NDArray rhs)
        {
            return Accelerator.Execute(GetFuncName("ndarr_mod", lhs.ElementType), new object[] { lhs, rhs });
        }

        public override NDArray Mod(NDArray x, float scalar)
        {
            NDArray rhs_arr = new NDArray(x.Shape);
            rhs_arr.Fill(scalar);
            return Accelerator.Execute(GetFuncName("ndarr_mod", x.ElementType), new object[] { x, rhs_arr });
        }

        public override NDArray Neg(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_neg", x.ElementType), new object[] { x });
        }

        public override NDArray Pow(NDArray x, float value)
        {
            return Accelerator.Execute(GetFuncName("ndarr_pow", x.ElementType), new object[] { x, value });
        }

        public override NDArray Prod(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Prod(x, dimension);
        }

        public override NDArray Round(NDArray x, int decimals = 0)
        {
            return Accelerator.Execute(GetFuncName("ndarr_round", x.ElementType), new object[] { x });
        }

        public override NDArray Sigmoid(NDArray x)
        {
            //ToDo: Need to implement with OpenCL
            return base.Sigmoid(x);
        }

        public override NDArray Sign(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sign", x.ElementType), new object[] { x });
        }

        public override NDArray Sqrt(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_sqrt", x.ElementType), new object[] { x });
        }

        public override NDArray Square(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_square", x.ElementType), new object[] { x });
        }

        public override NDArray Sum(NDArray x, int dimension)
        {
            //ToDo: Need to implement with OpenCL
            return base.Sum(x, dimension);
        }

        public override NDArray TPow(float value, NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_tpow", x.ElementType), new object[] { value, x });
        }

        public override NDArray Trunc(NDArray x)
        {
            return Accelerator.Execute(GetFuncName("ndarr_trunc", x.ElementType), new object[] { x });
        }
    }
}
