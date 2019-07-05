using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace SpicyNLP
{
    public class Vectors : IEnumerable<Unicode>, ISpicy
    {
        public Dictionary<Unicode, SuperArray> Items { get; set; }

        public List<Unicode> Keys
        {
            get
            {
                return Items.Keys.ToList();
            }
        }

        public List<SuperArray> Values
        {
            get
            {
                return Items.Values.ToList();
            }
        }

        public (int, int) Shape
        {
            get
            {
                return (Items.Count, Items.First().Value.ElementCount);
            }
        }

        public int Size
        {
            get
            {
                var (row, col) = Shape;
                return row * col;
            }
        }

        public Vectors(SuperArray data = null, string[] keys = null)
        {
            throw new NotImplementedException();
        }

        public Vectors(Shape shape = null)
        {
            throw new NotImplementedException();
        }

        public SuperArray this[Unicode key]
        {
            get
            {
                return Items[key];
            }
            set
            {
                Items[key] = value;
            }
        }

        public IEnumerator<Unicode> GetEnumerator()
        {
            return Items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.Keys.GetEnumerator();
        }

        public bool Contains(string key)
        {
            return Items.ContainsKey(key);
        }

        public void Add(string key, SuperArray vector, int? row = null)
        {
            throw new NotImplementedException();
        }

        public Version Resize(Shape shape, bool inplace = false)
        {
            throw new NotImplementedException();
        }

        public SuperArray[] Find(params string[] keys)
        {
            throw new NotImplementedException();
        }

        public SuperArray[] Find(params int[] rows)
        {
            throw new NotImplementedException();
        }

        public static Vectors FromGlove(string path)
        {
            throw new NotImplementedException();
        }

        public void ToDisk(string path)
        {
            throw new NotImplementedException();
        }

        public ISpicy FromDisk(string path)
        {
            throw new NotImplementedException();
        }

        public byte[] ToBytes()
        {
            throw new NotImplementedException();
        }

        public ISpicy FromBytes(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
