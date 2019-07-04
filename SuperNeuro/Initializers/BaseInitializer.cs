namespace SuperNeuro.Initializers
{
    using SuperchargedArray;
    using SuperNeuro.Engine;
    using K = SuperchargedArray.Ops;

    /// <summary>
    /// Base class for the initializer. Initializes the SuperArray weights or bias with values based on the type of the initializer selected.
    /// </summary>
    public abstract class BaseInitializer
    {
        /// <summary>
        /// Gets or sets the name of the initializer.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseInitializer"/> class.
        /// </summary>
        /// <param name="name">The name of the initializer.</param>
        public BaseInitializer(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Generates a SuperArray with specified shape.
        /// </summary>
        /// <param name="shape">The shape of the SuperArray.</param>
        /// <returns></returns>
        public abstract SuperArray Generate(Shape shape);
    }
}
