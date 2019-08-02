﻿namespace SuperNeuro.Metrics
{
    using SuperchargedArray;
    using SuperNeuro.Engine;
    using SuperNeuro.Losses;

    /// <summary>
    /// The mean absolute percentage error (MAPE), also known as mean absolute percentage deviation (MAPD), 
    /// is a measure of prediction accuracy of a forecasting method in statistics, for example in trend estimation, also used as a Loss function for regression problems in Machine Learning.
    /// </summary>
    /// <seealso cref="SuperNeuro.Metrics.BaseMetric" />
    public class MAPE : BaseMetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MAPE"/> class.
        /// </summary>
        public MAPE()
            :base("mape")
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
            return new MeanAbsolutePercentageError().Forward(preds, labels);
        }
    }
}
