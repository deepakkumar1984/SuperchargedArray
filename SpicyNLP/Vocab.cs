using SuperchargedArray;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class Vocab : IEnumerable<KeyValuePair<string, Unicode>>, ISpicy
    {
        public Dictionary<Func<Unicode, bool>, int> Flags { get; set; }

        public StringStore Strings { get; set; }

        public Vectors Vectors { get; set; }

        public Lemmatizer Lemmatizer { get; set; }

        public List<Lexeme> Lexemes { get; set; }

        public Vocab(StringStore store, Dictionary<int, Func<string, bool>> lex_attr_getters = null, Dictionary<string, string> tag_map = null, Lemmatizer lemmatizer = null)
        {
            Strings = store;
        }

        public int AddFlag(Func<string, bool> flag_getter, int flag_id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Unicode key)
        {
            throw new NotImplementedException();
        }

        public void ResetVector(int width)
        {
            throw new NotImplementedException();
        }

        public void ResetVector(Shape shape)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Unicode, float> PruneVectors(int nr_row, int batch_size = 1024)
        {
            throw new NotImplementedException();
        }

        public SuperArray GetVector(Unicode orth, int? minn = null, int? maxn = null)
        {
            throw new NotImplementedException();
        }

        public void SetVector(Unicode orth, SuperArray vector)
        {
            throw new NotImplementedException();
        }

        public bool HasVector(Unicode orth)
        {
            throw new NotImplementedException();
        }

        public ISpicy FromBytes(byte[] data)
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

        public void ToDisk(string path)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, Unicode>> GetEnumerator()
        {
            return Strings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Strings.GetEnumerator();
        }

   
    }
}
