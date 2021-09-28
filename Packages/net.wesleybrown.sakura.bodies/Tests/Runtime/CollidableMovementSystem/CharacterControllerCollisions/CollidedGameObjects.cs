using System;
using Sakura.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Collisions"/> that has only
    ///     the <see cref="GameObjects"/> involved in a single
    ///     <see cref="Collision"/>.
    /// </summary>
    sealed class CollidedGameObjects : GameObjects
    {
        static CollidedGameObjects()
        {
            colliderGameObject = new GameObject("Collider");
            colliderGameObject.SetActive(false);
            colliderGameObject.transform.position =
                CollidedBodies.ColliderBody.Location;
            colliderGameObject.AddComponent<CharacterController>();

            collideeGameObject = new GameObject("Collidee");
            collideeGameObject.SetActive(false);
            collideeGameObject.transform.position =
                CollidedBodies.CollideeBody.Location;
            collideeGameObject.AddComponent<CharacterController>();
        }

        private static readonly GameObject colliderGameObject;
        private static readonly GameObject collideeGameObject;

        /// <summary>
        ///     The <see cref="GameObject"/> of the collider involved in the
        ///     <see cref="Collision"/>.
        /// </summary>
        internal static GameObject ColliderGameObject
        {
            get
            {
                return colliderGameObject;
            }
        }

        /// <summary>
        ///     The <see cref="GameObject"/> of the collidee involved in the
        ///     <see cref="Collision"/>.
        /// </summary>
        internal static GameObject CollideeGameObject
        {
            get
            {
                return collideeGameObject;
            }
        }

        /// <summary>
        ///     Add a given <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="gameObject">
        ///     The <see cref="GameObject"/> to add for the entity.
        /// </param>
        /// <param name="entity">
        ///     The entity to add the <see cref="GameObject"/> for.
        /// </param>
        public void AddGameObjectForEntity(
            GameObject gameObject,
            Guid entity)
        {
            // No-op
        }

        /// <summary>
        ///     The entity for a given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="entity">
        ///     The <see cref="GameObject"/>.
        /// </param>
        /// <returns>
        ///     <see cref="CollidedBodies.ColliderBody.Entity"/> if the
        ///     given <see cref="GameObject"/> is
        ///     <see cref="ColliderGameObject"/>;
        ///     <see cref="CollidedBodies.CollideeBody.Entity"/>
        ///     otherwise.
        /// </returns>
        public Guid EntityForGameObject(GameObject gameObject)
        {
            if (gameObject == ColliderGameObject)
                return CollidedBodies.ColliderBody.Entity;
            return CollidedBodies.CollideeBody.Entity;
        }

        /// <summary>
        ///     The <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     <see cref="ColliderGameObject"/> if the given entity is 
        ///     <see cref="CollidedBodies.ColliderBody.Entity"/>; 
        ///     <see cref="CollideeGameObject"/> otherwise.
        /// </returns>
        public GameObject GameObjectForEntity(Guid entity)
        {
            if (entity == CollidedBodies.ColliderBody.Entity)
                return ColliderGameObject;
            return CollideeGameObject;
        }
    }
}
