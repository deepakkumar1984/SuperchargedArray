namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// The categorical cross-entropy loss (negative log likelihood) is used when a probabilistic interpretation of the scores is desired.
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class CategorialHinge : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategorialHinge"/> class.
        /// </summary>
        public CategorialHinge()
            : base("categorical_hinge")
        {

        }

        /// <summary>
        /// Forwards the inputs and calculate the loss.
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Forward(SuperArray preds, SuperArray labels)
        {
            var pos = K.Sum(labels * preds, -1);
            var neg = K.Max((1 - labels) * preds, -1);

            return K.Maximum(neg - pos + 1, 0f);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            var diff = (1 - labels) * preds - K.Sum(labels * preds, -1);
            return K.Maximum(diff, 0);
        }
    }
}
