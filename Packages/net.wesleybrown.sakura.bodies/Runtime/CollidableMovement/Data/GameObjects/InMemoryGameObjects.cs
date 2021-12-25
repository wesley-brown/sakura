using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Bodies.CollidableMovement.Data
{
    /// <summary>
    ///     A <see cref="GameObjects"/> that stores all
    ///     <see cref="GameObject"/>s in memory.  
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
            return new InMemoryGameObjects(new Dictionary<Guid, GameObject>());
        }

        /// <summary>
        ///     Create a <see cref="InMemoryGameObjects"/> from a given
        ///     <see cref="Dictionary{TKey, TValue}"/> with keys of type
        ///     <typeparamref name="Guid"/> and values of type
        ///     <typeparamref name="GameObject"/>.
        /// </summary>
        /// <param name="dictionary">
        ///     The <see cref="Dictionary{TKey, TValue}"/> with keys of type
        ///     <typeparamref name="Guid"/> and values of type
        ///     <typeparamref name="GameObject"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="InMemoryGameObjects"/> created from the given
        ///     <see cref="Dictionary{TKey, TValue}"/> with keys of type
        ///     <typeparamref name="Guid"/> and values of type
        ///     <typeparamref name="GameObject"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Dictionary{TKey, TValue}"/>
        ///     with keys of type <typeparamref name="Guid"/> and values of
        ///     type <typeparamref name="GameObject"/> is null.
        /// </exception>
        internal static InMemoryGameObjects From(
            Dictionary<Guid, GameObject> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            return new InMemoryGameObjects(dictionary);
        }

        private InMemoryGameObjects(Dictionary<Guid, GameObject> dictionary)
        {
            Debug.Assert(dictionary != null);
            gameObjects = dictionary;
        }

        private readonly Dictionary<Guid, GameObject> gameObjects;

        /// <inheritdoc/>
        public void AddGameObjectForEntity(
            GameObject gameObject,
            Guid entity)
        {
            if (gameObject == null)
                throw new ArgumentNullException(nameof(gameObject));
            if (gameObjects.ContainsValue(gameObject))
                throw new InvalidOperationException(
                    "The game object '"
                    + gameObject.name
                    + "' is already bound to entity '"
                    + entity
                    + "'.");
            if (gameObjects.ContainsKey(entity))
            {
                gameObjects[entity] = gameObject;
                return;
            }
            gameObjects.Add(
                entity,
                gameObject);
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
            if (gameObject == null)
                throw new ArgumentNullException(nameof(gameObject));
            foreach (var entry in gameObjects)
            {
                if (entry.Value == gameObject)
                    return entry.Key;
            }
            return Guid.Empty;
        }
    }
}
