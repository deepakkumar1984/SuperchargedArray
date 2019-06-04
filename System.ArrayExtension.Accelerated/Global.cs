using System;
using System.ArrayExtension.Accelerated;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension.Accelerated
{
    public partial class Global : ArrayExtension.Global
    {
        public static void UseAccelerator(int deviceId = 0)
        {
            Accelerator.UseDevice(deviceId);
        }
    }
}
