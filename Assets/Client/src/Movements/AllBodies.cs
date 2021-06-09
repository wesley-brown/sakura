using System;

namespace Sakura.Movements
{
    /// <summary>
    ///     A collection of all bodies in the simulation.
    /// </summary>
    public interface AllBodies
    {
        /// <summary>
        ///     Whether or not there is a body for an entity with a given ID
        ///     in the simulation.
        /// </summary>
        /// <param name="entityID">
        ///     The ID of the entity.
        /// </param>
        /// <returns>
        ///     True if there is a body for the entity with the given ID in the
        ///     simulation; false otherwise.
        /// </returns>
        bool HasBodyFor(Guid entityID);

        /// <summary>
        ///     Add a given body to the collection of all bodies.
        /// </summary>
        /// <param name="body">
        ///     The body to add.
        /// </param>
        void Add(Body body);

        /// <summary>
        ///     The body for the entity with a given ID.
        /// </summary>
        /// <param name="entityID">
        ///     The ID of the entity.
        /// </param>
        /// <returns>
        ///     The body for the entity with the given ID.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the entity with the given ID has no body.
        /// </exception>
        Body For(Guid entityID);
    }
}
