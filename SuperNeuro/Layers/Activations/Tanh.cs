namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Hyperbolic tangent activation. Tanh squashes a real-valued number to the range [-1, 1].
    /// It’s non-linear. But unlike Sigmoid, its output is zero-centered. Therefore, in practice the tanh non-linearity is always preferred to the sigmoid nonlinearity.
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Tanh : BaseLayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tanh"/> class.
        /// </summary>
        public Tanh()
            : base("tanh")
        {
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            Output = Ops.Tanh(x);
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad * (1 - Ops.Square(Output));
        }
    }
}
