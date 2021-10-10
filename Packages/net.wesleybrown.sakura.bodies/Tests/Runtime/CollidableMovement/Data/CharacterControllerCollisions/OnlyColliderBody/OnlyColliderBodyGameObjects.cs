using System;
using Sakura.Bodies.Core;
using Sakura.Bodies.CollidableMovement.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="GameObjects"/> for the
    ///     situation where two <see cref="GameObject"/>s collide but only the
    ///     collider has a <see cref="Body"/>.
    /// </summary>
    sealed class OnlyColliderBodyGameObjects : GameObjects
    {
        static OnlyColliderBodyGameObjects()
        {
            collider = new GameObject("Collider");
            collider.SetActive(false);
            collider.transform.position =
                OnlyColliderBodyBodies.Collider.Location;
            collider.AddComponent<CharacterController>();

            collidee = new GameObject("Collidee");
            collidee.SetActive(false);
            collidee.transform.position = new Vector3(2.0f, 0.0f, 0.0f);
            collidee.AddComponent<CharacterController>();
        }

        private static readonly GameObject collider;
        private static readonly GameObject collidee;

        /// <summary>
        ///     The <see cref="GameObject"/> that is the collider in this
        ///     situation.
        /// </summary>
        internal static GameObject Collider
        {
            get
            {
                return collider;
            }
        }

        /// <summary>
        ///     The <see cref="GameObject"/> that is the collidee in this
        ///     situation.
        /// </summary>
        internal static GameObject Collidee
        {
            get
            {
                return collidee;
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
        ///     The <see cref="GameObject"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     <see cref="Collider"/> if the given entity is
        ///     <see cref="OnlyColliderBodyBodies.Collider.Entity"/>;
        ///     <see cref="Collidee"/> otherwise.
        /// </returns>
        public GameObject GameObjectForEntity(Guid entity)
        {
            if (entity == OnlyColliderBodyBodies.Collider.Entity)
                return Collider;
            return Collidee;
        }

        /// <summary>
        ///     The entity for a given <see cref="GameObject"/>.
        /// </summary>
        /// <param name="gameObject">
        ///     The <see cref="GameObject"/>.
        /// </param>
        /// <returns>
        ///     <see cref="OnlyColliderBodyBodies.Collider.Entity"/> if the
        ///     given <see cref="GameObject"/> is <see cref="Collider"/>;
        ///     another <see cref="Guid"/> otherwise.
        /// </returns>
        public Guid EntityForGameObject(GameObject gameObject)
        {
            if (gameObject == Collider)
                return OnlyColliderBodyBodies.Collider.Entity;
            return new Guid("e337da28-5d40-4ca3-b9a6-6546e5addf11");
        }
    }
}
