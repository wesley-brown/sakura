using System;
using System.Collections.Generic;
using Sakura.Collisions;
using Sakura.Movements.Responses;

namespace Sakura.Movements
{
    /// <summary>
    ///     An attempt to move an entity during the current frame.
    /// </summary>
    public sealed class CurrentFrameMove
    {
        private readonly Guid entityID;
        private readonly AllMovements allMovements;

        /// <summary>
        ///     Create a new current frame move for an entity with a given ID
        ///     using given movements and collisions.
        /// </summary>
        /// <param name="entityID">
        ///     The ID of the entity to move.
        /// </param>
        /// <param name="allMovements">
        ///     All movements in the simulation.
        /// </param>
        /// <param name="allCollisions">
        ///     All collisions in the simulation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given movements are null.
        ///
        ///     -or-
        ///     
        ///     Thrown when the given collisions are null.
        /// </exception>
        public CurrentFrameMove(
            Guid entityID,
            AllMovements allMovements,
            AllCollisions allCollisions)
        {
            this.entityID = entityID;
            if (allMovements == null)
                throw new ArgumentNullException(
                    nameof(allMovements),
                    "The movements must not be null");
            this.allMovements = allMovements;
            if (allCollisions == null)
                throw new ArgumentNullException(
                    nameof(allCollisions),
                    "The collisions must not be null");
        }

        public MoveResponse Response()
        {
            if (EntityHasNilUuid())
                return CannotMoveEntityWithNilUuid();
            else if (WillMove())
                return DidMove();
            else
                return DidNotMove();
        }

        private bool EntityHasNilUuid()
        {
            return entityID == Guid.Empty;
        }

        private bool WillMove()
        {
            return allMovements.HasMovement(entityID);
        }

        private MoveResponse CannotMoveEntityWithNilUuid()
        {
            return new MoveResponse
            {
                Errors = new List<string>
                {
                    "An entity with the nil UUID cannot be moved."
                }
            };
        }

        private MoveResponse DidMove()
        {
            var movement = allMovements.For(entityID);
            var location = movement.Location();
            return new MoveResponse
            {
                DidMove = true,
                NewLocation = new Location
                {
                    X = location.x,
                    Y = location.y,
                    Z = location.z
                }
            };
        }

        private MoveResponse DidNotMove()
        {
            return new MoveResponse();
        }
    }
}
