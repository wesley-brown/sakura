using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Sakura.Client
{
    /// <summary>
    ///     A system that moves entities.
    /// </summary>
    public interface MovementSystem
    {
        /// <summary>
        ///     Move a given entity one tick towards a given destination.
        /// </summary>
        /// <param name="entity">
        ///     The entity to move.
        /// </param>
        /// <param name="destination">
        ///     The destination to move the entity towards.
        /// </param>
        /// <returns>
        ///     A task representing the asychronous operation.
        /// </returns>
        Task MoveEntityTowardsDestination(
            Guid entity,
            Vector3 destination);
    }
}
