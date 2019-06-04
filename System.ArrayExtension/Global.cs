using System;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension
{
    public partial class Global
    {
        public static int ParallelThread { get; set; } = Environment.ProcessorCount;

        public static ArrayOps OP { get; set; } = new ArrayOps();
    }
}
