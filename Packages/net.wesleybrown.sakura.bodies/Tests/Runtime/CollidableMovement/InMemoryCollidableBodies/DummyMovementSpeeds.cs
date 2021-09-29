using System;
using Sakura.Bodies.CollidableMovement.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
	/// <summary>
    ///		A dummy test double for a <see cref="MovementSpeeds"/>.
    /// </summary>
    sealed class DummyMovementSpeeds : MovementSpeeds
    {
		/// <summary>
		///     The movement speed for a given entity.
		/// </summary>
		/// <param name="entity">
		///		The entity.
		/// </param>
		/// <returns>
		///		Never returns.
		/// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
		public float MovementSpeedForEntity(Guid entity)
        {
            throw new NotImplementedException();
        }
    }
}
