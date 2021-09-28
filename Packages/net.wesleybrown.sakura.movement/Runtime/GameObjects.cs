using System;
using UnityEngine;

namespace Sakura.Data
{
    /// <summary>
    ///     A collection of <see cref="GameObjects"/> and the entities that
    ///     they represent.
    /// </summary>
    public interface GameObjects
    {
        /// <summary>
        ///     Add a given <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="gameObject">
        ///     The <see cref="GameObject"/> to add for the entity.
        /// </param>
        /// <param name="entity">
        ///     The entity to add the <see cref="GameObject"/> for.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="GameObject"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the given <see cref="GameObject"/> is already
        ///     bound to another entity.
        /// </exception>
        void AddGameObjectForEntity(
            GameObject gameObject,
            Guid entity);

        /// <summary>
        ///     The <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The <see cref="GameObject"/> for the given entity, if it has
        ///     one; null otherwise.
        /// </returns>
        GameObject GameObjectForEntity(Guid entity);

        /// <summary>
        ///     The entity for a given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="gameObject">
        ///     The <see cref="GameObject"/>.
        /// </param>
        /// <returns>
        ///     The entity for the given <see cref="GameObject"/>, if it has
        ///     one; <see cref="Guid.Empty"/> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="GameObject"/> is null.
        /// </exception>
        Guid EntityForGameObject(GameObject gameObject);
    }
}
