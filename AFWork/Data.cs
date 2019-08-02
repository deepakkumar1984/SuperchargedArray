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

using SiaNet.Backend.ArrayFire.Interop;

namespace SiaNet.Backend.ArrayFire
{
	public static class Data
	{

		#region Create array from host data
#if _
    for (\w+)=(\w+) in
        b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte s16=short u16=ushort
    do
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array CreateArray($2[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.$1)); return new Array(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array CreateArray($2[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.$1)); return new Array(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array CreateArray($2[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.$1)); return new Array(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Array CreateArray($2[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.$1)); return new Array(ptr); }
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(bool[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Boolean)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(bool[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Boolean)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(bool[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Boolean)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(bool[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Boolean)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(Complex[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Complex64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(Complex[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Complex64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(Complex[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Complex64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(Complex[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Complex64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(float[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Float32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(float[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Float32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(float[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Float32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(float[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Float32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(double[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Float64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(double[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Float64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(double[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Float64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(double[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Float64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(int[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Int32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(int[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Int32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(int[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Int32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(int[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Int32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(long[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Int64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(long[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Int64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(long[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Int64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(long[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Int64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(uint[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.UInt32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(uint[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.UInt32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(uint[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.UInt32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(uint[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.UInt32)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ulong[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.UInt64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ulong[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.UInt64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ulong[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.UInt64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ulong[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.UInt64)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(byte[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Byte)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(byte[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Byte)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(byte[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Byte)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(byte[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Byte)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(short[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.Int16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(short[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.Int16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(short[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.Int16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(short[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.Int16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ushort[] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.Length }, DataType.UInt16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ushort[,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1) }, DataType.UInt16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ushort[,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2) }, DataType.UInt16)); return new AFArray(ptr); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray CreateArray(ushort[,,,] data) { IntPtr ptr; Internal.VERIFY(AFArray.af_create_array(out ptr, data, (uint)data.Rank, new long[] { data.GetLength(0), data.GetLength(1), data.GetLength(2), data.GetLength(3) }, DataType.UInt16)); return new AFArray(ptr); }
#endif
        #endregion

        #region Write array from host data
#if _
    for (\w+)=(\w+) in
        b8=bool c64=Complex f32=float f64=double s32=int s64=long u32=uint u64=ulong u8=byte s16=short u16=ushort
    do
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(Array arr, $2[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(Array arr, $2[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(Array arr, $2[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(Array arr, $2[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, bool[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, bool[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, bool[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, bool[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, Complex[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, Complex[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, Complex[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, Complex[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, float[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, float[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, float[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, float[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, double[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, double[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, double[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, double[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, int[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, int[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, int[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, int[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, long[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, long[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, long[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, long[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, uint[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, uint[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, uint[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, uint[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ulong[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ulong[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ulong[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ulong[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, byte[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, byte[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, byte[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, byte[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, short[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, short[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, short[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, short[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ushort[] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ushort[,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ushort[,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(AFArray arr, ushort[,,,] data) { Internal.VERIFY(AFArray.af_write_array(arr._ptr, data, Internal.sizeOfArray(data), af_source.afHost)); }
#endif
		#endregion

		#region Random Arrays
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray RandUniform<T>(params int[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_randu(out ptr, (uint)dims.Length, Internal.toLongArray(dims), Internal.toDType<T>()));
			return new AFArray(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray RandNormal<T>(params int[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_randn(out ptr, (uint)dims.Length, Internal.toLongArray(dims), Internal.toDType<T>()));
			return new AFArray(ptr);
		}

		public static ulong RandSeed
		{
			get { ulong value; Internal.VERIFY(AFData.af_get_seed(out value)); return value; }
			set { Internal.VERIFY(AFData.af_set_seed(value)); }
		}
		#endregion

		#region Constant, Iota, Range, Identity
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Constant<T>(T value, params int[] dims)
		{
			IntPtr ptr;
			object boxval = value;
			DataType dtype = Internal.toDType<T>();
			switch (dtype)
			{
				case DataType.UInt64:
					Internal.VERIFY(AFData.af_constant_ulong(out ptr, (ulong)boxval, (uint)dims.Length, Internal.toLongArray(dims)));
					break;
				case DataType.Int64:
					Internal.VERIFY(AFData.af_constant_long(out ptr, (long)boxval, (uint)dims.Length, Internal.toLongArray(dims)));
					break;
				case DataType.Complex64:
					Complex z = (Complex)boxval;
					Internal.VERIFY(AFData.af_constant_complex(out ptr, z.Real, z.Imaginary, (uint)dims.Length, Internal.toLongArray(dims), dtype));
					break;
				default:
					Internal.VERIFY(AFData.af_constant(out ptr, (double)Convert.ChangeType(boxval, typeof(double)), (uint)dims.Length, Internal.toLongArray(dims), dtype));
					break;
			}
			return new AFArray(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Iota<T>(int[] dims, int[] tiles)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_iota(out ptr, (uint)dims.Length, Internal.toLongArray(dims), (uint)tiles.Length, Internal.toLongArray(tiles), Internal.toDType<T>()));
			return new AFArray(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Iota<T>(params int[] dims)
		{
			return Iota<T>(dims, new int[] { 1 });
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray RangeAlong<T>(int seq_dim, params int[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_range(out ptr, (uint)dims.Length, Internal.toLongArray(dims), seq_dim, Internal.toDType<T>()));
			return new AFArray(ptr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Range<T>(params int[] dims)
		{
			return RangeAlong<T>(-1, dims); // -1 is the default according to af_range's documentation
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Identity<T>(params int[] dims)
		{
			IntPtr ptr;
			Internal.VERIFY(AFData.af_identity(out ptr, (uint)dims.Length, Internal.toLongArray(dims), Internal.toDType<T>()));
			return new AFArray(ptr);
		}
		#endregion

		#region Complex Arrays from real data
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray CreateComplexArray(AFArray real, AFArray imag = null)
		{
			IntPtr ptr;
			if (imag != null) Internal.VERIFY(AFArith.af_cplx2(out ptr, real._ptr, imag._ptr, false));
			else Internal.VERIFY(AFArith.af_cplx(out ptr, real._ptr));
			return new AFArray(ptr);
		}
		#endregion

		#region Get the array inner data
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] GetData<T>(AFArray arr) // not called GetData1D because it works for arrays of any dimensionality
		{
			T[] data = new T[arr.ElemCount];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] GetData2D<T>(AFArray arr) // only works for 2D arrays
		{
			int[] dims = arr.Dimensions;
			if (dims.Length > 2) throw new NotSupportedException("This array has more than two dimensions");
			T[,] data;
			if (dims.Length == 1) // column vector
				data = new T[dims[0], 1];
			else
				data = new T[dims[0], dims[1]];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,] GetData3D<T>(AFArray arr) // only works for 3D arrays
		{
			int[] dims = arr.Dimensions;
			if (dims.Length > 3) throw new NotSupportedException("This array has more than three dimensions");
			T[,,] data;
			if (dims.Length == 1)
				data = new T[dims[0], 1, 1];
			else if (dims.Length == 2)
				data = new T[dims[0], dims[1], 1];
			else
				data = new T[dims[0], dims[1], dims[2]];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,,] GetData4D<T>(AFArray arr)
		{
			int[] dims = arr.Dimensions;
			if (dims.Length > 4) throw new NotSupportedException("This array has more than four dimensions");
			T[,,,] data;
			if (dims.Length == 1)
				data = new T[dims[0], 1, 1, 1];
			else if (dims.Length == 2)
				data = new T[dims[0], dims[1], 1, 1];
			else if (dims.Length == 3)
				data = new T[dims[0], dims[1], dims[2], 1];
			else
				data = new T[dims[0], dims[1], dims[2], dims[3]];
			Internal.VERIFY(Internal.getData<T>(data, arr._ptr));
			return data;
		}
		#endregion

		#region Casting
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Cast<X>(AFArray arr)
		{
			IntPtr ptr;
			Internal.VERIFY(AFArith.af_cast(out ptr, arr._ptr, Internal.toDType<X>()));
			return new AFArray(ptr);
		}
        #endregion

        #region Copying
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Copy(AFArray arr)
        {
            IntPtr ptr;
            Internal.VERIFY(AFArray.af_copy_array(out ptr, arr._ptr));
            return new AFArray(ptr);
        }
        #endregion

        #region Move Reorder
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Flat(AFArray arr)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_flat(out ptr, arr._ptr));
            return new AFArray(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Flip(AFArray arr, uint dim)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_flip(out ptr, arr._ptr, dim));
            return new AFArray(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Join(AFArray first, AFArray second, int dim)
        {
            IntPtr ptr;
            Internal.VERIFY(AFData.af_join(out ptr, dim, first._ptr, second._ptr));
            return new AFArray(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Join(AFArray[] list, int dim)
        {
            IntPtr ptr;
            IntPtr[] listPtr = new IntPtr[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                listPtr[i] = list[i]._ptr;
            }

            Internal.VERIFY(AFData.af_join_many(out ptr, dim, (uint)list.Length, listPtr));
            return new AFArray(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Reorder(AFArray arr, params uint[] dims)
        {
            IntPtr ptr;
            if (dims.Length < 2)
                throw new ArgumentException("Specify at least 2 axis");

            uint z = dims.Length >= 3 ? dims[2] : 1;
            uint w = dims.Length >= 4 ? dims[3] : 1;
            Internal.VERIFY(AFData.af_reorder(out ptr, arr._ptr, dims[0], dims[1], z, w));
            return new AFArray(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray ModDims(AFArray arr, params long[] dims)
        {
            IntPtr ptr;

            Internal.VERIFY(AFData.af_moddims(out ptr, arr._ptr, (uint)dims.Length, dims));
            return new AFArray(ptr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Tile(AFArray arr, params uint[] dims)
        {
            IntPtr ptr;
            if (dims.Length < 1)
                throw new ArgumentException("Specify at least 1 axis");

            uint y = dims.Length >= 2 ? dims[1] : 1;
            uint z = dims.Length >= 3 ? dims[2] : 1;
            uint w = dims.Length >= 4 ? dims[3] : 1;

            Internal.VERIFY(AFData.af_tile(out ptr, arr._ptr, dims[0], y, z, w));
            return new AFArray(ptr);
        }
        #endregion
    }
}
