using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Data
{
    /// <summary>
    ///     A <see cref="GameObjects"/> that stores all
    ///     <see cref="GameObjects"/> in memory.  
    /// </summary>
    sealed class InMemoryGameObjects : GameObjects
    {
        /// <summary>
        ///     Create a <see cref="InMemoryGameObjects"/> that doesn't have
        ///     any <see cref="GameObject"/>s in it.
        /// </summary>
        /// <returns>
        ///     An empty <see cref="InMemoryGameObjects"/>.
        /// </returns>
        internal static InMemoryGameObjects Empty()
        {
            return new InMemoryGameObjects();
        }

        private InMemoryGameObjects()
        {
            gameObjects = new Dictionary<Guid, GameObject>();
        }

        private readonly Dictionary<Guid, GameObject> gameObjects;

        /// <inheritdoc/>
        public void AddGameObjectForEntity(
            GameObject gameObject,
            Guid entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public GameObject GameObjectForEntity(Guid entity)
        {
            if (!gameObjects.ContainsKey(entity))
                return null;
            return gameObjects[entity];
        }

        /// <inheritdoc/>
        public Guid EntityForGameObject(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}
