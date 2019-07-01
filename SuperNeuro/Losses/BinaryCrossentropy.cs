namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Binary Cross-Entropy Loss. Also called Sigmoid Cross-Entropy loss. 
    /// It is a Sigmoid activation plus a Cross-Entropy loss. 
    /// Unlike Softmax loss it is independent for each vector component (class), meaning that the loss computed for every vector component is not affected by other component values
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class BinaryCrossentropy : BaseLoss
    {
        /// <summary>
        /// Gets or sets a value indicating whether [from logit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [from logit]; otherwise, <c>false</c>.
        /// </value>
        public bool FromLogit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryCrossentropy"/> class.
        /// </summary>
        /// <param name="fromLogit">if set to <c>true</c> [from logit].</param>
        public BinaryCrossentropy(bool fromLogit = false)
            : base("binary_crossentropy")
        {
            FromLogit = fromLogit;
        }

        /// <summary>
        /// Forwards the inputs and calculate the loss.
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Forward(SuperArray preds, SuperArray labels)
        {
            SuperArray output = preds;
            if (!FromLogit)
            {
                output = K.Clip(output, K.EPSILON, 1f - K.EPSILON);
                output = K.Log(output / (1 - output));
            }

            output = K.Sigmoid(output);
            return labels * K.Neg(K.Log(output)) + (1 - labels) * K.Neg(K.Log(1 - output));
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            SuperArray output = preds;

            if (!FromLogit)
            {
                output = K.Clip(preds, K.EPSILON, 1f - K.EPSILON);
            }

            return (output - labels) / (output * (1 - output));
        }
    }
}
