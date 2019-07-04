using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpicyNLP
{
    public class StringStore : IEnumerable, ISpicy
    {
        private Dictionary<string, string> data;

        public int Length
        {
            get
            {
                return data.Count;
            }
        }

        public StringStore(params string[] strings)
        {
            data = new Dictionary<string, string>();
            foreach (var item in strings)
            {
                data.Add(Helper.GetHash(item), item);
            }
        }

        public string this[string s, bool returnHash = true]
        {
            get
            {
                if(!returnHash)
                {
                    return data[s];
                }

                var r = data.FirstOrDefault(x => (x.Value == s));
                return r.Value;
            }
        }

        public string Add(string s)
        {
            string hash = Helper.GetHash(s);
            data.Add(hash, s);
            return hash;
        }


        public IEnumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public void ToDisk(string path)
        {
            throw new NotImplementedException();
        }

        public ISpicy FromDish(string path)
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
