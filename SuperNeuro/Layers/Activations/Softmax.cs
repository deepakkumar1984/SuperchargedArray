namespace SuperNeuro.Layers.Activations
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Softmax function calculates the probabilities distribution of the event over ‘n’ different events. 
    /// In general way of saying, this function will calculate the probabilities of each target class over all possible target classes. 
    /// Later the calculated probabilities will be helpful for determining the target class for the given inputs.
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Softmax : BaseLayer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Softmax"/> class.
        /// </summary>
        public Softmax()
            : base("softmax")
        {
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            Output = Utils.Softmax(x);
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            var s = Output.Reshape(-1, 1);
            var d = Ops.Diag(s) - Ops.Dot(s, s.Transpose());
            Input.Grad = outputgrad * Ops.Sum(d, 1).Reshape(Input.Data.Shape);
        }
    }
}
