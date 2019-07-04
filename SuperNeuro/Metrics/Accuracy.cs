namespace SuperNeuro.Metrics
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Accuracy is suggested to use to measure how accurate is the overall performance of a model is, considering both positive and negative classes without worrying about the imbalance of a data set
    /// </summary>
    /// <seealso cref="SuperNeuro.Metrics.BaseMetric" />
    public class Accuracy : BaseMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Accuracy"/> class.
        /// </summary>
        public Accuracy()
            :base("accuracy")
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
            preds = Ops.ArgMax(preds);
            labels = Ops.ArgMax(labels);

            var r = Ops.EqualTo(preds, labels);

            return r;
        }
    }
}
