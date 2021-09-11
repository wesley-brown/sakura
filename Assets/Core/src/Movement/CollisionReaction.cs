using System;

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
            throw new NotImplementedException();
        }
    }
}
