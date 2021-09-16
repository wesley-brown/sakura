using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A displacement of a <see cref="Body"/> through world space to a
    ///     destination.
    /// </summary>
    public sealed class Movement
    {
        /// <summary>
        ///     Create a <see cref="Movement"/> towards a given destination
        ///     with a given speed.
        /// </summary>
        /// <param name="destination">
        ///     The destination to move towards.
        /// </param>
        /// <param name="speed">
        ///     The speed to move towards the destination with.
        /// </param>
        /// <returns>
        ///     A <see cref="Movement"/> that moves towards the given
        ///     destination with the given speed.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the given speed is negative.
        /// </exception>
        public static Movement TowardsDestinationWithSpeed(
            Vector3 destination,
            float speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(speed),
                    "The given speed must be non-negative.");
            throw new NotImplementedException();
        }
    }
}
