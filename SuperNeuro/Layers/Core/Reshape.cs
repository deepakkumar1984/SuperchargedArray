﻿namespace SuperNeuro.Layers
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Reshapes an output to a certain shape.
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Reshape : BaseLayer
    {
        /// <summary>
        /// Target new shape. One and only one dim can be 0, in which case it will be inferred from the rest of dims
        /// </summary>
        public long[] TargetShape { get; set; }

        /// <summary>
        /// The target output shape
        /// </summary>
        /// <param name="targetShape"></param>
        /// <param name="reverse"></param>
        public Reshape(long[] targetShape)
            : base("reshape")
        {
            TargetShape = targetShape;
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);

            Output = x.Reshape(TargetShape);
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad.Reshape(Input.Data.Shape);
        }
    }
}
