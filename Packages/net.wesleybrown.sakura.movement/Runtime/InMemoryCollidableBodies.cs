using System;
using Sakura.Client;
using Sakura.Core;

namespace Sakura.Data
{
    /// <summary>
    ///     An in-memory <see cref="CollidableBodies"/>.
    /// </summary>
    sealed class InMemoryCollidableBodies : CollidableBodies
    {
        /// <summary>
        ///     Create a <see cref="InMemoryCollidableBodies"/> with a given
        ///     <see cref="MovementSpeeds"/>, <see cref="Bodies"/>, and
        ///     <see cref="Collisions"/>.
        /// </summary>
        /// <param name="movementSpeeds">
        ///     The <see cref="MovementSpeeds"/>.
        /// </param>
        /// <param name="bodies">
        ///     The <see cref="Bodies"/>.
        /// </param>
        /// <param name="collisions">
        ///     The <see cref="Collisions"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="InMemoryCollidableBodies"/> created with the given
        ///     <see cref="MovementSpeeds"/>, <see cref="Bodies"/>, and
        ///     <see cref="Collisions"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="MovementSpeeds"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Bodies"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Collisions"/> is null.
        /// </exception>
        internal static InMemoryCollidableBodies WithCollections(
            MovementSpeeds movementSpeeds,
            Bodies bodies,
            Collisions collisions)
        {
            if (movementSpeeds == null)
                throw new ArgumentNullException(nameof(movementSpeeds));
            if (bodies == null)
                throw new ArgumentNullException(nameof(bodies));
            if (collisions == null)
                throw new ArgumentNullException(nameof(collisions));
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public float MovementSpeedForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Body BodyForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            throw new NotImplementedException();
        }
    }
}
