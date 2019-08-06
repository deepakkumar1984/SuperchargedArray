using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Autograd
{
    public class Functions
    {
        public static Variable Sin(Variable x)
        {
            var result = Ops.Sin(x.Array());

            void grad_func(List<Variable> inputs, Variable grad_output)
            {
                inputs[0].AddGrad(grad_output * Ops.Cos(inputs[0].Array()));
            };
        }

        public static Variable Cos(Variable x)
        {
            var result = Ops.Cos(x.Array());

            void grad_func(List<Variable> inputs, Variable grad_output)
            {
                inputs[0].AddGrad(new Variable(grad_output.Array() * Ops.Neg(Ops.Sin(inputs[0].Array()))));
            };

            
        }
    }
}
