namespace SuperNeuro.Initializers
{
    /// <summary>
    /// Initializer that generates SuperArrays initialized to 0.
    /// </summary>
    /// <seealso cref="SuperNeuro.Initializers.Constant" />
    public class Zeros : Constant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Zeros"/> class.
        /// </summary>
        public Zeros()
            : base("zeros", 0)
        {

        }
    }
}
