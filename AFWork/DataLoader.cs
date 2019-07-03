using SiaNet.Backend.ArrayFire;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFWork
{
    public partial class SuperArray
    {
        public static SuperArray Create(bool[] data) => Data.CreateArray(data);
        public static SuperArray Create(bool[,] data) => Data.CreateArray(data);
        public static SuperArray Create(bool[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(bool[,,,] data) => Data.CreateArray(data);


        public static SuperArray Create(float[] data) => Data.CreateArray(data);
        public static SuperArray Create(float[,] data) => Data.CreateArray(data);
        public static SuperArray Create(float[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(float[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(double[] data) => Data.CreateArray(data);
        public static SuperArray Create(double[,] data) => Data.CreateArray(data);
        public static SuperArray Create(double[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(double[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(int[] data) => Data.CreateArray(data);
        public static SuperArray Create(int[,] data) => Data.CreateArray(data);
        public static SuperArray Create(int[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(int[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(uint[] data) => Data.CreateArray(data);
        public static SuperArray Create(uint[,] data) => Data.CreateArray(data);
        public static SuperArray Create(uint[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(uint[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(long[] data) => Data.CreateArray(data);
        public static SuperArray Create(long[,] data) => Data.CreateArray(data);
        public static SuperArray Create(long[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(long[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(ulong[] data) => Data.CreateArray(data);
        public static SuperArray Create(ulong[,] data) => Data.CreateArray(data);
        public static SuperArray Create(ulong[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(ulong[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(byte[] data) => Data.CreateArray(data);
        public static SuperArray Create(byte[,] data) => Data.CreateArray(data);
        public static SuperArray Create(byte[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(byte[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(short[] data) => Data.CreateArray(data);
        public static SuperArray Create(short[,] data) => Data.CreateArray(data);
        public static SuperArray Create(short[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(short[,,,] data) => Data.CreateArray(data);

        public static SuperArray Create(ushort[] data) => Data.CreateArray(data);
        public static SuperArray Create(ushort[,] data) => Data.CreateArray(data);
        public static SuperArray Create(ushort[,,] data) => Data.CreateArray(data);
        public static SuperArray Create(ushort[,,,] data) => Data.CreateArray(data);
    }
}
