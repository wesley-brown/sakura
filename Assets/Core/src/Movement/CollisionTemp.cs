using System;
using System.Diagnostics;

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
            return new CollisionTemp(adjustedMovement);
        }

        private CollisionTemp(MovementTemp adjustedMovement)
        {
            Debug.Assert(adjustedMovement != null);
            this.adjustedMovement = adjustedMovement;
        }

        private readonly MovementTemp adjustedMovement;

        /// <summary>
        ///     The adjusted movement for the colliding body after collisions
        ///     are taken into account.
        /// </summary>
        public MovementTemp AdjustedMovement
        {
            get
            {
                return adjustedMovement;
            }
        }

        /// <summary>
        ///     Create a string representation of this collision.
        /// </summary>
        /// <returns>
        ///     A string representation of this collision.
        /// </returns>
        public override string ToString()
        {
            return "{"
                + "AdjustedMovement="
                + AdjustedMovement
                + "}";
        }
    }
}
