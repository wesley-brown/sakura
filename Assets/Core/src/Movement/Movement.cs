using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A displacement of a <see cref="Core.Body"/> through world space to a
    ///     destination.
    /// </summary>
    public sealed class Movement
    {
        /// <summary>
        ///     Create a <see cref="Movement"/> for a given
        ///     <see cref="Core.Body"/> and destination.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Core.Body"/> being moved.
        /// </param>
        /// <param name="destination">
        ///     The destination.
        /// </param>
        /// <returns>
        ///     A <see cref="Movement"/> for the given <see cref="Core.Body"/>
        ///     and destination.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Core.Body"/> is null.
        /// </exception>
        public static Movement For(
            Body body,
            Vector3 destination)
        {
            if (body == null)
                throw new ArgumentNullException(
                    nameof(body),
                    "The given body must not be null.");
            return new Movement(
                body,
                destination);
        }

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

        private Movement(
            Body body,
            Vector3 destination)
        {
            Debug.Assert(body != null);
            this.body = body;
            this.destination = new Vector3(
                destination.x,
                destination.y,
                destination.z);
        }

        private readonly Body body;
        private readonly Vector3 destination;

        /// <summary>
        ///     The <see cref="Core.Body"/> to move.
        /// </summary>
        public Body Body
        {
            get
            {
                return body;
            }
        }

        /// <summary>
        ///     Create a <see cref="Core.Body"/> that is the result of moving
        ///     the <see cref="Core.Body"/> to the destination.
        /// </summary>
        /// <returns>
        ///     The <see cref="Core.Body"/> that is the result of moving the
        ///     <see cref="Core.Body"/> to the destination.
        /// </returns>
        public Body ResultingBody()
        {
            return body.TeleportTo(destination);
        }

        /// <summary>
        ///     Create a string representation of this <see cref="Movement"/>.
        /// </summary>
        /// <returns>
        ///     A string representation of this <see cref="Movement"/>.
        /// </returns>
        public override string ToString()
        {
            return "{"
                + "Body="
                + Body
                + ", Resulting Body="
                + ResultingBody()
                + "}";
        }
    }
}
