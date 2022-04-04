using System;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     The gateway for a movement creation system.
    /// </summary>
    internal interface Gateway
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
        Movement Add(
            Movement movement,
            float timestamp,
            Guid entity);

        /// <summary>
        ///     The body for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The body for the given entity if one exists; null otherwise.
        /// </returns>
        Body BodyFor(Guid entity);
    }
}
