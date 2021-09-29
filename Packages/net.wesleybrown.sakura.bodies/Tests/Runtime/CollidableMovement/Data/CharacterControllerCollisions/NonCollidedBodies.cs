using System;
using Sakura.Bodies.CollidableMovement.Data;
using Sakura.Bodies.Core;
using UnityEngine;

namespace Character_Controller_Collisions_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Bodies"/> that has two
    ///     <see cref="Body"/>s that are are not involved in a
    ///     <see cref="Collision"/>.
    /// </summary>
    sealed class NonCollidedBodies : Bodies
    {
        /// <summary>
        ///     The <see cref="Body"/> for the player entity.
        /// </summary>
        internal static Body PlayerBody
        {
            get
            {
                var player = new Guid("1444c0ad-9c05-47e6-b4fa-015404fa46d1");
                var playerLocation = new Vector3(0.0f, 0.0f, 0.0f);
                return Body.ForEntityLocatedAt(
                    player,
                    playerLocation);
            }
        }

        /// <summary>
        ///     The <see cref="Body"/> for the enemy entity.
        /// </summary>
        internal static Body EnemyBody
        {
            get
            {
                var enemy = new Guid("c4494c79-181c-41b3-9e7f-6b98543eb96b");
                var enemyLocation = new Vector3(10.0f, 0.0f, 0.0f);
                return Body.ForEntityLocatedAt(
                    enemy,
                    enemyLocation);
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
            //No-op
        }

        /// <summary>
        ///     The <see cref="Body"/> for a given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     <see cref="PlayerBody"/> if the given entity is
        ///     <see cref="PlayerBody.Entity"/>; <see cref="EnemyBody"/>
        ///     otherwise.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            if (entity == PlayerBody.Entity)
                return PlayerBody;
            return EnemyBody;
        }
    }
}
