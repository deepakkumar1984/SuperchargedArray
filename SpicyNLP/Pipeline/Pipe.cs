using SuperNeuro;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP.Pipeline
{
    public abstract class Pipe
    {
        Sequential model = null;

        Dictionary<string, object> parameters;

        public Pipe(Vocab vocab, Sequential model = null, Dictionary<string, object> parameters = null)
        {
            this.model = model;
            this.parameters = parameters;
        }

        public abstract Sequential Model(Dictionary<string, object> args = null);


    }
}
