﻿using System;
using System.Runtime.CompilerServices;
using Sakura.Core;
using UnityEngine;

[assembly: InternalsVisibleTo("Sakura.Movement.Tests")]
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
            collidableBodies.ReplaceEntityBody(
                entity,
                movedBody);
            var movedBodyIsColliding =
                collidableBodies.BodyIsColliding(movedBody);
            if (movedBodyIsColliding)
                PresentCollisionResolvedLocationOf(movedBody);
            else
                PresentLocationOf(movedBody);
        }

        private void PresentCollisionResolvedLocationOf(Body body)
        {
            Debug.Assert(body != null);
            var collision = collidableBodies.CollisionForBody(body);
            var adjustedBody = collision.Collider;
            var collidableMovement = new CollidableMovement
            {
                EndingLocation = adjustedBody.Location
            };
            presenter.Present(collidableMovement);
        }

        private void PresentLocationOf(Body body)
        {
            Debug.Assert(body != null);
            var collidableMovement = new CollidableMovement
            {
                EndingLocation = body.Location
            };
            presenter.Present(collidableMovement);
        }
    }
}
