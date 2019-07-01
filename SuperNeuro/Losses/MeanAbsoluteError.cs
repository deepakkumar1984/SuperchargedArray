namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Mean Absolute Error (MAE) is a quantity used to measure how close forecasts or predictions are to the eventual outcomes
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class MeanAbsoluteError : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeanAbsoluteError"/> class.
        /// </summary>
        public MeanAbsoluteError()
            : base("mean_absolute_error")
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
            return K.Reshape(K.Mean(K.Abs(preds - labels), 1), 1, -1);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            return (preds - labels) / ((float)preds.Shape[0] * K.Abs(preds - labels));
        }
    }
}
