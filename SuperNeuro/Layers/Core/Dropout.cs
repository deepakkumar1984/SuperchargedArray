namespace SuperNeuro.Layers
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Applies Dropout to the input. Dropout consists in randomly setting a fraction rate of input units to 0 at each update during training time, which helps prevent overfitting.
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Dropout : BaseLayer
    {
        /// <summary>
        /// The noise
        /// </summary>
        private SuperArray noise;

        /// <summary>
        /// float between 0 and 1. Fraction of the input units to drop.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public float Rate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dropout"/> class.
        /// </summary>
        /// <param name="rate">float between 0 and 1. Fraction of the input units to drop..</param>
        public Dropout(float rate)
            :base("dropout")
        {
            SkipPred = true;
            Rate = rate;
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            
            var p = 1 - Rate;
            if (noise == null)
            {
                noise = SuperArray.RandomBernoulli<float>(x.Shape, p);
            }

            Output = noise * p;
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad * noise;
        }
    }
}
