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
    public class Conv3DTranspose : BaseLayer
    {
        public Conv3DTranspose(int filters, Tuple<int, int, int> kernalSize, int strides = 1, PaddingType padding = PaddingType.Same, Tuple<int, int, int> dialationRate = null,
                                ActType activation = ActType.Linear, BaseInitializer kernalInitializer = null,
                                 BaseRegularizer kernalRegularizer = null, BaseConstraint kernalConstraint = null,
                                bool useBias = true, BaseInitializer biasInitializer = null, BaseRegularizer biasRegularizer = null, BaseConstraint biasConstraint = null)
            : base("conv3d_transpose")
        {
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
