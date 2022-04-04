using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.Movements.Creations;

namespace Movement_Creation_System_Spec.Gateways
{
    /// <summary>
    ///     A stub test double for a movement creation system gateway that
    ///     has no bodies to return.
    /// </summary>
    internal sealed class NoBodies : Gateway
    {
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
            throw new Exception();
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
            return null;
        }
    }
}
