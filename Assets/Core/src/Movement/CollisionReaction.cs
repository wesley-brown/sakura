using System;
using System.Diagnostics;

namespace Sakura.Core
{
    /// <summary>
    ///     A instance of two <see cref="Body"/>s reacting to a collision
    ///     between them.
    /// </summary>
    public sealed class CollisionReaction
    {
        /// <summary>
        ///     Create a <see cref="CollisionReaction"/> for two given collided
        ///     <see cref="Body"/>s.
        /// </summary>
        /// <param name="collider">
        ///     The <see cref="Body"/> that made the collision.
        /// </param>
        /// <param name="collidee">
        ///     The <see cref="Body"/> that was collided with.
        /// </param>
        /// <returns>
        ///     A <see cref="CollisionReaction"/> for the two given collided
        ///     <see cref="Body"/>s.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collider <see cref="Body"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given collidee <see cref="Body"/> is null.
        /// </exception>
        public static CollisionReaction ForCollidedBodies(
            Body collider,
            Body collidee)
        {
            if (collider == null)
                throw new ArgumentNullException(nameof(collider));
            if (collidee == null)
                throw new ArgumentNullException(nameof(collidee));
            return new CollisionReaction(
                new Guid(),
                collider,
                collidee);
        }

        private CollisionReaction(
            Guid id,
            Body collider,
            Body collidee)
        {
            this.id = id;
            Debug.Assert(collider != null);
            this.collider = collider;
            Debug.Assert(collidee != null);
            this.collidee = collidee;
        }

        private readonly Guid id;
        private readonly Body collider;
        private readonly Body collidee;

        /// <summary>
        ///     The ID of this <see cref="CollisionReaction"/>.
        /// </summary>
        /// <returns></returns>
        public Guid ID
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        ///     The body that made the collision.
        /// </summary>
        public Body Collider
        {
            get
            {
                return collider;
            }
        }

        /// <summary>
        ///     The body that was collided with.
        /// </summary>
        public Body Collidee
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
                + "ID="
                + ID
                + ", Collider="
                + Collider
                + ", Collidee="
                + Collidee
                + "}";
        }
    }
}
