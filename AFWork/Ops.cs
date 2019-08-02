using SiaNet.Backend.ArrayFire;
using SiaNet.Backend.ArrayFire.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace AFWork
{
    public class Ops
    {
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
        public static SuperArray Clamp(SuperArray arr, SuperArray lo, SuperArray hi) { IntPtr ptr; Internal.VERIFY(AFArith.af_clamp(out ptr, arr.variable._ptr, lo.variable._ptr, hi.variable._ptr, false)); return new SuperArray(new AFArray(ptr)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray Neg(SuperArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_neg(out ptr, arr.variable._ptr)); return new SuperArray(new AFArray(ptr)); }
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
        public static SuperArray Sum(SuperArray arr, int dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);

            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_sum(out ptr, y._ptr, dim));
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
        public static SuperArray Prod(SuperArray arr, int dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_product(out ptr, y._ptr, dim));
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
        public static SuperArray Max(SuperArray arr, int dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_max(out ptr, y._ptr, dim));
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
        public static SuperArray Min(SuperArray arr, int dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFAlgorithm.af_min(out ptr, y._ptr, dim));
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
        public static SuperArray Mean(SuperArray arr, int dim)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFStatistics.af_mean(out ptr, y._ptr, dim));
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
        public static SuperArray StdDev(SuperArray arr, int dim)
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
        public static SuperArray Var(SuperArray arr, int dim, bool isbiased = false)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            Internal.VERIFY(AFStatistics.af_var(out ptr, y._ptr, isbiased, dim));
            return new SuperArray(new AFArray(ptr));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuperArray TopK(SuperArray arr, int k, int dim, int order)
        {
            AFArray y = CreateMajorSupportedArray(arr);
            IntPtr ptr;
            IntPtr idx;
            Internal.VERIFY(AFStatistics.af_topk(out ptr, out idx, y._ptr, k, dim, order));
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

        private static AFArray CreateMajorSupportedArray(SuperArray arr, bool withTranspose = true)
        {
            AFArray y = null;

            if (!Global.IsColumnMajor)
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
