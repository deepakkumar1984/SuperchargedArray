using SpicyNLP.Model;
using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class Lexeme : ISpicy
    {
        public Vocab ParentVocab { get; set; }

        public Unicode Orth { get; set; }

        private string _orth;

        public string Text
        {
            get
            {
                return Orth.ToString();
            }
        }

        public int Flags { get; set; }

        public Lexeme(Vocab vocab, int orth)
        {
            ParentVocab = vocab;
            Orth = orth;
        }

        private int __richcmp__(Lexeme other, int op)
        {
            throw new NotImplementedException();
        }

        public bool CheckFlag(AttributeEnum flagId)
        {
            int One = 1;
            if (Convert.ToBoolean(One << Flags))
            {
                return true;
            }

            return false;
        }

        public void SetFlag(AttributeEnum flagId, bool value)
        {
            int One = 1;
            if (value)
            {
                Flags |= One << (int)flagId;
            }
            else
            {
                Flags &= ~(One << (int)flagId);
            }
        }

        public int Similarity(Lexeme other)
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

        public bool HasVector
        {
            get
            {
                return ParentVocab.HasVector(Orth);
            }
        }

        public float VectorNorm
        {
            get
            {
                return (float)Ops.Sum(Ops.Sqrt(Ops.Square(Vector)));
            }
        }

        public SuperArray Vector
        {
            get
            {
                return ParentVocab.Vectors[Orth];
            }
            set
            {
                ParentVocab.Vectors[Orth] = value;
            }
        }

        public Unicode Rank { get; set; }

        public float Sentiment { get; set; }

        public Unicode Lower { get; set; }

        public int Norm { get; set; }

        public int Shape { get; set; }

        public int Prefix { get; set; } = 1;

        public int Suffix { get; set; } = 3;

        public int Cluster { get; set; }

        public int Lang { get; set; }

        public float Probability { get; set; }

        public Unicode Lower_
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

        public Unicode Norm_
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

        public Unicode Shape_
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

        public Unicode Prefix_
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

        public Unicode Suffix_
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

        public Unicode Lang_
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

        public bool IsOOV
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

        public bool IsStop
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

        public bool IsAlpha
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

        public bool IsAscii
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

        public bool IsDigit
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

        public bool IsLower
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

        public bool IsTitle
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


        public bool IsPunct
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


        public bool IsSpace
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

        public bool IsBracket
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

        public bool IsQuote
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

        public bool IsLeftPunct
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

        public bool IsRightPunct
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

        public bool IsCurrency
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

        public bool LikeUrl
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

        public bool LikeNum
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

        public bool LikeEmail
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
    }
}
