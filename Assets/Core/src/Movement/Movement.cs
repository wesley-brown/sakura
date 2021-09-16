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
        ///     The speed to move towards the destination with, measured in
        ///     movement units per tick.
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
        ///     The speed to move towards the destination with, measured in
        ///     movement units per tick.
        /// </summary>
        public float Speed
        {
            get
            {
                return speed;
            }
        }

        /// <summary>
        ///     Move a given <see cref="Body"/> one tick forward towards this 
        ///     <see cref="Movement"/>'s <see cref="Destination"/> at this
        ///     <see cref="Movement"/>'s <see cref="Speed"/>.
        /// </summary>
        /// <remarks>
        ///     Since the given <see cref="Body"/> is moved one tick forward,
        ///     its ending location may not be this <see cref="Movement"/>'s
        ///     <see cref="Destination"/> if the given <see cref="Body"/>'s
        ///     <see cref="Body.Location"/> is too far away to be reached in
        ///     one tick at this <see cref="Movement"/>'s <see cref="Speed"/>.
        /// </remarks>
        /// <param name="body">
        ///     The <see cref="Body"/> to move.
        /// </param>
        /// <returns>
        ///     A <see cref="Body"/> for the same entity as the given
        ///     <see cref="Body"/> moved as close to <see cref="Destination"/>
        ///     as possible in one tick at <see cref="Speed"/>.
        /// </returns>
        public Body Move(Body body)
        {
            var heading = destination - body.Location;
            var distance = heading.magnitude;
            var direction = heading / distance;
            var movement = direction * speed;
            var newLocation = body.Location + movement;
            return body.TeleportTo(newLocation);
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
