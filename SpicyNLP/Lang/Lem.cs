using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Lang
{
    public class Lem
    {
        public LemKnot ADJECTIVES { get; set; }

        public LemKnot ADVERBS { get; set; }

        public LemKnot NOUNS { get; set; }

        public LemKnot VERBS { get; set; }

        public Dictionary<string, string> LOOKUPS { get; set; }

        public LemmaRules LemmaRules { get; set; }
    }
}
