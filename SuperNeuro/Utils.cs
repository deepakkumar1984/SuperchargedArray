using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro
{
    public class Utils
    {
        private static ArrayOps K = Global.OP;

        public static SuperArray Softmax(SuperArray x, int axis = -1)
        {
            var e = K.Exp(x - K.Max(x, axis));
            var s = K.Sum(e, axis);
            return e / s;
        }

        public static SuperArray Softplus(SuperArray x, int axis = -1)
        {
            return K.Log((K.Exp(x) + 1));
        }

        public static SuperArray L1Normalize(SuperArray x, int axis = -1)
        {
            throw new NotImplementedException();
        }

        public static SuperArray L2Normalize(SuperArray x, int axis = -1)
        {
            var y = K.Max(K.Sum(K.Square(x), axis), axis);
            return x / K.Sqrt(y);
        }
    }
}
