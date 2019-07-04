namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Cosine Proximity loss function computes the cosine proximity between predicted value and actual value.
    /// It is same as Cosine Similarity, which is a measure of similarity between two non-zero vectors of an inner product space that measures the cosine of the angle between them. In this case, note that unit vectors are maximally “similar” if they’re parallel and maximally “dissimilar” if they’re orthogonal (perpendicular). 
    /// This is analogous to the cosine, which is unity (maximum value) when the segments subtend a zero angle and zero (uncorrelated) when the segments are perpendicular.
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class CosineProximity : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosineProximity"/> class.
        /// </summary>
        public CosineProximity()
            : base("cosine_proximity")
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
            return -1 * _cossine_sim(preds, labels);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            var y_true = Ops.Max(Ops.Sum(labels, 1), 1) / (Ops.Abs(preds * Ops.Abs(labels)));
            var y_pred = Ops.Max(Ops.Sum(preds, 1), 1) / Ops.Square(Ops.Abs(preds));

            return y_true + _cossine_sim(preds, labels) * y_pred;
        }

        private SuperArray _cossine_sim(SuperArray preds, SuperArray labels)
        {
            var y_true = Utils.L2Normalize(labels, 1);
            var y_pred = Utils.L2Normalize(preds, 1);
            return Ops.Sum(y_true * y_pred, 1);
        }
    }
}
