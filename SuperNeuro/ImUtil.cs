using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro
{
    class ImUtil
    {
        public static SuperArray Im2Col(SuperArray x, Tuple<int, int> kernalSize, int padding = 1, int stride = 1, Tuple<int, int> dialation = null)
        {
            if (dialation == null)
                dialation = Tuple.Create<int, int>(1, 1);

            var (n, c, h, w) = x.GetConv2DShape();

            var out_height = (h + 2 * padding - kernalSize.Item1) / stride + 1;
            var out_width = (w + 2 * padding - kernalSize.Item2) / stride + 1;
            SuperArray cols = new SuperArray((c * kernalSize.Item1 * kernalSize.Item2), (n * out_height * out_width));

            return cols;
        }

        public static SuperArray Col2Im(SuperArray cols, int[] x_shape, Tuple<int, int> kernalSize, int padding = 1, int stride = 1, Tuple<int, int> dialation = null)
        {

            if (dialation == null)
                dialation = Tuple.Create<int, int>(1, 1);

            SuperArray im = new SuperArray(x_shape);

            return im;
        }
    }
}
