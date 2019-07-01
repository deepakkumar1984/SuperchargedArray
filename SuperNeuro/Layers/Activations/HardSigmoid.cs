namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;
    using System;

    public class HardSigmoid : BaseLayer
    {
        public HardSigmoid()
            : base("hard_sigmoid")
        {
        }

        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            throw new NotImplementedException();
        }

        public override void Backward(SuperArray outputgrad)
        {
            throw new NotImplementedException();
        }
    }
}
