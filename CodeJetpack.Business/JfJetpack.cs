using System;

namespace CodeJetpack.Business
{
    /// <summary>
    /// Simple demo jetpack business class.
    /// Public classes use the "Jf" prefix by repository convention.
    /// </summary>
    public class JfJetpack
    {
        /// <summary>
        /// Amount of fuel remaining (integer units).
        /// </summary>
        public int FuelAmount { get; set; }

        /// <summary>
        /// Current altitude in meters.
        /// </summary>
        public float Altitude { get; set; }

        /// <summary>
        /// Indicates whether the jetpack is currently flying.
        /// </summary>
        public bool IsFlying => Altitude > 0;

        /// <summary>
        /// The name of the jetpack.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a new jetpack with optional starting fuel and altitude.
        /// </summary>
        public JfJetpack(string name, int startingFuel = 100, float startingAltitude = 0f)
        {
            Name = name;
            FuelAmount = startingFuel;
            Altitude = startingAltitude;
        }

        /// <summary>
        /// Attempt to fly the jetpack. Consumes fuel and increases altitude.
        /// Returns true when flight occurred, false when there is no fuel.
        /// </summary>
        public bool Fly(float meters = 1f)
        {
            if (FuelAmount <= 0)
            {
                return false;
            }

            // Simple model: consume 1 fuel per call and increase altitude by meters.
            FuelAmount -= 1;
            Altitude += meters;
            return true;
        }

        /// <summary>
        /// Land the jetpack. Sets altitude to zero.
        /// </summary>
        public void Land()
        {
            Altitude = 0f;
        }
    }
}
