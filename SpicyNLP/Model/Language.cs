using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Model
{
    public class Language
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public List<string> Infixes { get; set; }

        public List<string> Prefixes { get; set; }

        public List<string> Suffixes { get; set; }

        public List<string> StopWords { get; set; }

        public List<MorphRule> MorphRules { get; set; }

        public Lemma Lemma { get; set; }

        public TagMap TagMap { get; set; }
    }
}
