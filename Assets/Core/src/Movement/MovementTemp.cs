using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A displacement of a body through world space.
    /// </summary>
    public sealed class MovementTemp
    {
        private readonly BodyTemp body;

        /// <summary>
        ///     Create a movement for a given body and location.
        /// </summary>
        /// <param name="body">
        ///     The body.
        /// </param>
        /// <param name="location">
        ///     The location.
        /// </param>
        /// <returns>
        ///     A movement for the given body and location.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given body is null.
        /// </exception>
        public static MovementTemp For(
            BodyTemp body,
            Vector3 location)
        {
            if (body == null)
            {
                throw new ArgumentNullException(
                    nameof(body),
                    "The given body must not be null.");
            }
            return new MovementTemp(body);
        }

        private MovementTemp(BodyTemp body)
        {
            Debug.Assert(body != null);
            this.body = body;
        }

        /// <summary>
        ///     The body this movement is for.
        /// </summary>
        public BodyTemp Body
        {
            get
            {
                return body;
            }
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
                + "}";
        }
    }
}
