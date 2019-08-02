using SuperchargedArray;
using SuperchargedArray.Backend;
using SuperchargedArray.Backend.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace SuperchargedArray
{
    public class Ops
    {
        public static float EPSILON = 1e-7f;

        #region Math
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Arg(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_arg(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sin(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sin(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sign(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sign(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sinh(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sinh(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Asin(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_asin(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Asinh(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_asinh(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Cos(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cos(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Cosh(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cosh(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Acos(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_acos(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Acosh(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_acosh(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Tan(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tan(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Tanh(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tanh(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Atan(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_atan(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Atanh(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_atanh(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Exp(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_exp(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Expm1(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_expm1(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Log(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Log10(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log10(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Log1p(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log1p(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Log2(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log2(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Erf(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_erf(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Erfc(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_erfc(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sqrt(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sqrt(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Square(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_pow2(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Pow<T>(SuperArray arr, T value) { IntPtr ptr; Internal.VERIFY(AFArith.af_pow(out ptr, arr.variable._ptr, Data.Constant<T>(value, arr.variable.Dimensions)._ptr, false)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Cbrt(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cbrt(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray LGamma(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_lgamma(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray TGamma(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tgamma(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Abs(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_abs(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sigmoid(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sigmoid(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Factorial(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_factorial(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Round(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_round(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Trunc(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_trunc(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Floor(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_floor(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Ceil(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_ceil(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Clip<T>(SuperArray arr, T lo, T hi) where T: struct
        {
            IntPtr ptr;
            Internal.VERIFY(AFArith.af_clamp(out ptr, arr.variable._ptr, Data.Constant<T>(lo, arr.variable.Dimensions)._ptr, Data.Constant<T>(hi, arr.variable.Dimensions)._ptr, false));
            return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Neg(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_neg(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }

        public static SuperArray Maximum(SuperArray a, SuperArray b)
        {
            return Arith.MaxOf(a.variable, b.variable);
        }

        public static SuperArray Maximum<T>(SuperArray a, T b)
        {
            return Maximum(a, Constant<T>(b, a.Shape));
        }

        public static SuperArray Minimum(SuperArray a, SuperArray b)
        {
            return Arith.MinOf(a.variable, b.variable);
        }

        public static SuperArray Minimum<T>(SuperArray a, T b)
        {
            return Maximum(a, Constant<T>(b, a.Shape));
        }

        public static SuperArray Dot(SuperArray a, SuperArray b)
        {
            return Matrix.Multiply(a.variable, b.variable);
        }
        #endregion

        #region Algorithm
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Sum(SuperArray arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_sum_all(out r, out i, arr.variable._ptr));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sum(SuperArray arr, uint dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_sum(out ptr, y._ptr, (int)dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Sum(SuperArray arr, uint[] dims)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr = IntPtr.Zero;
            foreach (int dim in dims)
            {
                Internal.VERIFY(AFAlgorithm.af_sum(out ptr, y._ptr, dim));
                y._ptr = ptr;
            }
            
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Prod(SuperArray arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_product_all(out r, out i, arr.variable._ptr));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Prod(SuperArray arr, uint dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_product(out ptr, y._ptr, (int)dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Prod(SuperArray arr, uint[] dims)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr = IntPtr.Zero;
            foreach (var dim in dims)
            {
                Internal.VERIFY(AFAlgorithm.af_product(out ptr, y._ptr, (int)dim));
                y._ptr = ptr;
            }

            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Max(SuperArray arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_max_all(out r, out i, arr.variable._ptr));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Max(SuperArray arr, uint dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_max(out ptr, y._ptr, (int)dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Max(SuperArray arr, uint[] dims)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr = IntPtr.Zero;
            foreach (int dim in dims)
            {
                Internal.VERIFY(AFAlgorithm.af_max(out ptr, y._ptr, dim));
                y._ptr = ptr;
            }

            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Min(SuperArray arr)
        {
            double r, i;
            Internal.VERIFY(AFAlgorithm.af_min_all(out r, out i, arr.variable._ptr));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Min(SuperArray arr, uint dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_min(out ptr, y._ptr, (int)dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Min(SuperArray arr, uint[] dims)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr = IntPtr.Zero;
            foreach (int dim in dims)
            {
                Internal.VERIFY(AFAlgorithm.af_min(out ptr, y._ptr, dim));
                y._ptr = ptr;
            }

            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Mean(SuperArray arr)
        {
            double r, i;
            Internal.VERIFY(AFStatistics.af_mean_all(out r, out i, arr.variable._ptr));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Mean(SuperArray arr, uint dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFStatistics.af_mean(out ptr, y._ptr, dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Mean(SuperArray arr, uint[] dims)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr = IntPtr.Zero;
            foreach (var dim in dims)
            {
                Internal.VERIFY(AFStatistics.af_mean(out ptr, y._ptr, dim));
                y._ptr = ptr;
            }

            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double StdDev(SuperArray arr)
        {
            double r, i;
            Internal.VERIFY(AFStatistics.af_stdev_all(out r, out i, arr.variable._ptr));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray StdDev(SuperArray arr, uint dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFStatistics.af_stdev(out ptr, y._ptr, dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Var(SuperArray arr, bool isbiased = false)
        {
            double r, i;
            Internal.VERIFY(AFStatistics.af_var_all(out r, out i, arr.variable._ptr, isbiased));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Var(SuperArray arr, uint dim, bool isbiased = false)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFStatistics.af_var(out ptr, y._ptr, isbiased, dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray TopK(SuperArray arr, int k, uint dim, int order)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            IntPtr idx;
            Internal.VERIFY(AFStatistics.af_topk(out ptr, out idx, y._ptr, k, (int)dim, order));
            return new SuperArray(new AFArray(idx));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray ArgMax(SuperArray arr)
        {
            AFArray y = CreateMajorSupportedArray(arr, false);
            IntPtr ptr;
            IntPtr idx;
            Internal.VERIFY(AFStatistics.af_topk(out ptr, out idx, y._ptr, 1, 0, 2));
            return new SuperArray(new AFArray(idx));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray ArgMin(SuperArray arr)
        {
            AFArray y = CreateMajorSupportedArray(arr, false);
            IntPtr ptr;
            IntPtr idx;
            Internal.VERIFY(AFStatistics.af_topk(out ptr, out idx, y._ptr, 1, 0, 1));
            return new SuperArray(new AFArray(idx));
        }
        #endregion

        #region Misc
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Diag(SuperArray arr)
        {
            return Data.Diag(arr.variable);
        }

        public static SuperArray Constant<T>(T value, Shape shape)
        {
            return Data.Constant<T>(value, shape.Dims);
        }

        public static SuperArray Tile(SuperArray x, int nTimes, int axis = 0)
        {
            uint[] dims = new uint[x.Shape.Length];

            for (int i = 0; i < dims.Length; i++)
            {
                if (i == axis)
                {
                    dims[i] = (uint)nTimes;
                    continue;
                }

                dims[i] = 1;
            }

            return Data.Tile(x.variable, dims);
        }

        #endregion

        #region Comparision
        public static SuperArray GreaterThan(SuperArray a, SuperArray b)
        {
            return a > b;
        }

        public static SuperArray GreaterThanEqual(SuperArray a, SuperArray b)
        {
            return a >= b;
        }

        public static SuperArray LessThan(SuperArray a, SuperArray b)
        {
            return a < b;
        }

        public static SuperArray LessThanEqual(SuperArray a, SuperArray b)
        {
            return a <= b;
        }

        public static SuperArray GreaterThan(float a, SuperArray b)
        {
            return a > b;
        }

        public static SuperArray GreaterThanEqual(float a, SuperArray b)
        {
            return a >= b;
        }

        public static SuperArray LessThan(float a, SuperArray b)
        {
            return a < b;
        }

        public static SuperArray LessThanEqual(float a, SuperArray b)
        {
            return a <= b;
        }

        public static SuperArray GreaterThan(SuperArray a, float b)
        {
            return a > b;
        }

        public static SuperArray GreaterThanEqual(SuperArray a, float b)
        {
            return a >= b;
        }

        public static SuperArray LessThan(SuperArray a, float b)
        {
            return a < b;
        }

        public static SuperArray LessThanEqual(SuperArray a, float b)
        {
            return a <= b;
        }

        public static SuperArray EqualTo(SuperArray a, SuperArray b)
        {
            return Arith.EqualTo(a.variable,b.variable);
        }
        #endregion

        private static AFArray CreateMajorSupportedArray(SuperArray arr, bool withTranspose = true)
        {
            AFArray y = null;

            if (!Device.IsColumnMajor)
            {
                y = Data.ModDims(arr.variable, arr.variable.Dimensions.Select(i => (long)i).Reverse().ToArray());
                if(withTranspose)
                    y = Matrix.Transpose(y, false);
            }
            else
            {
                y = arr.variable;
            }

            return y;
        }
    }
}
