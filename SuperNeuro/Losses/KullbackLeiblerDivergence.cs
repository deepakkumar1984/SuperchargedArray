namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// KL Divergence, also known as relative entropy, information divergence/gain, is a measure of how one probability distribution diverges from a second expected probability distribution.
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class KullbackLeiblerDivergence : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KullbackLeiblerDivergence"/> class.
        /// </summary>
        public KullbackLeiblerDivergence()
            : base("kullback_leibler_divergence")
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
            var y_true = Ops.Clip(labels, Ops.EPSILON, 1);
            var y_pred = Ops.Clip(preds, Ops.EPSILON, 1);

            return Ops.Sum(y_true * Ops.Log(y_true / y_pred), 1);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            var y_true = Ops.Clip(labels, Ops.EPSILON, 1);
            var y_pred = Ops.Clip(preds, Ops.EPSILON, 1);

            return Ops.Maximum((-1 * (y_true / y_pred)), 0);
        }
    }
}
