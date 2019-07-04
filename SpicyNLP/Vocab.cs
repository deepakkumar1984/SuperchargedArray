using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class Vocab : IEnumerable, ISpicy
    {
        public Vocab(StringStore store, Dictionary<int, IFunction> lex_attr_getters = null, Dictionary<string, string> tag_map = null)
        {

        }

        public ISpicy FromBytes(byte[] data)
        {
            throw new NotImplementedException();
        }

        public ISpicy FromDish(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public byte[] ToBytes()
        {
            throw new NotImplementedException();
        }

        public void ToDisk(string path)
        {
            throw new NotImplementedException();
        }
    }
}
