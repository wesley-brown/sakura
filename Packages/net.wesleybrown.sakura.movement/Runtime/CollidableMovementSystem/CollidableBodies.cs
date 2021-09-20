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
        ///     The movement speed for the given entity.
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
        void ReplaceEntityBody(
            Guid entity,
            Body body);

        /// <summary>
        ///     Whether or not a given <see cref="Body"/> is currently
        ///     colliding with another <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/> to check for <see cref="Collision"/>s
        ///     for.
        /// </param>
        /// <returns>
        ///     True if the given <see cref="Body"/> is colliding with another
        ///     <see cref="Body"/>; false otherwise.
        /// </returns>
        bool BodyIsColliding(Body body);

        /// <summary>
        ///     The <see cref="Collision"/> caused by the movement of a given
        ///     <see cref="Body"/>.
        /// </summary>
        /// <param name="body">
        ///     The <see cref="Body"/>.
        /// </param>
        /// <returns>
        ///     The <see cref="Collision"/> caused by the movement of the given
        ///     <see cref="Body"/>.
        /// </returns>
        Collision CollisionForBody(Body body);
    }
}
