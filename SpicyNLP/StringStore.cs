using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpicyNLP
{
    public class StringStore : IEnumerable<KeyValuePair<string, Unicode>>, ISpicy
    {
        private Dictionary<string, Unicode> data;

        public int Length
        {
            get
            {
                return data.Count;
            }
        }

        public StringStore(params Unicode[] strings)
        {
            data = new Dictionary<string, Unicode>();
            foreach (var item in strings)
            {
                data.Add(Helper.GetHash(item.ToString()), item);
            }
        }

        public Unicode this[string hash]
        {
            get
            {
                return data[hash];
            }
        }

        public string this[Unicode s]
        {
            get
            {
                return data.FirstOrDefault(x => (x.Value == s)).Key;
            }
        }

        public string Add(string s)
        {
            string hash = Helper.GetHash(s);
            data.Add(hash, s);
            return hash;
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, Unicode>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
