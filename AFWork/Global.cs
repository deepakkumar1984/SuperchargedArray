using SiaNet.Backend.ArrayFire;
using SiaNet.Backend.ArrayFire.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFWork
{
    public class Global
    {
        public static bool IsColumnMajor { get; set; }

        public static void SetBackend(BackendType backend, int device = 0)
        {
            Device.SetBackend(backend);
            Device.SetDevice(device);
        }
    }
}
