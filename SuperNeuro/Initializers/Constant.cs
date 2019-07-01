namespace SuperNeuro.Initializers
{
    using SuperchargedArray;
    using SuperNeuro.Engine;

    /// <summary>
    /// Initializer that generates SuperArrays initialized to a constant value.
    /// </summary>
    /// <seealso cref="SuperNeuro.Initializers.BaseInitializer" />
    public class Constant : BaseInitializer
    {
        /// <summary>
        /// float; the value of the generator SuperArrays.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public float Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constant"/> class.
        /// </summary>
        /// <param name="value">float; the value of the generator SuperArrays.</param>
        public Constant(float value)
            :base("constant")
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constant"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        internal Constant(string name, float value)
           : base(name)
        {
            Value = value;
        }

        /// <summary>
        /// Generates a SuperArray with specified shape.
        /// </summary>
        /// <param name="shape">The shape of the SuperArray.</param>
        /// <returns></returns>
        public override SuperArray Generate(params long[] shape)
        {
            SuperArray SuperArray = K.Constant(Value, shape);
            return SuperArray;
        }
    }
}
