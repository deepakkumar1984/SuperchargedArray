using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;
using K = SuperchargedArray.Ops;

namespace SuperNeuro
{
    public class Utils
    {
        public static SuperArray Softmax(SuperArray x, uint axis = 1)
        {
            var e = Ops.Exp(x - Ops.Max(x, axis));
            var s = Ops.Sum(e, axis);
            return e / s;
        }

        public static SuperArray Softplus(SuperArray x, uint axis = 1)
        {
            return Ops.Log((Ops.Exp(x) + 1));
        }

        public static SuperArray L1Normalize(SuperArray x, uint axis = 1)
        {
            throw new NotImplementedException();
        }

        public static SuperArray L2Normalize(SuperArray x, uint axis = 1)
        {
            var y = Ops.Max(Ops.Sum(Ops.Square(x), axis), axis);
            return x / Ops.Sqrt(y);
        }
    }
}
