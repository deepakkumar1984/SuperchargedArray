namespace SuperNeuro.Losses
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Cross-entropy loss, or log loss, measures the performance of a classification model whose output is a probability value between 0 and 1. 
    /// Cross-entropy loss increases as the predicted probability diverges from the actual label.
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class CategoricalCrossentropy : BaseLoss
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoricalCrossentropy"/> class.
        /// </summary>
        /// <param name="fromLogit">if set to <c>true</c> [from logit].</param>
        public CategoricalCrossentropy()
            : base("categorical_crossentropy")
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
            preds /= K.Sum(preds, -1);

            preds = K.Clip(preds, K.EPSILON, 1 - K.EPSILON);
            return K.Sum(-1 * labels * K.Log(preds), -1);
        }

        /// <summary>
        /// Backpropagation method to calculate gradient of the loss function
        /// </summary>
        /// <param name="preds">The predicted result.</param>
        /// <param name="labels">The true result.</param>
        /// <returns></returns>
        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            preds = K.Clip(preds, K.EPSILON, 1 - K.EPSILON);
            return (preds - labels) / preds;
        }
    }
}
