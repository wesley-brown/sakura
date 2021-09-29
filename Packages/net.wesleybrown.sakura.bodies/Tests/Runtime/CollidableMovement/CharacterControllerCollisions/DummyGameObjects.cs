using System;
using Sakura.Bodies.CollidableMovement.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="GameObjects"/>.
    /// </summary>
    sealed class DummyGameObjects : GameObjects
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
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void AddGameObjectForEntity(
            GameObject gameObject,
            Guid entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public Guid EntityForGameObject(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The entity for a given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="gameObject">
        ///     The <see cref="GameObject"/>.
        /// </param>
        /// <returns>
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public GameObject GameObjectForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}
