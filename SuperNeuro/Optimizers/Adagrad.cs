﻿namespace SuperNeuro.Optimizers
{
    using System.Collections.Generic;
    using SuperchargedArray;
    using SuperNeuro.Engine;
    using SuperNeuro.Layers;

    /// <summary>
    /// Adagrad is an optimizer with parameter-specific learning rates, which are adapted relative to how frequently a parameter gets updated during training. The more updates a parameter receives, the smaller the learning rate.
    /// </summary>
    /// <seealso cref="SuperNeuro.Optimizers.BaseOptimizer" />
    public class Adagrad : BaseOptimizer
    {
        /// <summary>
        /// Fuzz factor. Lowest float value but > 0
        /// </summary>
        /// <value>
        /// The epsilon.
        /// </value>
        public float Epsilon { get; set; }

        private Dictionary<string, SuperArray> accumulators;

        /// <summary>
        /// Initializes a new instance of the <see cref="Adagrad"/> class.
        /// </summary>
        /// <param name="lr">Initial learning rate for the optimizer.</param>
        /// <param name="decayRate">Learning rate decay over each update.</param>
        /// <param name="epsilon">Fuzz factor. Lowest float value but > 0</param>
        public Adagrad(float lr = 0.01f, float decayRate = 0, float epsilon = 1e-07f)
            : base(lr, "adagrad")
        {
            DecayRate = decayRate;
            Epsilon = epsilon;
            accumulators = new Dictionary<string, SuperArray>();
        }

        /// <summary>
        /// Updates the specified iteration.
        /// </summary>
        /// <param name="iteration">The iteration.</param>
        /// <param name="layer">The layer.</param>
        internal override void Update(int iteration, BaseLayer layer)
        {
            if (DecayRate > 0)
            {
                LearningRate = LearningRate * (1 / 1 + DecayRate * iteration);
            }

            foreach (var item in layer.Params)
            {
                var param = item.Value;
                if (!accumulators.ContainsKey(param.Name))
                {
                    accumulators[param.Name] = Ops.Constant(0, param.Data.Shape);
                }

                accumulators[param.Name] = accumulators[param.Name] + Ops.Square(param.Grad);
                param.Data = param.Data - (LearningRate * param.Grad / (Ops.Sqrt(accumulators[param.Name]) + Ops.EPSILON));

                param.ApplyConstraint();
            }
        }
    }
}
