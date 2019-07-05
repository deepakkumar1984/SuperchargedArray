using SpicyNLP;
using SpicyNLP.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpicyLang.Exporter
{
    class Program
    {
        static Language lang;

        static void Main(string[] args)
        {
            List<Func<string, bool>> flist = new List<Func<string, bool>>();

            flist.Add(new LexAttrs().IsPunct);

            lang = new Language();
            LoadInfixes();
        }

        static void LoadInfixes()
        {
            string path = "./en/infixes.txt";

            string data = File.ReadAllText(path);
            lang.Infixes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(data);
        }

        static void LoadPrefixes()
        {
            string path = "./en/prefixes.txt";

            string data = File.ReadAllText(path);
            lang.Infixes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(data);
        }

        static void LoadSuffixes()
        {
            string path = "./en/suffixes.txt";

            string data = File.ReadAllText(path);
            lang.Infixes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(data);
        }

        static void LoadStopWords()
        {
            string path = "./en/suffixes.txt";

            string data = File.ReadAllText(path);
            lang.Infixes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(data);
        }
    }
}
