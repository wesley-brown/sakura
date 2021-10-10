using System;
using Sakura.Bodies.CollidableMovement.Data;
using Sakura.Bodies.Core;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Bodies"/> for the situation
    ///     where two <see cref="GameObject"/>s collide but only the collider
    ///     has a <see cref="Body"/>.
    /// </summary>
    sealed class OnlyColliderBodyBodies : Bodies
    {
        internal static Body Collider
        {
            get
            {
                var collider =
                    new Guid("1d169819-a97b-4719-865e-756a08ea9fad");
                var colliderLocation = new Vector3(0.0f, 0.0f, 0.0f);
                return Body.ForEntityLocatedAt(
                    collider,
                    colliderLocation);
            }
        }

        /// <inheritdoc/>
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
        ///     <see cref="Collider"/> if the given entity is
        ///     <see cref="Collider.Entity"/>, null otherwise.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            if (entity == Collider.Entity)
                return Collider;
            return null;
        }
    }
}
