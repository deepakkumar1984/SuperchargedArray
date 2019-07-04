namespace SuperNeuro
{
    using SuperNeuro.Constraints;
    using SuperNeuro.Regularizers;
    using SuperNeuro.Engine;
    using SuperchargedArray;
    using System;

    /// <summary>
    /// Placeholder variable for holding weight and bias for the neural networOps. Attached with constraints and regularizer to easy apply them during optimizer update operations
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// The constraint
        /// </summary>
        private BaseConstraint constraint;

        /// <summary>
        /// The regularizer
        /// </summary>
        private BaseRegularizer regularizer;

        public SuperArray Data { get; set; }

        public SuperArray Grad { get; set; }

        public string Name { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        public Parameter(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Create an instance of parameter with SuperArray data.
        /// </summary>
        /// <param name="data">The SuperArray data to build the parameter.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <returns></returns>
        public static Parameter Create(SuperArray data, string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                name = "v";

            Parameter x = new Parameter(name);
            x.Data = data;

            return x;
        }

        /// <summary>
        /// Gets a value indicating whether the parameter have regularizer function attached.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [have regularizer]; otherwise, <c>false</c>.
        /// </value>
        public bool HaveRegularizer
        {
            get
            {
                return regularizer != null;
            }
        }

        /// <summary>
        /// Sets the constraint function.
        /// </summary>
        /// <param name="fn">The function.</param>
        public void SetConstraint(BaseConstraint fn)
        {
            constraint = fn;
        }

        /// <summary>
        /// Sets the regularizer function.
        /// </summary>
        /// <param name="fn">The function.</param>
        public void SetRegularizer(BaseRegularizer fn)
        {
            regularizer = fn;
        }

        /// <summary>
        /// Applies the constraint function to weight/bias during training.
        /// </summary>
        public void ApplyConstraint()
        {
            if (constraint != null)
            {
                Data = constraint.Call(Data);
            }
        }

        /// <summary>
        /// Applies the regularizer function to weight/bias during training.
        /// </summary>
        /// <returns></returns>
        public float ApplyRegularizer()
        {
            float r = 0;
            if (regularizer != null)
            {
                r = regularizer.Call(Data);
            }

            return r;
        }

        /// <summary>
        /// Applies the gradient of regularizer function during back propagation.
        /// </summary>
        public void ApplyDeltaRegularizer()
        {
            if (regularizer != null)
            {
                Grad += regularizer.CalcGrad(Data);
            }
        }
    }
}
