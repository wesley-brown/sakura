using System;
using System.Threading.Tasks;
using Sakura.Client;
using Sakura.Core;

namespace Collidable_Movement_System_Spec
{
    sealed class NoCollidableBodies : CollidableBodies
    {
        /// <summary>
        ///     The movement speed for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will always be 0f.
        /// </returns>
        public Task<float> MovementSpeedForEntity(Guid entity)
        {
            return Task.FromResult(0f);
        }

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will be always be null.
        /// </returns>
        public Task<Body> BodyForEntity(Guid entity)
        {
            return Task.FromResult<Body>(null);
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
        ///     The task result will always be false.
        /// </returns>
        public Task<bool> BodyIsColliding(Body body)
        {
            return Task.FromResult(false);
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
        ///     The task result will always be null.
        /// </returns>
        public Task<Collision> CollisionForBody(Body body)
        {
            return Task.FromResult<Collision>(null);
        }
    }
}
