using System;
using Sakura.Core;
using UnityEngine;

namespace Sakura.Client
{
    /// <summary>
    ///     A <see cref="MovementSystem"/> that checks for and resolves
    ///     collisions while moving entities.
    /// </summary>
    sealed class CollidableMovementSystem : MovementSystem
    {
        /// <summary>
        ///     Create a <see cref="CollidableMovementSystem"/> with a given
        ///     <see cref="CollidableBodies"/> and
        ///     <see cref="CollidableMovementSystemPresenter"/>.
        /// </summary>
        /// <param name="collidableBodies">
        ///     The <see cref="CollidableBodies"/>.
        /// </param>
        /// <param name="presenter">
        ///     The <see cref="CollidableMovementSystemPresenter"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="CollidableMovementSystem"/> that moves entities
        ///     with the given non-negative speed and collection of collidable
        ///     bodies.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="CollidableBodies"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given
        ///     <see cref="CollidableMovementSystemPresenter"/> is null.
        /// </exception>
        internal static CollidableMovementSystem
            WithCollidableBodiesAndPresenter(
                CollidableBodies collidableBodies,
                CollidableMovementSystemPresenter presenter)
        {
            if (collidableBodies == null)
                throw new ArgumentNullException(nameof(collidableBodies));
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));
            return new CollidableMovementSystem(
                collidableBodies,
                presenter);
        }

        private CollidableMovementSystem(
            CollidableBodies collidableBodies,
            CollidableMovementSystemPresenter presenter)
        {
            this.collidableBodies = collidableBodies;
            this.presenter = presenter;
        }

        private readonly CollidableBodies collidableBodies;
        private readonly CollidableMovementSystemPresenter presenter;

        /// <inheritdoc/>
        public void MoveEntityTowardsDestination(
            Guid entity,
            Vector3 destination)
        {
            var body = collidableBodies.BodyForEntity(entity);
            if (body == null)
            {
                presenter.ReportError(
                    "The entity '"
                    + entity
                    + "' does not have a body.");
                return;
            }
            var speed = collidableBodies.MovementSpeedForEntity(entity);
            var movement = Movement.TowardsDestinationWithSpeed(
                destination,
                speed);
            var movedBody = movement.Move(body);
            var collision = collidableBodies.CollisionCausedByMovingBody(
                movement,
                body);
            if (collision != null)
                movedBody = collision.Collider;
            collidableBodies.ReplaceEntityBody(
                entity,
                movedBody);
            var collidableMovement = new CollidableMovement
            {
                EndingLocation = movedBody.Location
            };
            presenter.Present(collidableMovement);
        }
    }
}
