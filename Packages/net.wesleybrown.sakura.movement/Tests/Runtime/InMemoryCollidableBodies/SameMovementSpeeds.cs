using System;
using Sakura.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
	/// <summary>
    ///		A <see cref="MovementSpeeds"/> that always returns a movement
    ///		speed of 5.0f for every entity.
    /// </summary>
    sealed class SameMovementSpeeds : MovementSpeeds
    {
        /// <summary>
        ///     The movement speed that is always returned for every entity.
        /// </summary>
		public static float MovementSpeed
        {
            get
            {
                return 5.0f;
            }
        }

		/// <summary>
		///     The movement speed for a given entity.
		/// </summary>
		/// <param name="entity">
		///		The entity.
		/// </param>
		/// <returns>
		///		Always returns 5.0f.
		/// </returns>
		public float MovementSpeedForEntity(Guid entity)
        {
			return 5.0f;
        }
    }
}