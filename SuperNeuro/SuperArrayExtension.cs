using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperNeuro
{
    internal static class SuperArrayExtension
    {
        internal static Parameter ToParameter(this SuperArray t, string name = "")
        {
            return Parameter.Create(t, name);
        }

        internal static (int, int, int) GetConv1DShape(this SuperArray x)
        {
            return ((int)x.Shape[0], (int)x.Shape[1], (int)x.Shape[2]);
        }

        internal static (int, int, int, int) GetConv2DShape(this SuperArray x)
        {
            return ((int)x.Shape[0], (int)x.Shape[1], (int)x.Shape[2], (int)x.Shape[3]);
        }

        internal static (int, int, int, int, int) GetConv3DShape(this SuperArray x)
        {
            return ((int)x.Shape[0], (int)x.Shape[1], (int)x.Shape[2], (int)x.Shape[3], (int)x.Shape[4]);
        }
    }
}
