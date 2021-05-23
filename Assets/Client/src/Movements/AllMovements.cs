using System;

namespace Sakura.Movements
{
    /// <summary>
    ///     A collection of all the movements in the simulation.
    /// </summary>
    public interface AllMovements
    {
        /// <summary>
        ///     Whether or not the entity with a given ID has movement.
        /// </summary>
        /// <param name="entityID">
        ///     The ID of the entity.
        /// </param>
        /// <returns>
        ///     True if the entity with the given ID has movement; false
        ///     otherwise.
        /// </returns>
        bool HasMovement(Guid entityID);

        /// <summary>
        ///     The movement for the entity with a given ID.
        /// </summary>
        /// <param name="entityID">
        ///     The ID of the entity.
        /// </param>
        /// <returns>
        ///     The movement for the entity with the given ID.
        /// </returns>
        Movement For(Guid entityID);
    }
}
