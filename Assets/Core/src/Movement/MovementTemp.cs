using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A displacement of a body through world space to a destination.
    /// </summary>
    public sealed class MovementTemp
    {
        /// <summary>
        ///     Create a movement for a given body and destination.
        /// </summary>
        /// <param name="body">
        ///     The body.
        /// </param>
        /// <param name="destination">
        ///     The destination.
        /// </param>
        /// <returns>
        ///     A movement for the given body and destination.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given body is null.
        /// </exception>
        public static MovementTemp For(
            BodyTemp body,
            Vector3 destination)
        {
            if (body == null)
            {
                throw new ArgumentNullException(
                    nameof(body),
                    "The given body must not be null.");
            }
            return new MovementTemp(
                body,
                destination);
        }

        private MovementTemp(
            BodyTemp body,
            Vector3 destination)
        {
            Debug.Assert(body != null);
            this.body = body;
            this.destination = new Vector3(
                destination.x,
                destination.y,
                destination.z);
        }

        private readonly BodyTemp body;
        private readonly Vector3 destination;

        /// <summary>
        ///     The body to move.
        /// </summary>
        public BodyTemp Body
        {
            get
            {
                return body;
            }
        }

        /// <summary>
        ///     Create a body that is the result of moving the body to the
        ///     destination.
        /// </summary>
        /// <returns>
        ///     The body that is the result of moving the body to the
        ///     destination.
        /// </returns>
        public BodyTemp ResultingBody()
        {
            return BodyTemp.ForEntityLocatedAt(
                body.Entity,
                destination);
        }

        /// <summary>
        ///     Create a string representation of this movement.
        /// </summary>
        /// <returns>
        ///     A string representation of this movement.
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
