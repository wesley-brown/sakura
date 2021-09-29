using System;

namespace Sakura.Bodies.CollidableMovement.Data
{
    /// <summary>
	///     A collection of entity movement speeds.
	/// </summary>
    internal interface MovementSpeeds
    {
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
        float MovementSpeedForEntity(Guid entity);
    }
}
