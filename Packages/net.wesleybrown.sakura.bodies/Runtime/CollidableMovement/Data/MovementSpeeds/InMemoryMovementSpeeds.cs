using System;
using System.Collections.Generic;

namespace Sakura.Bodies.CollidableMovement.Data
{
	/// <summary>
    ///		A <see cref="MovementSpeeds"/> that stores all movement speeds in
    ///		memory.
    /// </summary>
    sealed class InMemoryMovementSpeeds : MovementSpeeds
    {
		/// <summary>
        ///		Create a <see cref="InMemoryMovementSpeeds"/> from a given
        ///		dictionary.
        /// </summary>
        /// <param name="dictionary">
        ///     The dictionary.
        /// </param>
        /// <returns>
        ///     A <see cref="InMemoryMovementSpeeds"/> created from the given
        ///     dictionary.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given dictionary is null.
        /// </exception>
		internal static InMemoryMovementSpeeds From(
			Dictionary<Guid, float> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
			throw new NotImplementedException();
        }

		/// <summary>
		///     The movement speed for a given entity.
		/// </summary>
		/// <param name="entity">
		///		The entity.
		/// </param>
		/// <returns>
		///		The movement speed for the given entity, if it has one;
		///		0.0f otherwise.
		/// </returns>
		public float MovementSpeedForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}
