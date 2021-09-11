using System;

namespace Sakura.Core
{
    /// <summary>
    ///     An instance of one body trying to occupy the same space as another
    ///     after moving.
    /// </summary>
    public sealed class CollisionTemp
    {
        /// <summary>
        ///     Create a collision with a given adjustd movement towards a 
        ///     given body.
        /// </summary>
        /// <param name="adjustedMovement">
        ///     The adjusted movement.
        /// </param>
        /// <param name="body">
        ///     The body the adjusted movement is towards.
        /// </param>
        /// <returns>
        ///     A collision with the given adjusted movement towards the given
        ///     body.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given adjusted movement is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given body is null.
        /// </exception>
        public static CollisionTemp WithAdjustedMovementTowardsBody(
            MovementTemp adjustedMovement,
            BodyTemp body)
        {
            if (adjustedMovement == null)
                throw new ArgumentNullException(nameof(adjustedMovement));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            throw new NotImplementedException();
        }
    }
}
