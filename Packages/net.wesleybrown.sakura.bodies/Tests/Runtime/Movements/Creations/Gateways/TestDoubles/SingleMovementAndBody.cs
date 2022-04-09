using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.Movements.Creations;

namespace Movement_Creation_System_Spec.Gateways
{
    /// <summary>
    ///     A stub test double for a movement creation system gateway that
    ///     has a single movement and body that it always returns.
    /// </summary>
    internal sealed class SingleMovementAndBody : Gateway
    {
        /// <summary>
        ///     The body this movement creation system gateway always has.
        /// </summary>
        internal Body Body
        {
            get
            {
                return Body.ForEntityLocatedAt(
                    new Guid("d6c2d714-03bb-4a47-89cc-3dc4c563f936"),
                    UnityEngine.Vector3.zero);
            }
        }

        /// <summary>
        ///     The movement that this movement creation system always
        ///     creates.
        /// </summary>
        internal Movement Movement
        {
            get
            {
                return Movement.TowardsDestinationWithSpeed(
                    UnityEngine.Vector3.zero,
                    5.0f);
            }
        }

        /// <summary>
        ///     Add a given movement at a given timestamp as a given entity's
        ///     movement.
        /// </summary>
        /// <param name="movement">
        ///     The movement to add for the given entity.
        /// </param>
        /// <param name="timestamp">
        ///     The timestamp of the movement to add.
        /// </param>
        /// <param name="entity">
        ///     The entity to add the given movement for.
        /// </param>
        /// <returns>
        ///     The added movement.
        /// </returns>
        public Movement Add(
            Movement movement,
            float timestamp,
            Guid entity)
        {
            return Movement;
        }

        /// <summary>
        ///     The body for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The body for the given entity if one exists; null otherwise.
        /// </returns>
        public Body BodyFor(Guid entity)
        {
            return Body;
        }
    }
}
