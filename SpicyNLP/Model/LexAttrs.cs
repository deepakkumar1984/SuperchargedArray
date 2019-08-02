using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Model
{
    public class LexAttrs
    {
        public virtual bool IsPunct(string text)
        {
            throw new Exception();
        }

        public virtual bool IsAscii(string text)
        {
            throw new Exception();
        }

        public virtual bool LikeNum(string text)
        {
            throw new Exception();
        }

        public virtual bool IsBracket(string text)
        {
            throw new Exception();
        }

        public virtual bool IsQuote(string text)
        {
            throw new Exception();
        }

        public virtual bool IsLeftPunct(string text)
        {
            throw new Exception();
        }

        public virtual bool IsRightPunct(string text)
        {
            throw new Exception();
        }

        public virtual bool IsCurrency(string text)
        {
            throw new Exception();
        }

        public virtual bool LikeEmail(string text)
        {
            throw new Exception();
        }

        public virtual bool LikeUrl(string text)
        {
            throw new Exception();
        }

        public virtual string[] WordShape(string text)
        {
            throw new Exception();
        }

        public virtual StringStore Lower(StringStore strings)
        {
            throw new Exception();
        }

        public virtual StringStore Prefix(StringStore strings)
        {
            throw new Exception();
        }

        public virtual StringStore Suffix(StringStore strings)
        {
            throw new Exception();
        }

        public virtual int Cluster(StringStore strings)
        {
            throw new Exception();
        }

        public virtual bool IsAlpha(string text)
        {
            throw new Exception();
        }
    }
}
