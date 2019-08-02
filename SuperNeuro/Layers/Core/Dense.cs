namespace SuperNeuro.Layers
{
    using SuperchargedArray;
    using SuperNeuro.Constraints;
    using SuperNeuro.Engine;
    using SuperNeuro.Initializers;
    using SuperNeuro.Layers.Activations;
    using SuperNeuro.Regularizers;

    /// <summary>
    /// Dense implements the operation: output = activation(dot(input, kernel) + bias) where activation is the element-wise activation function passed as the activation argument, 
    /// kernel is a weights matrix created by the layer, and bias is a bias vector created by the layer (only applicable if use_bias is True).
    /// </summary>
    /// <seealso cref="SuperNeuro.Layers.BaseLayer" />
    public class Dense : BaseLayer
    {
        /// <summary>
        /// Dimensions of the output space
        /// </summary>
        /// <value>
        /// The dim.
        /// </value>
        public int Dim { get; set; }

        /// <summary>
        /// Activation function to use. If none specified linear activation will be used
        /// </summary>
        /// <value>
        /// The act.
        /// </value>
        public BaseLayer Act { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use bias parameter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use bias]; otherwise, <c>false</c>.
        /// </value>
        public bool UseBias { get; set; }

        /// <summary>
        /// Initializer for kernel weight matrix
        /// </summary>
        /// <value>
        /// The kernel initializer.
        /// </value>
        public BaseInitializer KernelInitializer { get; set; }

        /// <summary>
        /// Initializer for bias weight matrix
        /// </summary>
        /// <value>
        /// The bias initializer.
        /// </value>
        public BaseInitializer BiasInitializer { get; set; }

        /// <summary>
        /// Constraint function applied to kernel weight matrix
        /// </summary>
        /// <value>
        /// The kernel constraint.
        /// </value>
        public BaseConstraint KernelConstraint { get; set; }

        /// <summary>
        /// Constraint function applied to bias weight matrix
        /// </summary>
        /// <value>
        /// The bias constraint.
        /// </value>
        public BaseConstraint BiasConstraint { get; set; }

        /// <summary>
        /// Regularizer function applied to kernel weight matrix
        /// </summary>
        /// <value>
        /// The kernel regularizer.
        /// </value>
        public BaseRegularizer KernelRegularizer { get; set; }

        /// <summary>
        ///  Constraint function applied to bias weight matrix
        /// </summary>
        /// <value>
        /// The bias regularizer.
        /// </value>
        public BaseRegularizer BiasRegularizer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dense"/> class.
        /// </summary>
        /// <param name="dim">Dimensions of the output space</param>
        /// <param name="activation">Activation function to use. If none specified linear activation will be used</param>
        /// <param name="kernelInitializer">Initializer for kernel weight matrix.</param>
        /// <param name="kernelRegularizer">Regularizer function applied to bias weight matrix</param>
        /// <param name="kernelConstraint">Constraint function applied to kernel weight matrix.</param>
        /// <param name="useBias">if set to <c>true</c> will use bias parameter.</param>
        /// <param name="biasInitializer">Initializer for bias weight matrix</param>
        /// <param name="biasRegularizer">Regularizer function applied to bias weight matrix</param>
        /// <param name="biasConstraint">Constraint function applied to bias weight matrix</param>
        public Dense(int dim, ActType activation = ActType.Linear,
                    BaseInitializer kernelInitializer = null, BaseRegularizer kernelRegularizer = null, BaseConstraint kernelConstraint = null,
                    bool useBias = true, BaseInitializer biasInitializer = null, BaseRegularizer biasRegularizer = null, BaseConstraint biasConstraint = null)
            : base("dense")
        {
            Dim = dim;
            Act = ActivationRegistry.Get(activation);
            UseBias = useBias;
            KernelInitializer = kernelInitializer ?? new GlorotUniform();
            BiasInitializer = biasInitializer ?? new Zeros();
            KernelConstraint = kernelConstraint;
            BiasConstraint = biasConstraint;
            KernelRegularizer = kernelRegularizer;
            BiasRegularizer = biasRegularizer;
        }

        /// <summary>
        /// Forwards the inputs and compute the output
        /// </summary>
        /// <param name="x">The input SuperArray for this layer.</param>
        public override void Forward(SuperArray x)
        {
            base.Forward(x);

            Parameter weight = BuildParam("w", new Shape(x.Shape[1], Dim), KernelInitializer, KernelConstraint, KernelRegularizer);
            Parameter bias = null;
            Output = Ops.Dot(x, weight.Data);

            if (UseBias)
            {
                bias = BuildParam("b", new Shape(1, Dim), BiasInitializer, BiasConstraint, BiasRegularizer);
                Output = Output + bias.Data;
            }

            if (Act != null)
            {
                Act.Forward(Output);
                Output = Act.Output;
            }
        }

        /// <summary>
        /// Calculate the gradient of this layer function
        /// </summary>
        /// <param name="outputgrad">The calculated output grad from previous layer.</param>
        public override void Backward(SuperArray outputgrad)
        {
            if (Act != null)
            {
                Act.Backward(outputgrad);
                outputgrad = Act.Input.Grad;
            }

            Input.Grad = Ops.Dot(outputgrad, base["w"].Data.Transpose());
            this["w"].Grad = Ops.Dot(Input.Data.Transpose(), outputgrad);
            if (UseBias)
                this["b"].Grad = Ops.Sum(outputgrad, 0);
        }
    }
}
