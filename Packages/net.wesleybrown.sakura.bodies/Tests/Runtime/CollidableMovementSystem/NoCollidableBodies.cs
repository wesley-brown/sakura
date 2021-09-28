using System;
using Sakura.Client;
using Sakura.Core;

namespace Collidable_Movement_System_Spec
{
    sealed class NoCollidableBodies : CollidableBodies
    {
        /// <summary>
        ///     The movement speed for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns 0f.
        /// </returns>
        public float MovementSpeedForEntity(Guid entity)
        {
            return 0f;
        }

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns null.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            return null;
        }

        /// <summary>
        ///    Replace the <see cref="Body"/> that currently represents a
        ///    given entity with a given <see cref="Body"/>.
        /// </summary>
        /// <param name="entity">
        ///     The entity to replace the <see cref="Body"/> of.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to replace the given entity's
        ///     <see cref="Body"/> with.
        /// </param>
        public void ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            // No-op
        }

        /// <summary>
        ///     Whether or not a given <see cref="Body"/> is currently
        ///     colliding with another <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to check for <see cref="Collision"/>s
        ///     for.
        /// </param>
        /// <returns>
        ///     Always returns false.
        /// </returns>
        public bool BodyIsColliding(Body body)
        {
            return false;
        }

        /// <summary>
        ///     The <see cref="Collision"/> caused by the movement of a given
        ///     <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     Always returns null.
        /// </returns>
        public Collision CollisionForBody(Body body)
        {
            return null;
        }

        /// <summary>
        ///     The <see cref="Collision"/>, if any, caused by applying a given
        ///     <see cref="Movement"/> to a given <see cref="Body"/>.
        /// </summary>
        /// <param name="movement">
        ///     The <see cref="Movement"/> to apply to the <see cref="Body"/>.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to apply the <see cref="Movement"/> to.
        /// </param>
        /// <returns>
        ///     Always returns null.
        /// </returns>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            return null;
        }
    }
}
