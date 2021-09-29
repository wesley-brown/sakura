using System;
using Sakura.Core;
using Sakura.Bodies.CollidableMovement.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="Collisions"/> that only ever
    ///     has a single <see cref="Collision"/>.
    /// </summary>
    internal sealed class SingleCollision : Collisions
    {
        /// <summary>
        ///     The single <see cref="Collision"/> that this
        ///     <see cref="SingleCollision"/> always has.
        /// </summary>
        internal static Collision Collision
        {
            get
            {
                var collider =
                    new Guid("8e0a7408-978d-4701-9d4c-19cbe5b89632");
                var colliderLocation =
                    new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
                var colliderBody = Body.ForEntityLocatedAt(
                    collider,
                    colliderLocation);

                var collidee =
                    new Guid("2cf4ff7c-7ece-4c88-a933-bc3353f6bff7");
                var collideeLocation =
                    new UnityEngine.Vector3(1.0f, 0.0f, 0.0f);
                var collideeBody = Body.ForEntityLocatedAt(
                    collidee,
                    collideeLocation);

                return Collision.BetweenBodies(
                    colliderBody,
                    collideeBody);
            }
        }

        /// <summary>
        ///     The <see cref="Collision"/> caused by moving a given
        ///     <see cref="Body"/> with a given <see cref="Movement"/>.
        /// </summary>
        /// <param name="movement">
        ///     The <see cref="Movement"/> to move the <see cref="Body"/>
        ///     with.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to move with the <see cref="Movement"/>.
        /// </param>
        /// <returns>
        ///     Always returns <see cref="Collision"/>.
        /// </returns>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            return Collision;
        }
    }
}
