using SiaNet.Backend.ArrayFire;
using SiaNet.Backend.ArrayFire.Interop;
using System;
using System.Linq;

namespace AFWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.SetBackend(BackendType.CPU);
            var a = SuperArray.Create(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
            a = a + 2f;
            var r = Ops.Mean(Ops.ArgMax(a));
            //r.Print();
        }

        //static AFArray Max(SiaNet.Backend.ArrayFire.AFArray x, int axis)
        //{
        //    var y = Data.ModDims(x, x.Dimensions.Select(i => (long)i).Reverse().ToArray());
        //    y = Matrix.Transpose(y, false);
        //    y = Ops.Max(y, axis);
        //    return Data.ModDims(y, y.Dimensions.Select(i => (long)i).Reverse().ToArray());
        //}

        //static AFArray ArgMax(SiaNet.Backend.ArrayFire.AFArray x)
        //{
        //    var y = Data.ModDims(x, x.Dimensions.Select(i => (long)i).Reverse().ToArray());
        //    return Ops.TopK(y, 1, 0, 2);
        //}

        //static void Print(SiaNet.Backend.ArrayFire.AFArray x)
        //{
        //    var y = Data.ModDims(x, x.Dimensions.Select(i => (long)i).Reverse().ToArray());
        //    y = Matrix.Transpose(y, false);
        //    var d = Data.GetData<float>(y);
        //    AFUtil.af_print_array(y._ptr);
        //}
    }
}
