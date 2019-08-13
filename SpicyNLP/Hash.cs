﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class MurmurHash2
    {
        public static uint Hash(Unicode data)
        {
            return Hash(data.data);
        }

        public static uint Hash(byte[] data)
        {
            return Hash(data, 0xc58f1a7a);
        }
        const uint m = 0x5bd1e995;
        const int r = 24;

        public static uint Hash(byte[] data, uint seed)
        {
            int length = data.Length;
            if (length == 0)
                return 0;
            uint h = seed ^ (uint)length;
            int currentIndex = 0;
            while (length >= 4)
            {
                uint k = (uint)(data[currentIndex++] | data[currentIndex++] << 8 | data[currentIndex++] << 16 | data[currentIndex++] << 24);
                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;
                length -= 4;
            }
            switch (length)
            {
                case 3:
                    h ^= (UInt16)(data[currentIndex++] | data[currentIndex++] << 8);
                    h ^= (uint)(data[currentIndex] << 16);
                    h *= m;
                    break;
                case 2:
                    h ^= (UInt16)(data[currentIndex++] | data[currentIndex] << 8);
                    h *= m;
                    break;
                case 1:
                    h ^= data[currentIndex];
                    h *= m;
                    break;
                default:
                    break;
            }

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
        }
    }
}
