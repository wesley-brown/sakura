using System;
using Sakura.Client;
using Sakura.Core;

namespace Collidable_Movement_System_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="CollidableBodies"/> that
    ///     always has collisions.
    /// </summary>
    sealed class AlwaysCollisions : CollidableBodies
    {
        /// <summary>
        ///     Create a new <see cref="AlwaysCollisions"/>.
        /// </summary>
        internal AlwaysCollisions()
        {
            var player = new Guid("5905dcc6-f59d-4a96-85c0-2b2e1da02ec8");
            var playersLocation = new UnityEngine.Vector3(0.0f, 0.0f, 0.0f);
            playersBody = Body.ForEntityLocatedAt(
                player,
                playersLocation);
            var enemy = new Guid("c15f7c57-f638-4cda-8a1c-07889d03d4f0");
            var enemysLocation = new UnityEngine.Vector3(3.5f, 0.0f, 3.5f);
            enemysBody = Body.ForEntityLocatedAt(
                enemy,
                enemysLocation);
            var adjustedPlayersLocation =
                new UnityEngine.Vector3(3.0f, 0.0f, 3.0f);
            var adjustedPlayersBody = Body.ForEntityLocatedAt(
                player,
                adjustedPlayersLocation);
            playersCollision = Collision.BetweenBodies(
                adjustedPlayersBody,
                enemysBody);
        }

        private readonly Body playersBody;
        private readonly Body enemysBody;
        private readonly Collision playersCollision;

        /// <summary>
        ///     The single entity that this <see cref="AlwaysCollisions"/>
        ///     will have <see cref="Collision"/>s for.
        /// </summary>
        public Guid Player
        {
            get
            {
                return playersBody.Entity;
            }
        }

        /// <summary>
        ///     The <see cref="Body"/> of <see cref="Player"/>.
        /// </summary>
        public Body PlayersBody
        {
            get
            {
                return playersBody;
            }
        }

        /// <summary>
        ///     The adjusted location for <see cref="Player"/> after
        ///     <see cref="Collision"/>s are resolved.
        /// </summary>
        public UnityEngine.Vector3 AdjustedCollisionLocation
        {
            get
            {
                return new UnityEngine.Vector3(3.0f, 0.0f, 3.0f);
            }
        }

        /// <summary>
        ///     The <see cref="Collision"/> that <see cref="Player"/> will
        ///     always be involved in.
        /// </summary>
        public Collision PlayersCollision
        {
            get
            {
                return playersCollision;
            }
        }

        /// <summary>
        ///     The movement speed for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns <see cref="PlayersBody"/>.
        /// </returns>
        public Body BodyForEntity(Guid entity)
        {
            return playersBody;
        }

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     Always returns 5.0f.
        /// </returns>
        public float MovementSpeedForEntity(Guid entity)
        {
            return 5.0f;
        }

        /// <summary>
        ///    Replace the <see cref="Body"/> that currently represents a
        ///    given entity with a given <see cref="Body"/>.
        /// </summary>
        /// <param name="entity">
        ///     The entity to replace the <see cref="Body"/> of.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to replace the given entity's
        ///     <see cref="Body"/> with.
        /// </param>
        public void ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            // No-op
        }

        /// <summary>
        ///     Whether or not a given <see cref="Body"/> is currently
        ///     colliding with another <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to check for <see cref="Collision"/>s
        ///     for.
        /// </param>
        /// <returns>
        ///     Always returns true.
        /// </returns>
        public bool BodyIsColliding(Body body)
        {
            return true;
        }

        /// <summary>
        ///     The <see cref="Collision"/> caused by the movement of a given
        ///     <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     Aways returns <see cref="PlayerCollision"/>.
        /// </returns>
        public Collision CollisionForBody(Body body)
        {
            return PlayersCollision;
        }
    }
}
