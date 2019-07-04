namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// <![CDATA[Exponential linear unit activation function: x if x > 0 and alpha * (exp(x)-1) if x < 0.]]>
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Elu : BaseLayer
    {
        /// <summary>
        /// Slope of the negative section
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public float Alpha { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elu"/> class.
        /// </summary>
        /// <param name="alpha">Slope of the negative section.</param>
        public Elu(float alpha = 1)
            : base("elu")
        {
            Alpha = alpha;
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            var keepElements = x > 0;
            var keepElements_Exp = x < 0;
            var d = Alpha * (Ops.Exp(x * keepElements_Exp) - 1);
            Output = (x * keepElements) + d;
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            var keepElements = Input.Data > 0;
            var keepElements_Exp = Input.Data < 0;
            var d = Alpha * Ops.Exp(Input.Data * keepElements_Exp);
            Input.Grad = outputgrad * d;
        }
    }
}
