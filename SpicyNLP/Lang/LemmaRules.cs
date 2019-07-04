using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Lang
{
    public class LemmaRules
    {
        public Dictionary<string, string> ADJECTIVE_RULES { get; set; }

        public Dictionary<string, string> NOUN_RULES { get; set; }

        public Dictionary<string, string> VERB_RULES { get; set; }

        public Dictionary<string, string> PUNCT_RULES { get; set; }
    }
}
