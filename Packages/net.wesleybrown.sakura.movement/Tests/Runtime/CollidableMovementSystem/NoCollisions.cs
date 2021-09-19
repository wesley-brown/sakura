using System;
using System.Threading.Tasks;
using Sakura.Client;
using Sakura.Core;
using UnityEngine;

namespace Collidable_Movement_System_Spec
{
    /// <summary>
    ///     A stub test double for a <see cref="CollidableBodies"/> that has
    ///     no <see cref="Collision"/>s.
    /// </summary>
    sealed class NoCollisions : CollidableBodies
    {
        /// <summary>
        ///     Create a new <see cref="NoCollisions"/>.
        /// </summary>
        internal NoCollisions()
        {
            var player = new Guid("0c6cace6-95c3-4c0c-a608-3918818a4a03");
            var playersLocation = new Vector3(0.0f, 0.0f, 0.0f);
            playersBody = Body.ForEntityLocatedAt(
                player,
                playersLocation);
        }

        private readonly Body playersBody;

        /// <summary>
        ///     The single entity that this <see cref="NoCollisions"/> has.
        /// </summary>
        internal Guid Player
        {
            get
            {
                return playersBody.Entity;
            }
        }

        /// <summary>
        ///     The <see cref="Body"/> for <see cref="Player"/>.
        /// </summary>
        internal Body PlayersBody
        {
            get
            {
                return playersBody;
            }
        }

        /// <summary>
        ///     The movement speed for a given entity.
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
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will always be <see cref="PlayersBody"/>.
        /// </returns>
        public Task<Body> BodyForEntity(Guid entity)
        {
            return Task.FromResult(playersBody);
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
        public Task ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            return Task.CompletedTask;
        }
    }
}
