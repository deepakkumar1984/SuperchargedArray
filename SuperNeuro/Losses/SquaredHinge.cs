using SuperchargedArray;
using SuperNeuro.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Losses
{
    /// <summary>
    /// Squared Hinge Loss function is a variant of Hinge Loss, it solves the problem in hinge loss that the derivative of hinge loss has a discontinuity at Pred * True = 1
    /// </summary>
    /// <seealso cref="SuperNeuro.Losses.BaseLoss" />
    public class SquaredHinge : BaseLoss
    {
        public SquaredHinge()
            : base("squared_hinge")
        {

        }

        public override SuperArray Forward(SuperArray preds, SuperArray labels)
        {
            var value = 1 - labels * preds;

            return K.Mean(K.Square(K.Maximum(value, 0)), -1);
        }

        public override SuperArray Backward(SuperArray preds, SuperArray labels)
        {
            float norm = 2f / preds.Shape[0];
            return -1 * norm * labels * K.Maximum((1 - labels * preds), 0);
        }
    }
}
