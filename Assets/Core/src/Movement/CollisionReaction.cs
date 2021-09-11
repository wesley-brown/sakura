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
        public static CollisionReaction ForCollidedBodies(
            BodyTemp collider,
            BodyTemp collidee)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));
            throw new NotImplementedException();
        }
    }
}
