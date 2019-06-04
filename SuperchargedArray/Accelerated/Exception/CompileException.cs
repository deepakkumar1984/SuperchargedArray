using System;
using System.Runtime.Serialization;

namespace SuperchargedArray.Accelerated
{
    public class CompileException : Exception
    {
        public CompileException()
        {
        }

        public CompileException(string message) : base(message)
        {
            
        }

        public CompileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CompileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}