using System;
using System.Threading.Tasks;
using Sakura.Core;

namespace Sakura.Client
{
    /// <summary>
    ///     A collection of entity movement speeds, <see cref="Collision"/>s,
    ///     and <see cref="Body"/>s.
    /// </summary>
    internal interface CollidableBodies
    {
        /// <summary>
        ///     The movement speed for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will be the movement speed for the given
        ///     entity.
        /// </returns>
        Task<float> MovementSpeedForEntity(Guid entity);

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     A task representing the asynchronous operation.
        ///     The task result will be the <see cref="Body"/> of the given
        ///     entity.
        /// </returns>
        Task<Body> BodyForEntity(Guid entity);

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
        Task ReplaceEntityBody(
            Guid entity,
            Body body);
    }
}
