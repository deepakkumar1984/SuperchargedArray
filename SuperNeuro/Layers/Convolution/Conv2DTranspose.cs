using SuperchargedArray;
using SuperNeuro.Constraints;
using SuperNeuro.Engine;
using SuperNeuro.Initializers;
using SuperNeuro.Regularizers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Layers
{
    public class Conv2DTranspose : BaseLayer
    {
        public Conv2DTranspose(uint filters, Tuple<uint, uint> kernalSize, uint strides = 1, PaddingType padding = PaddingType.Same, Tuple<uint, uint> dialationRate = null,
                                ActType activation = ActType.Linear, BaseInitializer kernalInitializer = null, BaseRegularizer kernalRegularizer = null,
                                BaseConstraint kernalConstraint = null, bool useBias = true, BaseInitializer biasInitializer = null, BaseRegularizer biasRegularizer = null,
                                BaseConstraint biasConstraint = null)
            : base("conv2d_transpose")
        {
            Name = "conv2d_transpose";
        }


        public override void Forward(SuperArray x)
        {
            throw new NotImplementedException();
        }

        public override void Backward(SuperArray outputgrad)
        {
            throw new NotImplementedException();
        }
    }
}
