namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Mean squared logarithmic error (MSLE) is, as the name suggests, a variation of the Mean Squared Error. 
    /// The loss is the mean over the seen data of the squared differences between the log-transformed true and predicted values, or writing it as a formula: where ŷ is the predicted value.
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class MeanSquaredLogError : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeanSquaredLogError"/> class.
        /// </summary>
        public MeanSquaredLogError()
            : base("mean_squared_logarithmic_error")
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
            var first_log = Ops.Log(Ops.Clip(preds, Ops.EPSILON, float.MaxValue) + 1);
            var second_log = Ops.Log(Ops.Clip(labels, Ops.EPSILON, float.MaxValue) + 1);

            return Ops.Mean(Ops.Square(first_log - second_log), 1);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            float norm = 2f / preds.Shape[0];
            var first_log = Ops.Log(Ops.Clip(preds, Ops.EPSILON, float.MaxValue) + 1);
            var second_log = Ops.Log(Ops.Clip(labels, Ops.EPSILON, float.MaxValue) + 1);

            return  norm * (first_log - second_log) / (Ops.Clip(preds, Ops.EPSILON, float.MaxValue) + 1);
        }
    }
}
