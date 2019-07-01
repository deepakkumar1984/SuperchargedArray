namespace SuperNeuro.Initializers
{
    /// <summary>
    /// Initializer that generates SuperArrays initialized to 1.
    /// </summary>
    /// <seealso cref="SuperNeuro.Initializers.Constant" />
    public class Ones : Constant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ones"/> class.
        /// </summary>
        public Ones()
            : base("ones", 1)
        {

        }
    }
}
