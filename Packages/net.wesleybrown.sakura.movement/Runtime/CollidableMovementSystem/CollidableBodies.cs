using System;
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
        ///     The movement speed for the given entity, if it has one; 0.0f
        ///     otherwise.
        /// </returns>
        float MovementSpeedForEntity(Guid entity);

        /// <summary>
        ///     The <see cref="Body"/> for the given entity.
        /// </summary>
        /// <param name="entity">
        ///     The entity.
        /// </param>
        /// <returns>
        ///     The <see cref="Body"/> of the given entity, if there is one;
        ///     null otherwise.
        /// </returns>
        Body BodyForEntity(Guid entity);

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
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Body"/> is null.
        /// </exception>
        void ReplaceEntityBody(
            Guid entity,
            Body body);

        /// <summary>
        ///     The <see cref="Collision"/>, if any, caused by applying a given
        ///     <see cref="Movement"/> to a given <see cref="Body"/>.
        /// </summary>
        /// <param name="movement">
        ///     The <see cref="Movement"/> to apply to the <see cref="Body"/>.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to apply the <see cref="Movement"/> to.
        /// </param>
        /// <returns>
        ///     The <see cref="Collision"/>, if any, caused by applying the
        ///     given <see cref="Movement"/> to the given <see cref="Body"/>;
        ///     null otherwise.
        /// </returns>
        Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body);
    }
}
