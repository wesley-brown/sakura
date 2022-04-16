using System;
using System.Collections.Generic;
using Sakura.Bodies.Core;
using UnityEngine;

namespace Sakura.Bodies.Movements.Gateways
{
    /// <summary>
    ///     A movement system gateway.
    /// </summary>
    internal sealed class Gateway : Creations.Gateway
    {
        /// <summary>
        ///     Create a movement system gateway made of a given dicitonary of
        ///     bodies and dictionary of movements.
        /// </summary>
        /// <param name="bodies">
        ///     The dictionary of bodies.
        /// </param>
        /// <param name="movements">
        ///     The dictionary of movements.
        /// </param>
        /// <returns>
        ///     A movement system gateway made of the given dictionary of
        ///     bodies and movements.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given dictionary of bodies is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given dictionary of movements is null.
        /// </exception>
        internal static Gateway Of(
            IDictionary<Guid, Body> bodies,
            IDictionary<Guid, Movement> movements)
        {
            if (bodies == null)
                throw new ArgumentNullException(nameof(bodies));
            if (movements == null)
                throw new ArgumentNullException(nameof(movements));
            return new Gateway(
                bodies,
                movements);
        }

        private Gateway(
            IDictionary<Guid, Body> bodies,
            IDictionary<Guid, Movement> movements)
        {
            this.bodies = bodies;
            this.movements = movements;
        }

        private readonly IDictionary<Guid, Body> bodies;
        private readonly IDictionary<Guid, Movement> movements;

        #region Creations
        /// <inheritdoc/>
        public Core.Movement Add(
            Core.Movement movement,
            float timestamp,
            Guid entity)
        {
            if (movement == null)
                throw new ArgumentNullException(nameof(movement));
            Debug.Assert(movements != null);
            var hasEntryForEntity = movements.ContainsKey(entity);
            if (!hasEntryForEntity)
            {
                var serializedMovement = new Movement
                {
                    Destination = movement.Destination,
                    MovementSpeed = movement.Speed
                };
                movements.Add(
                    entity,
                    serializedMovement);
            }
            return movement;
        }

        /// <inheritdoc/>
        public Body BodyFor(Guid entity)
        {
            Debug.Assert(bodies != null);
            return bodies.ContainsKey(entity)
                ? bodies[entity]
                : null;
        }
        #endregion
    }
}
