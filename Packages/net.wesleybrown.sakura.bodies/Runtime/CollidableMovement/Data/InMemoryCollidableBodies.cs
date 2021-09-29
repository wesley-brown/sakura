using System;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.CollidableMovement.Data
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
            return new InMemoryCollidableBodies(
                movementSpeeds,
                bodies,
                collisions);
        }

        private InMemoryCollidableBodies(
            MovementSpeeds movementSpeeds,
            Bodies bodies,
            Collisions collisions)
        {
            UnityEngine.Debug.Assert(movementSpeeds != null);
            this.movementSpeeds = movementSpeeds;

            UnityEngine.Debug.Assert(bodies != null);
            this.bodies = bodies;

            UnityEngine.Debug.Assert(collisions != null);
            this.collisions = collisions;
        }

        private readonly MovementSpeeds movementSpeeds;
        private readonly Bodies bodies;
        private readonly Collisions collisions;

        /// <inheritdoc/>
        public float MovementSpeedForEntity(Guid entity)
        {
            return movementSpeeds.MovementSpeedForEntity(entity);
        }

        /// <inheritdoc/>
        public Body BodyForEntity(Guid entity)
        {
            return bodies.BodyForEntity(entity);
        }

        /// <inheritdoc/>
        public void ReplaceEntityBody(
            Guid entity,
            Body body)
        {
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            if (bodies.BodyForEntity(entity) == null)
                throw new NonExistingEntity(entity);
            bodies.AddBody(body);
        }

        /// <inheritdoc/>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            if (movement == null)
                throw new ArgumentNullException(nameof(movement));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            return collisions.CollisionCausedByMovingBody(
                movement,
                body);
        }
    }
}
