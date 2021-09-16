using System;
using UnityEngine;

namespace Sakura.Core
{
    /// <summary>
    ///     An instance of one <see cref="Body"/> trying to occupy the same
    ///     space as another after moving.
    /// </summary>
    public sealed class Collision
    {
        /// <summary>
        ///     Create a <see cref="Collision"/> between two given
        ///     <see cref="Body"/>s.
        /// </summary>
        /// <param name="collider">
        ///     The <see cref="Body"/> that moved.
        /// </param>
        /// <param name="collidee">
        ///     The <see cref="Body"/> that was moved into.
        /// </param>
        /// <returns>
        ///     A <see cref="Collision"/> between the two given
        ///     <see cref="Body"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collider <see cref="Body"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given collidee <see cref="Body"/> is null.
        /// </exception>
        public static Collision BetweenBodies(
            Body collider,
            Body collidee)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));
            if (collidee == null)
                throw new ArgumentNullException(nameof(collidee));
            return new Collision(collider);
        }

        private Collision(Body collider)
        {
            Debug.Assert(collider != null);
            this.collider = collider;
        }

        private readonly Body collider;

        /// <summary>
        ///     The <see cref="Body"/> that moved.
        /// </summary>
        public Body Collider
        {
            get
            {
                return collider;
            }
        }

        /// <summary>
        ///     Create a <see cref="string"/> representation of this
        ///     <see cref="Collision"/>.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> representation of this
        ///     <see cref="Collision"/>.
        /// </returns>
        public override string ToString()
        {
            return "Collider=" + collider;
        }
    }
}
