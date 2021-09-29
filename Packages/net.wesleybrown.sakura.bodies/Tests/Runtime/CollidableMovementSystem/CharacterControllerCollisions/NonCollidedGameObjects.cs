using System;
using Sakura.Bodies.CollidableMovement.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Collisions"/> that has two
    ///     <see cref="GameObject"/>s that are not involved in a
    ///     <see cref="Collision"/>.
    /// </summary>
    sealed class NonCollidedGameObjects : GameObjects
    {
        static NonCollidedGameObjects()
        {
            playerGameObject = new GameObject("Player");
            playerGameObject.SetActive(false);
            playerGameObject.transform.position =
                NonCollidedBodies.PlayerBody.Location;
            playerGameObject.AddComponent<CharacterController>();

            enemyGameObject = new GameObject("Enemy");
            enemyGameObject.SetActive(false);
            enemyGameObject.transform.position =
                NonCollidedBodies.EnemyBody.Location;
            enemyGameObject.AddComponent<CharacterController>();
        }

        private static readonly GameObject playerGameObject;
        private static readonly GameObject enemyGameObject;

        /// <summary>
        ///     The <see cref="GameObject"/> of the player that is not involved
        ///     in any collisions.
        /// </summary>
        internal static GameObject PlayerGameObject
        {
            get
            {
                return playerGameObject;
            }
        }

        /// <summary>
        ///     The <see cref="GameObject"/> of the enemy that is not involved
        ///     in any collisions.
        /// </summary>
        internal static GameObject EnemyGameObject
        {
            get
            {
                return enemyGameObject;
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
        ///     <see cref="NonCollidedBodies.PlayerBody.Entity"/> if the
        ///     given <see cref="GameObject"/> is
        ///     <see cref="PlayerGameObject"/>;
        ///     <see cref="NonCollidedBodies.EnemyBody.Entity"/>
        ///     otherwise.
        /// </returns>
        public Guid EntityForGameObject(GameObject gameObject)
        {
            if (gameObject == PlayerGameObject)
                return NonCollidedBodies.PlayerBody.Entity;
            return NonCollidedBodies.EnemyBody.Entity;
        }

        /// <summary>
        ///     The <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     <see cref="PlayerGameObject"/> if the given entity is 
        ///     <see cref="NonCollidedBodies.PlayerBody.Entity"/>; 
        ///     <see cref="EnemyGameObject"/> otherwise.
        /// </returns>
        public GameObject GameObjectForEntity(Guid entity)
        {
            if (entity == NonCollidedBodies.PlayerBody.Entity)
                return PlayerGameObject;
            return EnemyGameObject;
        }
    }
}
