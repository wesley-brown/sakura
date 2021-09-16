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
            return new Movement(
                destination,
                speed);
        }

        private Movement(
            Vector3 destination,
            float speed)
        {
            this.destination = destination;
            Debug.Assert(speed >= 0);
            this.speed = speed;
        }

        private readonly Vector3 destination;
        private readonly float speed;

        /// <summary>
        ///     The destination to move towards.
        /// </summary>
        public Vector3 Destination
        {
            get
            {
                return destination;
            }
        }

        /// <summary>
        ///     The speed to move towards the destination with.
        /// </summary>
        public float Speed
        {
            get
            {
                return speed;
            }
        }

        /// <summary>
        ///     Create a <see cref="string"/> representation of this
        ///     <see cref="Movement"/>.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> representation of this
        ///     <see cref="Movement"/>.
        /// </returns>
        public override string ToString()
        {
            return "Destination="
                + Destination
                + ", Speed="
                + Speed;
        }
    }
}
