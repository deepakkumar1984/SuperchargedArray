namespace SuperNeuro.Metrics
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Positive and negative predictive values. 
    /// In addition to sensitivity and specificity, the performance of a binary classification test can be measured with positive predictive value (PPV), also known as precision, and negative predictive value (NPV)
    /// </summary>
    /// <seealso cref="SuperNeuro.Metrics.BaseMetric" />
    public class BinaryAccuracy : BaseMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryAccuracy"/> class.
        /// </summary>
        public BinaryAccuracy()
            :base("binary_accuracy")
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
            preds = K.Clip(preds, 0, 1);
            var r = K.EqualTo(K.Round(preds), labels);

            return r;
        }
    }
}
