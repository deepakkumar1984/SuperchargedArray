using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Model
{
    public class TokenExceptions
    {
        public string Text { get; set; }

        public List<Dictionary<SymbolEnum, string>> Exceptions { get; set; }
    }
}
