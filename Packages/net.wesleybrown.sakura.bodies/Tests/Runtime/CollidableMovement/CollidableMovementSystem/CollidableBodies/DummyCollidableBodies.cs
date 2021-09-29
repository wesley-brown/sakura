using System;
using Sakura.Bodies.CollidableMovement;
using Sakura.Core;

namespace Collidable_Movement_System_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="CollidableBodies"/>.
    /// </summary>
    sealed class DummyCollidableBodies : CollidableBodies
    {
        /// <summary>
        ///     The movement speed for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public float MovementSpeedForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public Body BodyForEntity(Guid entity)
        {
            throw new NotImplementedException();
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
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            throw new NotImplementedException();
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
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public bool BodyIsColliding(Body body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The <see cref="Collision"/> caused by the movement of a given
        ///     <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public Collision CollisionForBody(Body body)
        {
            throw new NotImplementedException();
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
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            throw new NotImplementedException();
        }
    }
}
