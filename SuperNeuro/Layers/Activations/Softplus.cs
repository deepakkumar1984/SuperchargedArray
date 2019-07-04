namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// The softplus activation: log(exp(x) + 1).
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Softplus : BaseLayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Softplus"/> class.
        /// </summary>
        public Softplus()
            : base("softplus")
        {
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            Output = Utils.Softplus(x);
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad * (Ops.Exp(Input.Data) / (Ops.Exp(Input.Data) + 1));
        }
    }
}
