using System;
using Sakura.Bodies.CollidableMovement.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
	/// <summary>
    ///		A <see cref="MovementSpeeds"/> that doesn't have any movement
    ///		speeds for any entity.
    /// </summary>
    sealed class NoMovementSpeeds : MovementSpeeds
    {
		/// <summary>
		///     The movement speed for a given entity.
		/// </summary>
		/// <param name="entity">
		///		The entity.
		/// </param>
		/// <returns>
		///		Always returns 0.0f.
		/// </returns>
		public float MovementSpeedForEntity(Guid entity)
        {
			return 0.0f;
        }
    }
}
