/*
Copyright (c) 2015, ArrayFire
Copyright (c) 2015, Steven Burns (royalstream@hotmail.com)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of arrayfire_dotnet nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

using SuperchargedArray.Backend.Interop;

namespace SuperchargedArray.Backend
{
    // we can't make Arith static because Array inherits from it (so the F# Core.Operators free functions work correctly)
    public /*static*/ class Arith
	{
		protected Arith() { }

        #region Mathematical Functions
#if _
	for (\w+) in
		Sin Sinh Asin Asinh
		Cos Cosh Acos Acosh
		Tan Tanh Atan Atanh
		Exp Expm1 Log Log10 Log1p Log2 Erf Erfc
		Sqrt Pow2 Cbrt
		LGamma TGamma
		Abs Sigmoid Factorial
		Round Trunc Floor Ceil
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array $1(Array arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_$L1(out ptr, arr._ptr)); return new Array(ptr); }
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Arg(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_arg(out ptr, arr._ptr)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Sin(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sin(out ptr, arr._ptr)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Sign(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sign(out ptr, arr._ptr)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Sinh(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sinh(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Asin(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_asin(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Asinh(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_asinh(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Cos(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cos(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Cosh(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cosh(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Acos(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_acos(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Acosh(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_acosh(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Tan(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tan(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Tanh(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tanh(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Atan(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_atan(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Atanh(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_atanh(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Exp(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_exp(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Expm1(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_expm1(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Log(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Log10(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log10(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Log1p(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log1p(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Log2(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_log2(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Erf(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_erf(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Erfc(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_erfc(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Sqrt(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sqrt(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Pow2(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_pow2(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Cbrt(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_cbrt(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray LGamma(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_lgamma(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray TGamma(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_tgamma(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Abs(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_abs(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Sigmoid(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_sigmoid(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Factorial(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_factorial(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Round(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_round(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Trunc(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_trunc(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Floor(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_floor(out ptr, arr._ptr)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Ceil(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_ceil(out ptr, arr._ptr)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Clamp(AFArray arr, AFArray lo, AFArray hi) { IntPtr ptr; Internal.VERIFY(AFArith.af_clamp(out ptr, arr._ptr, lo._ptr, hi._ptr, false)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Neg(AFArray arr) { IntPtr ptr; Internal.VERIFY(AFArith.af_neg(out ptr, arr._ptr)); return new AFArray(ptr); }
#if _
	for (\w+) in
		Atan2 Rem Pow
	do
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Array $1(Array lhs, Array rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_$L1(out ptr, lhs._ptr, rhs._ptr, false)); return new Array(ptr); }
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Atan2(AFArray lhs, AFArray rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_atan2(out ptr, lhs._ptr, rhs._ptr, false)); return new AFArray(ptr); }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Rem(AFArray lhs, AFArray rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_rem(out ptr, lhs._ptr, rhs._ptr, false)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray EqualTo(AFArray lhs, AFArray rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_eq(out ptr, lhs._ptr, rhs._ptr, false)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Pow(AFArray lhs, AFArray rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_pow(out ptr, lhs._ptr, rhs._ptr, false)); return new AFArray(ptr); }

        public static AFArray MaxOf(AFArray lhs, AFArray rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_maxof(out ptr, lhs._ptr, rhs._ptr, false)); return new AFArray(ptr); }

        public static AFArray MinOf(AFArray lhs, AFArray rhs) { IntPtr ptr; Internal.VERIFY(AFArith.af_minof(out ptr, lhs._ptr, rhs._ptr, false)); return new AFArray(ptr); }
        #endregion
    }
}
