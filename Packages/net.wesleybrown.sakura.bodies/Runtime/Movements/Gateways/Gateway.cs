using System;
using System.Collections.Generic;
using Sakura.Bodies.Core;

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
            this.movements = movements;
        }

        private readonly IDictionary<Guid, Movement> movements;

        #region Creations
        /// <inheritdoc/>
        public Movement Add(
            Movement movement,
            float timestamp,
            Guid entity)
        {
            if (movement == null)
                throw new ArgumentNullException(nameof(movement));
            try
            {
                movements.Add(
                    entity,
                    movement);
            }
            catch (ArgumentException)
            {
                throw new NotImplementedException();
            }
            return movement;
        }

        /// <inheritdoc/>
        public Body BodyFor(Guid entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
