using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Model
{
    public class TagMap
    {
        public string Tag { get; set; }

        public Dictionary<SymbolEnum, string> Maps { get; set; }
    }
}
