namespace SuperNeuro.Metrics
{
    using SuperchargedArray;
    using SuperNeuro.Engine;
    using SuperNeuro.Losses;

    /// <summary>
    /// The mean squared error (MSE) or mean squared deviation (MSD) of an estimator (of a procedure for estimating an unobserved quantity) measures the average of the squares of the errors—that is, the average squared difference between the estimated values and what is estimated.
    /// </summary>
    /// <seealso cref="SuperNeuro.Metrics.BaseMetric" />
    public class MSE : BaseMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MSE"/> class.
        /// </summary>
        public MSE()
            :base("mse")
        {

        }

        /// <summary>
        /// Calculates the metric with predicted and true values.
        /// </summary>
        /// <param name="preds">The predicted value.</param>
        /// <param name="labels">The true value.</param>
        /// <returns></returns>
        public override SuperArray Calc(SuperArray preds, SuperArray labels)
        {
            return new MeanSquaredError().Forward(preds, labels);
        }
    }
}
