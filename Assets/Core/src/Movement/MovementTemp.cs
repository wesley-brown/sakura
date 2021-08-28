using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     A displacement of a body through world space.
    /// </summary>
    public sealed class MovementTemp
    {
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
            throw new NotImplementedException();
        }
    }
}
