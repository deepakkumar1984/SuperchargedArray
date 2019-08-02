namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Exponential activation function which returns simple exp(x)
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Exp : BaseLayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exp"/> class.
        /// </summary>
        public Exp()
            : base("exp")
        {
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            Output = Ops.Exp(x);
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad * Output;
        }
    }
}
