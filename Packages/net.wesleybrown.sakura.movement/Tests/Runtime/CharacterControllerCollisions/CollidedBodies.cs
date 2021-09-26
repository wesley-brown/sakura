using System;
using Sakura.Core;
using Sakura.Data;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Bodies"/> that always returns
    ///     <see cref="Body"/>s related to a single <see cref="Collision"/>.
    /// </summary>
    sealed class CollidedBodies : Bodies
    {
        /// <summary>
        ///     The collider <see cref="Body"/> of the <see cref="Collision"/>.
        /// </summary>
        internal static Body ColliderBody
        {
            get
            {
                var collider =
                    new Guid("5b6ee82b-7544-464e-adae-3a29333167fb");
                var colliderLocation = new Vector3(0.0f, 0.0f, 0.0f);
                return Body.ForEntityLocatedAt(
                    collider,
                    colliderLocation);
            }
        }

        /// <summary>
        ///     The collidee <see cref="Body"/> of the <see cref="Collision"/>.
        /// </summary>
        internal static Body CollideeBody
        {
            get
            {
                var collidee =
                    new Guid("c3e9de8c-0c3d-4284-9ca8-809fc41f603a");
                var collideeLocation = new Vector3(3.0f, 0.0f, 0.0f);
                return Body.ForEntityLocatedAt(
                    collidee,
                    collideeLocation);
            }
        }

        /// <summary>
        ///     Add a given <see cref="Body"/> to this
        ///     <see cref="CollidedBodies"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to add.
        /// </param>
        public void AddBody(Body body)
        {
            // No-op
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     <see cref="ColliderBody"/> if the given entity is
        ///     <see cref="ColliderBody.Entity"/>; <see cref="CollideeBody"/>
        ///     otherwise.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            if (entity == ColliderBody.Entity)
                return ColliderBody;
            return CollideeBody;
        }
    }
}
