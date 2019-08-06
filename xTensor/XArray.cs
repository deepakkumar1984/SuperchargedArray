using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace xTensor
{
    public class XArray : IDisposable
    {
        internal IntPtr handle;

        internal XArray(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [DllImport("xtensornative")]
        private static extern long XLTTensor_ndimension(IntPtr handle);

        public long Dimension()
        {
            return XLTTensor_ndimension(handle);
        }

        [DllImport("xtensornative")]
        private static extern IntPtr XLTTensor_ones(long[] sizes);
        public static XArray Ones(params long[] shape)
        {
            var ptr = XLTTensor_ones(shape);
            return new XArray(ptr);
        }
    }
}
