using System;
using System.Threading.Tasks;
using Sakura.Client;
using Sakura.Core;
using UnityEngine;

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
            var playersLocation = new Vector3(0.0f, 0.0f, 0.0f);
            playersBody = Body.ForEntityLocatedAt(
                player,
                playersLocation);
            var enemy = new Guid("c15f7c57-f638-4cda-8a1c-07889d03d4f0");
            var enemysLocation = new Vector3(3.5f, 0.0f, 3.5f);
            enemysBody = Body.ForEntityLocatedAt(
                enemy,
                enemysLocation);
            var adjustedPlayersLocation = new Vector3(3.0f, 0.0f, 3.0f);
            var adjustedPlayersBody = Body.ForEntityLocatedAt(
                player,
                adjustedPlayersLocation);
            playersCollision = Sakura.Core.Collision.BetweenBodies(
                adjustedPlayersBody,
                enemysBody);
        }

        private readonly Body playersBody;
        private readonly Body enemysBody;
        private readonly Sakura.Core.Collision playersCollision;

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
        public Vector3 AdjustedCollisionLocation
        {
            get
            {
                return new Vector3(3.0f, 0.0f, 3.0f);
            }
        }

        /// <summary>
        ///     The <see cref="Collision"/> that <see cref="Player"/> will
        ///     always be involved in.
        /// </summary>
        public Sakura.Core.Collision PlayersCollision
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
        ///     A task representing the asynchronous operation.
        ///     The task result will be always be <see cref="PlayersBody"/>.
        /// </returns>
        public Task<Body> BodyForEntity(Guid entity)
        {
            return Task.FromResult(playersBody);
        }

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will always be 5.0f.
        /// </returns>
        public Task<float> MovementSpeedForEntity(Guid entity)
        {
            return Task.FromResult(5.0f);
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
        /// <returns>
        ///     A task representing the asynchronous operation.
        /// </returns>
        public Task ReplaceEntityBody(Guid entity, Body body)
        {
            return Task.CompletedTask;
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
        ///     A task representing the asynchronous opeartion.
        ///     The task result will always be true.
        /// </returns>
        public Task<bool> BodyIsColliding(Body body)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     The <see cref="Collision"/> caused by the movement of a given
        ///     <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will always be <see cref="PlayerCollision"/>.
        /// </returns>
        public Task<Sakura.Core.Collision> CollisionForBody(Body body)
        {
            return Task.FromResult(PlayersCollision);
        }
    }
}
