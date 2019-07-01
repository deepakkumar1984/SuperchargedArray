using SuperchargedArray;
using SuperNeuro.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Constraints
{
    /// <summary>
    /// Constrains the weights to be non-negative.
    /// </summary>
    /// <seealso cref="SuperNeuro.Constraints.BaseConstraint" />
    public class NonNeg : BaseConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonNeg"/> class.
        /// </summary>
        public NonNeg()
        {
        }

        /// <summary>
        /// Invoke the constraint
        /// </summary>
        /// <param name="w">The w.</param>
        /// <returns></returns>
        internal override SuperArray Call(SuperArray w)
        {
            w = w * (w >= 0);
            return w;
        }
    }
}
