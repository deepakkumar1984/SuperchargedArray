using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SuperchargedArray;

namespace SpicyNLP
{
    public class Document : IEnumerable<Token>, ISpicy
    {
        public Vocab Vocab { get; set; }

        public Unicode[] Words { get; set; }

        public List<Token> Tokens { get; set; }

        public bool[] Spaces { get; set; }

        public Dictionary<string, object> UserData { get; set; }

        public Document(Vocab vocab, Unicode[] words, bool[] spaces, Dictionary<string, object> user_data = null)
        {
            Vocab = vocab;
            Words = words;
            Spaces = spaces;
            UserData = user_data;
        }

        public bool IsSentenced
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsNered
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Span this[int start, int end]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<Token> GetEnumerator()
        {
            return Tokens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Tokens.GetEnumerator();
        }

        public Span CharSpan(int startIndex, int endIndex, int label = 0, int kb_id = 0, SuperArray vector = null)
        {
            throw new NotImplementedException();
        }

        public float Similarity(Document other)
        {
            throw new NotImplementedException();
        }

        public bool HasVector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SuperArray Vector
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float VectorNorm
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode Text
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode TextWithSpace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Span[] Entities
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Span[] NounChunks
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Span[] Sents
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Lang
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode Lang_
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int PushBack(Lexeme lex, int has_space)
        {
            throw new NotImplementedException();
        }

        public int PushBack(Token token, int has_space)
        {
            throw new NotImplementedException();
        }

        public SuperArray ToArray(int[] attr_ids)
        {
            throw new NotImplementedException();
        }

        public SuperArray ToArray(string[] attr_ids)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, int> CountBy(ulong attr_id)
        {
            throw new NotImplementedException();
        }

        public Document FromArray(int[] attrs, SuperArray array)
        {
            throw new NotImplementedException();
        }

        public SuperArray GetLCAMatrix()
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

        public void ExtendTensor(SuperArray tensor)
        {
            throw new NotImplementedException();
        }

        public object Retokenize()
        {
            throw new NotImplementedException();
        }

        public void Merge(int startIndex, int endIndex, int[] attributes)
        {
            throw new NotImplementedException();
        }

        public string ToJson(string[] underscore = null)
        {
            throw new NotImplementedException();
        }
    }
}
