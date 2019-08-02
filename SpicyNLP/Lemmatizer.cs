using SpicyNLP.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public class Lemmatizer : Lemma
    {
        public Lemmatizer(LemmaIndexes index = null, LemmaExceptions exceptions = null, LemmaRules rules = null, Dictionary<string, string> lookups = null)
        {
            this.Exceptions = exceptions;
            Indexes = index;
            Rules = rules;
            Lookups = lookups;
        }

        public string[] Call(string s, SymbolEnum univ_pos, Dictionary<string, string> morphology)
        {
            throw new NotImplementedException();
        }

        public string Lookup(string s)
        {
            throw new NotImplementedException();
        }

        public bool IsBaseForm(SymbolEnum univ_pos, Dictionary<string, string> morphology)
        {
            throw new NotImplementedException();
        }
    }
}
