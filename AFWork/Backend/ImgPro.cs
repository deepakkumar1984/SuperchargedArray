﻿/*
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
	public static class ImgPro
	{
		#region Wrap/Unwrap
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AFArray Unwrap(AFArray arr, uint wx, uint wy, uint sx, uint sy, uint px, uint py, bool is_column)
		{
            IntPtr ptr;
            Internal.VERIFY(AFImgPro.af_unwrap(out ptr, arr._ptr, wx, wy, sx, sy, px, py, is_column));
            return new AFArray(ptr);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AFArray Wrap(AFArray arr, uint ox, uint oy, uint wx, uint wy, uint sx, uint sy, uint px, uint py, bool is_column)
        {
            IntPtr ptr;
            Internal.VERIFY(AFImgPro.af_wrap(out ptr, arr._ptr, ox, oy, wx, wy, sx, sy, px, py, is_column));
            return new AFArray(ptr);
        }
        #endregion
    }
}
