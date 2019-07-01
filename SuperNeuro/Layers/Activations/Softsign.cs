namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// The softsign activation: x / (abs(x) + 1).
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Softsign : BaseLayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Softsign"/> class.
        /// </summary>
        public Softsign()
            : base("softsign")
        {
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);

            Output = x / (K.Abs(x) + 1);
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad / K.Square(K.Abs(Input.Data) + 1);
        }
    }
}
