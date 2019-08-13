using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class Unicode
    {
        internal byte[] data;

        private int code;

        public Unicode(string s)
        {
            data = Encoding.Unicode.GetBytes(s);
        }

        public Unicode(int code)
        {
            this.code = code;
        }

        public override string ToString()
        {
            if (data != null)
                return Encoding.Unicode.GetString(data);

            return code.ToString();
        }

        public override bool Equals(object obj)
        {
            Unicode other = (Unicode)obj;

            return (other.ToString() == this.ToString());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static implicit operator Unicode(string s)
        {
            return new Unicode(s);
        }

        public static implicit operator Unicode(int d)
        {
            return new Unicode(d.ToString());
        }

        public static explicit operator string(Unicode u)
        {
            return u.ToString();
        }

        public static explicit operator int(Unicode u)
        {
            return u.code;
        }

        public static explicit operator SymbolEnum(Unicode u)
        {
            return (SymbolEnum)u.code;
        }

        public static explicit operator AttributeEnum(Unicode u)
        {
            return (AttributeEnum)u.code;
        }
    }
}
