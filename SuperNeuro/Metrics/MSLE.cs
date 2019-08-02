namespace SuperNeuro.Metrics
{
    using SuperchargedArray;
    using SuperNeuro.Engine;
    using SuperNeuro.Losses;

    /// <summary>
    /// Mean squared logarithmic error (MSLE) is, as the name suggests, a variation of the Mean Squared Error. 
    /// </summary>
    /// <seealso cref="SuperNeuro.Metrics.BaseMetric" />
    public class MSLE : BaseMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MSLE"/> class.
        /// </summary>
        public MSLE()
            :base("msle")
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
            return new MeanSquaredLogError().Forward(preds, labels);
        }
    }
}
