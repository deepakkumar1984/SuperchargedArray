using System;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension.Accelerated
{
    public enum DeviceType
    {
        CPU = 1 << 1,
        GPU = 1 << 2,
        FPGA = 1 << 3
    }

    public class Device
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Vendor { get; set; }

        public DeviceType Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {2}-> {1}", ID, Name, Type);
        }
    }
}
