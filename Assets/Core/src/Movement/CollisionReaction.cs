using System;
using System.Diagnostics;

namespace Sakura.Core
{
    /// <summary>
    ///     A instance of two bodies reacting to a collision between them.
    /// </summary>
    public sealed class CollisionReaction
    {
        /// <summary>
        ///     Create a <see cref="CollisionReaction"/> for two given collided
        ///     bodies.
        /// </summary>
        /// <param name="collider">
        ///     The body that made the collision.
        /// </param>
        /// <param name="collidee">
        ///     The body that was collided with.
        /// </param>
        /// <returns>
        ///     A <see cref="CollisionReaction"/> for the two given collided
        ///     bodies.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collider body is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given collidee body is null.
        /// </exception>
        public static CollisionReaction ForCollidedBodies(
            BodyTemp collider,
            BodyTemp collidee)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));
            if (collidee == null)
                throw new ArgumentNullException(nameof(collidee));
            return new CollisionReaction(
                collider,
                collidee);
        }

        private CollisionReaction(
            BodyTemp collider,
            BodyTemp collidee)
        {
            Debug.Assert(collider != null);
            this.collider = collider;
            Debug.Assert(collidee != null);
            this.collidee = collidee;
        }

        private readonly BodyTemp collider;
        private readonly BodyTemp collidee;
        

        /// <summary>
        ///     The body that made the collision.
        /// </summary>
        public BodyTemp Collider
        {
            get
            {
                return collider;
            }
        }

        /// <summary>
        ///     The body that was collided with.
        /// </summary>
        public BodyTemp Collidee
        {
            get
            {
                return collidee;
            }
        }

        /// <summary>
        ///     Create a string representation of this
        ///     <see cref="CollisionReaction"/>.
        /// </summary>
        /// <returns>
        ///     A string representation of this
        ///     <see cref="CollisionReaction"/>.
        /// </returns>
        public override string ToString()
        {
            return "{"
                + "Collider="
                + Collider
                + ", Collidee="
                + Collidee
                + "}";
        }
    }
}
