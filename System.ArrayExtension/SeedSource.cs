using System;
using System.Collections.Generic;
using System.Text;

namespace System.ArrayExtension
{
    /// <summary>
    /// Class SeedSource.
    /// </summary>
    public class SeedSource
    {
        /// <summary>
        /// The RNG
        /// </summary>
        private Random rng;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeedSource"/> class.
        /// </summary>
        public SeedSource()
        {
            rng = new Random();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeedSource"/> class.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public SeedSource(int? seed)
        {
            if (seed.HasValue)
                rng = new Random(seed.Value);
            else
                rng = new Random();
        }

        /// <summary>
        /// Sets the seed.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public void SetSeed(int seed)
        {
            rng = new Random(seed);
        }

        /// <summary>
        /// Nexts the seed.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int NextSeed()
        {
            return rng.Next();
        }
    }
}
