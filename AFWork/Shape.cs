using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AFWork
{
    public class Shape
    {
        public int[] Dims { get; set; }

        public int Length
        {
            get
            {
                return Dims.Length;
            }
        }

        public Shape(params int[] size)
        {
            Dims = size;
        }

        public Shape(params uint[] size)
        {
            Dims = size.Select(x => (int)x).ToArray();
        }

        public Shape(params long[] size)
        {
            Dims = size.Select(x => (int)x).ToArray();
        }

        public long[] GetLongShape()
        {
            return Dims.Select(x => (long)x).ToArray();
        }

        public uint[] GetUIntShape()
        {
            return Dims.Select(x => (uint)x).ToArray();
        }

        public int this[int index]
        {
            get
            {
                return Dims[index];
            }
            set
            {
                Dims[index] = value;
            }
        }

        public static implicit operator Shape(int size)
        {
            return new Shape(size);
        }

        public static implicit operator Shape((int, int) size)
        {
            return new Shape(size.Item1, size.Item2);
        }

        public static implicit operator Shape((int, int, int) size)
        {
            return new Shape(size.Item1, size.Item2, size.Item3);
        }

        public static implicit operator Shape((int, int, int, int) size)
        {
            return new Shape(size.Item1, size.Item2, size.Item3, size.Item4);
        }
    }
}
