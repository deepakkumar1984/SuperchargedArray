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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using SuperchargedArray.Backend.Interop;

namespace SuperchargedArray.Backend
{
    internal static class Internal // shared functionality
	{
		private static Dictionary<DataType, Type> dtype2clr;
		private static Dictionary<Type, DataType> clr2dtype;
		private static Dictionary<Type, Func<System.Array, IntPtr, af_err>>[] getdatafn;

		static Internal()
		{
			clr2dtype = new Dictionary<Type, DataType>();
			dtype2clr = new Dictionary<DataType, Type>();
			getdatafn = new Dictionary<Type, Func<System.Array, IntPtr, af_err>>[4];
			for(int i = 0; i < getdatafn.Length; ++i) getdatafn[i] = new Dictionary<Type, Func<System.Array, IntPtr, af_err>>();

#if _
	for (\w+)=(\w+) in
			b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte s16=short u16=ushort
	do
			dtype2clr.Add(af_dtype.$1, typeof($2));
			clr2dtype.Add(typeof($2), af_dtype.$1);
			getdatafn[0].Add(typeof($2), (data, ptr) => AFArray.af_get_data_ptr(($2[])data, ptr));
			getdatafn[1].Add(typeof($2), (data, ptr) => AFArray.af_get_data_ptr(($2[,])data, ptr));
			getdatafn[2].Add(typeof($2), (data, ptr) => AFArray.af_get_data_ptr(($2[,,])data, ptr));
			getdatafn[3].Add(typeof($2), (data, ptr) => AFArray.af_get_data_ptr(($2[,,,])data, ptr));
#else
			dtype2clr.Add(DataType.Boolean, typeof(bool));
			clr2dtype.Add(typeof(bool), DataType.Boolean);
			getdatafn[0].Add(typeof(bool), (data, ptr) => AFArray.af_get_data_ptr((bool[])data, ptr));
			getdatafn[1].Add(typeof(bool), (data, ptr) => AFArray.af_get_data_ptr((bool[,])data, ptr));
			getdatafn[2].Add(typeof(bool), (data, ptr) => AFArray.af_get_data_ptr((bool[,,])data, ptr));
			getdatafn[3].Add(typeof(bool), (data, ptr) => AFArray.af_get_data_ptr((bool[,,,])data, ptr));

			dtype2clr.Add(DataType.Complex64, typeof(Complex));
			clr2dtype.Add(typeof(Complex), DataType.Complex64);
			getdatafn[0].Add(typeof(Complex), (data, ptr) => AFArray.af_get_data_ptr((Complex[])data, ptr));
			getdatafn[1].Add(typeof(Complex), (data, ptr) => AFArray.af_get_data_ptr((Complex[,])data, ptr));
			getdatafn[2].Add(typeof(Complex), (data, ptr) => AFArray.af_get_data_ptr((Complex[,,])data, ptr));
			getdatafn[3].Add(typeof(Complex), (data, ptr) => AFArray.af_get_data_ptr((Complex[,,,])data, ptr));

			dtype2clr.Add(DataType.Float32, typeof(float));
			clr2dtype.Add(typeof(float), DataType.Float32);
			getdatafn[0].Add(typeof(float), (data, ptr) => AFArray.af_get_data_ptr((float[])data, ptr));
			getdatafn[1].Add(typeof(float), (data, ptr) => AFArray.af_get_data_ptr((float[,])data, ptr));
			getdatafn[2].Add(typeof(float), (data, ptr) => AFArray.af_get_data_ptr((float[,,])data, ptr));
			getdatafn[3].Add(typeof(float), (data, ptr) => AFArray.af_get_data_ptr((float[,,,])data, ptr));

			dtype2clr.Add(DataType.Float64, typeof(double));
			clr2dtype.Add(typeof(double), DataType.Float64);
			getdatafn[0].Add(typeof(double), (data, ptr) => AFArray.af_get_data_ptr((double[])data, ptr));
			getdatafn[1].Add(typeof(double), (data, ptr) => AFArray.af_get_data_ptr((double[,])data, ptr));
			getdatafn[2].Add(typeof(double), (data, ptr) => AFArray.af_get_data_ptr((double[,,])data, ptr));
			getdatafn[3].Add(typeof(double), (data, ptr) => AFArray.af_get_data_ptr((double[,,,])data, ptr));

			dtype2clr.Add(DataType.Int32, typeof(int));
			clr2dtype.Add(typeof(int), DataType.Int32);
			getdatafn[0].Add(typeof(int), (data, ptr) => AFArray.af_get_data_ptr((int[])data, ptr));
			getdatafn[1].Add(typeof(int), (data, ptr) => AFArray.af_get_data_ptr((int[,])data, ptr));
			getdatafn[2].Add(typeof(int), (data, ptr) => AFArray.af_get_data_ptr((int[,,])data, ptr));
			getdatafn[3].Add(typeof(int), (data, ptr) => AFArray.af_get_data_ptr((int[,,,])data, ptr));

			dtype2clr.Add(DataType.Int64, typeof(long));
			clr2dtype.Add(typeof(long), DataType.Int64);
			getdatafn[0].Add(typeof(long), (data, ptr) => AFArray.af_get_data_ptr((long[])data, ptr));
			getdatafn[1].Add(typeof(long), (data, ptr) => AFArray.af_get_data_ptr((long[,])data, ptr));
			getdatafn[2].Add(typeof(long), (data, ptr) => AFArray.af_get_data_ptr((long[,,])data, ptr));
			getdatafn[3].Add(typeof(long), (data, ptr) => AFArray.af_get_data_ptr((long[,,,])data, ptr));

			dtype2clr.Add(DataType.UInt32, typeof(uint));
			clr2dtype.Add(typeof(uint), DataType.UInt32);
			getdatafn[0].Add(typeof(uint), (data, ptr) => AFArray.af_get_data_ptr((uint[])data, ptr));
			getdatafn[1].Add(typeof(uint), (data, ptr) => AFArray.af_get_data_ptr((uint[,])data, ptr));
			getdatafn[2].Add(typeof(uint), (data, ptr) => AFArray.af_get_data_ptr((uint[,,])data, ptr));
			getdatafn[3].Add(typeof(uint), (data, ptr) => AFArray.af_get_data_ptr((uint[,,,])data, ptr));

			dtype2clr.Add(DataType.UInt64, typeof(ulong));
			clr2dtype.Add(typeof(ulong), DataType.UInt64);
			getdatafn[0].Add(typeof(ulong), (data, ptr) => AFArray.af_get_data_ptr((ulong[])data, ptr));
			getdatafn[1].Add(typeof(ulong), (data, ptr) => AFArray.af_get_data_ptr((ulong[,])data, ptr));
			getdatafn[2].Add(typeof(ulong), (data, ptr) => AFArray.af_get_data_ptr((ulong[,,])data, ptr));
			getdatafn[3].Add(typeof(ulong), (data, ptr) => AFArray.af_get_data_ptr((ulong[,,,])data, ptr));

			dtype2clr.Add(DataType.Byte, typeof(byte));
			clr2dtype.Add(typeof(byte), DataType.Byte);
			getdatafn[0].Add(typeof(byte), (data, ptr) => AFArray.af_get_data_ptr((byte[])data, ptr));
			getdatafn[1].Add(typeof(byte), (data, ptr) => AFArray.af_get_data_ptr((byte[,])data, ptr));
			getdatafn[2].Add(typeof(byte), (data, ptr) => AFArray.af_get_data_ptr((byte[,,])data, ptr));
			getdatafn[3].Add(typeof(byte), (data, ptr) => AFArray.af_get_data_ptr((byte[,,,])data, ptr));

			dtype2clr.Add(DataType.Int16, typeof(short));
			clr2dtype.Add(typeof(short), DataType.Int16);
			getdatafn[0].Add(typeof(short), (data, ptr) => AFArray.af_get_data_ptr((short[])data, ptr));
			getdatafn[1].Add(typeof(short), (data, ptr) => AFArray.af_get_data_ptr((short[,])data, ptr));
			getdatafn[2].Add(typeof(short), (data, ptr) => AFArray.af_get_data_ptr((short[,,])data, ptr));
			getdatafn[3].Add(typeof(short), (data, ptr) => AFArray.af_get_data_ptr((short[,,,])data, ptr));

			dtype2clr.Add(DataType.UInt16, typeof(ushort));
			clr2dtype.Add(typeof(ushort), DataType.UInt16);
			getdatafn[0].Add(typeof(ushort), (data, ptr) => AFArray.af_get_data_ptr((ushort[])data, ptr));
			getdatafn[1].Add(typeof(ushort), (data, ptr) => AFArray.af_get_data_ptr((ushort[,])data, ptr));
			getdatafn[2].Add(typeof(ushort), (data, ptr) => AFArray.af_get_data_ptr((ushort[,,])data, ptr));
			getdatafn[3].Add(typeof(ushort), (data, ptr) => AFArray.af_get_data_ptr((ushort[,,,])data, ptr));
#endif
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static DataType toDType<T>() { return clr2dtype[typeof(T)]; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static Type toClrType(DataType dtype) { return dtype2clr[dtype]; }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static af_err getData<T>(System.Array arr, IntPtr ptr)
		{
            // lookup time was experimentally found to be negligible (less than 1%)
            // compared to the time the actual operation takes, even for small arrays
			return getdatafn[arr.Rank - 1][typeof(T)](arr, ptr);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long[] toLongArray(int[] intarr)
        {
            return System.Array.ConvertAll(intarr, x => (long)x);
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void VERIFY(af_err err)
		{
			if (err != af_err.AF_SUCCESS) throw new ArrayFireException(err);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UIntPtr sizeOfArray(System.Array arr)
        {
            return (UIntPtr)(Marshal.SizeOf(arr.GetType().GetElementType()) * arr.Length);
        }
    }
}
