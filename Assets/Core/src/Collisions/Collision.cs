using System;
using System.Diagnostics;

namespace Sakura.Core
{
    /// <summary>
    ///     A collision between a colliding body and another body.
    /// </summary>
    public sealed class Collision
    {
        private readonly Body collider;
        private readonly Body other;

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
            return new Collision(
                collider,
                other);
        }

        private Collision(
            Body collider,
            Body other)
        {
            Debug.Assert(
                collider != null,
                "The given colliding body was null");
            this.collider = collider;
            Debug.Assert(
                other != null,
                "The given other body was null");
            this.other = other;
        }

        public Body Collider()
        {
            return collider;
        }

        public Body Other()
        {
            return other;
        }

        public override string ToString()
        {
            return "{"
                + "Collider="
                + Collider()
                + ", Other="
                + Other()
                + "}";
        }
    }
}
