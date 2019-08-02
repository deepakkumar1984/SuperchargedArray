using SuperchargedArray;
using SuperNeuro.Engine;

namespace SuperNeuro.Layers.Activations
{
    /// <summary>
    /// Leaky version of a Rectified Linear Unit.
    /// <para>
    /// <![CDATA[It allows a small gradient when the unit is not active: f(x) = alpha* x for x< 0, f(x) = x for x >= 0.]]>
    /// </para>
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class LeakyRelu : BaseLayer
    {
        /// <summary>
        /// Negative slope coefficient..
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public float Alpha { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeakyRelu"/> class.
        /// </summary>
        /// <param name="alpha">Negative slope coefficient.</param>
        public LeakyRelu(float alpha = 0.3f)
            : base("leaky_relu")
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
            var keepElements = x >= 0;
            Output = x * keepElements + (Alpha * x * (1 - keepElements));
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            var keepElements = Input.Data >= 0;
            Input.Grad = outputgrad * (keepElements + (Alpha * (1 - keepElements)));
        }
    }
}
