﻿using SuperchargedArray;
using SuperNeuro.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Constraints
{
    /// <summary>
    /// Constrains the weights incident to each hidden unit to have unit norm.
    /// </summary>
    /// <seealso cref="SuperNeuro.Constraints.BaseConstraint" />
    public class UnitNorm : BaseConstraint
    {
        /// <summary>
        /// Integer, axis along which to calculate weight norms. For instance, in a Dense layer the weight matrix has shape (input_dim, output_dim), set axis to 0 to constrain each weight vector of length (input_dim,). 
        /// In a Conv2D layer, the weight SuperArray has shape  (output_depth, input_depth, rows, cols), 
        /// set axis to [1, 2, 3] to constrain the weights of each filter SuperArray of size  (input_depth, rows, cols).
        /// </summary>
        /// <value>
        /// The axis.
        /// </value>
        public int Axis;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitNorm"/> class.
        /// </summary>
        /// <param name="axis">Integer, axis along which to calculate weight norms</param>
        public UnitNorm(int axis = 0)
        {
            Axis = axis;
        }

        /// <summary>
        /// Invoke the constraint
        /// </summary>
        /// <param name="w">The w.</param>
        /// <returns></returns>
        internal override SuperArray Call(SuperArray w)
        {
            return w / (K.EPSILON + K.Sqrt(K.Sum(K.Square(w), Axis)));
        }
    }
}
