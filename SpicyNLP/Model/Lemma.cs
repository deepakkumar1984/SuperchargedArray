using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Model
{
    public class Lemma
    {
        public Dictionary<string, string> Lookups { get; set; }

        public LemmaRules Rules { get; set; }

        public LemmaExceptions Exceptions { get; set; }

        public LemmaIndexes Indexes { get; set; }
    }

    public class LemmaIndexes
    {
        public List<string> Adj { get; set; }

        public List<string> Adv { get; set; }

        public List<string> Noun { get; set; }

        public List<string> Verb { get; set; }
    }

    public class LemmaRules
    {
        public List<List<string>> Adj { get; set; }

        public List<List<string>> Adv { get; set; }

        public List<List<string>> Noun { get; set; }

        public List<List<string>> Verb { get; set; }
    }

    public class LemmaExceptions
    {
        public LemmaExcRule Adj { get; set; }

        public LemmaExcRule Adv { get; set; }

        public LemmaExcRule Noun { get; set; }

        public LemmaExcRule Verb { get; set; }
    }

    public class LemmaExcRule
    {
        public string Text { get; set; }

        public List<string> Exceptions { get; set; }
    }
}
