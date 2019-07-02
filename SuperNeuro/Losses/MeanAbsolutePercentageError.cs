﻿namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// The mean absolute percentage error (MAPE), also known as mean absolute percentage deviation (MAPD), 
    /// is a measure of prediction accuracy of a forecasting method in statistics, for example in trend estimation, also used as a Loss function for regression problems in Machine Learning.
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class MeanAbsolutePercentageError : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeanAbsolutePercentageError"/> class.
        /// </summary>
        public MeanAbsolutePercentageError()
            : base("mean_absolute_percentage_error")
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
            var diff = K.Abs(preds - labels) / K.Clip(K.Abs(labels), K.EPSILON, float.MaxValue);
            return 100 * K.Mean(diff, 1).Reshape(1, -1);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            var diff = (preds - labels) / K.Clip(K.Abs(labels) * K.Abs(labels - preds), K.EPSILON, float.MaxValue);
            return 100 * diff / preds.Shape[0];
        }
    }
}
