using SuperchargedArray;
using SuperNeuro.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Layers
{
    public class AvgPooling1D : BaseLayer
    {
        public int PoolSize { get; set; }

        public int Strides { get; set; }

        public PaddingType Padding { get; set; }

        private SuperArray xCols;

        public AvgPooling1D(int poolSize = 2, int strides = 1, PaddingType padding = PaddingType.Same)
            : base("avgpooling1d")
        {
            PoolSize = poolSize;
            Strides = strides;
            Padding = padding;
        }

        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            var (n, c, s) = x.GetConv1DShape();

            int pad = 0;
            if (Padding == PaddingType.Same)
            {
                pad = 1;
            }
            else if (Padding == PaddingType.Full)
            {
                pad = 2;
            }

            var s_out = (s - PoolSize) / Strides + 1;

            var x_reshaped = x.Reshape(n * c, 1, s);
            xCols = ImUtil.Im2Col(x_reshaped, Tuple.Create(PoolSize, PoolSize), pad, Strides);
            Output = Ops.Mean(xCols, 0);
            Output = Output.Reshape(s_out, n, c).Transpose(2, 0, 1);
        }

        public override void Backward(SuperArray outputgrad)
        {
            SuperArray dX_col = Ops.Constant(0, xCols.Shape);
            var (n, c, s) = Input.Data.GetConv1DShape();

            int pad = 0;
            if (Padding == PaddingType.Same)
            {
                pad = 1;
            }
            else if (Padding == PaddingType.Full)
            {
                pad = 2;
            }

            var dout_flat = outputgrad.Transpose(2, 0, 1).Reshape(1, -1);
            var dX = ImUtil.Col2Im(dout_flat, Input.Data.Shape.Dims, Tuple.Create(PoolSize, PoolSize), pad, Strides);
            Input.Grad = dX.Reshape(n, c, s);
        }
    }
}
