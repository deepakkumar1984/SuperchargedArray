using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class Token
    {
        public Vocab Vocab { get; set; }
        public Document Doc { get; set; }


        public Token(Vocab vocab, Document doc, int offset)
        {

        }

        public int Length
        {
            get
            {
                throw new Exception();
            }
        }

        public Token Nbor(int i = 1)
        {
            throw new NotImplementedException();
        }

        public Token Similarity(Token other)
        {
            throw new NotImplementedException();
        }

        public int LexID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Rank
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

        public float Probability
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Lang
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Index
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Cluster
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Orth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Lower
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Norm
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Shape
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Prefix
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Suffix
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Lemma
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Pos
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Tag
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Dep
        {
            get
            {
                throw new NotImplementedException();
            }
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

        public int NLefts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int NRights
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Span Sent
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

        public bool IsSentStart
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

        public int Lefts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Rights
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token[] Childern
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token[] Subtree
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token LeftEdge
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token RightEdge
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token[] Ancestors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAncestor
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Token Head
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

        public Token[] Conjuncts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong EntityType
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

        public ulong EntityIOB
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode EntityID
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

        public Unicode EntityKBID
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

        public Unicode Whitespace
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode Orth_
        {
            get
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

        public Unicode Lemma_
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode Pos_
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Unicode Tag_
        {
            get
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
