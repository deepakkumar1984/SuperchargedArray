using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Lang
{
    public class MorphRule
    {
        public string Tag { get; set; }

        public List<RuleAttr> Rules { get; set; }
    }

    public class RuleAttr
    {
        public string Key { get; set; }

        public Dictionary<string, string> Attributes { get; set; }
    }
}
