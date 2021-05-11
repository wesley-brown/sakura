using System;

namespace Sakura.Core
{
    /// <summary>
    ///     A collision between a colliding body and another body.
    /// </summary>
    public sealed class Collision
    {
        /// <summary>
        ///     Create a new collision between a given colliding body and
        ///     another given body.
        /// </summary>
        /// <param name="collider">
        ///     The colliding body.
        /// </param>
        /// <param name="other">
        ///     The other body.
        /// </param>
        /// <returns>
        ///     A newly created collision between the given colliding body and
        ///     the other given body.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given colliding body is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given other body is null.
        /// </exception>
        public static Collision ForBodyCollidingWithOther(
            Body collider,
            Body other)
        {
            if (collider == null)
                throw new ArgumentNullException(
                    nameof(collider),
                    "The given colliding body must not be null");
            if (other == null)
                throw new ArgumentNullException(
                    nameof(other),
                    "The given other body must not be null");
            return null;
        }
    }
}
