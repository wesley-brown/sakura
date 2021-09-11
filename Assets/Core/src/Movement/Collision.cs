using System;
using System.Diagnostics;

namespace Sakura.Core
{
    /// <summary>
    ///     An instance of one body trying to occupy the same space as another
    ///     after moving.
    /// </summary>
    public sealed class Collision
    {
        /// <summary>
        ///     Create a <see cref="Collision"/> with a given adjusted
        ///     <see cref="Movement"/> towards a given body.
        /// </summary>
        /// <param name="adjustedMovement">
        ///     The adjusted <see cref="Movement"/>.
        /// </param>
        /// <param name="body">
        ///     The body the adjusted <see cref="Movement"/> is towards.
        /// </param>
        /// <returns>
        ///     A <see cref="Collision"/> with the given adjusted
        ///     <see cref="Movement"/> towards the given body.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given adjusted <see cref="Movement"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given body is null.
        /// </exception>
        public static Collision WithAdjustedMovementTowardsBody(
            Movement adjustedMovement,
            BodyTemp body)
        {
            if (adjustedMovement == null)
                throw new ArgumentNullException(nameof(adjustedMovement));
            if (body == null)
                throw new ArgumentNullException(nameof(body));
            return new Collision(adjustedMovement);
        }

        private Collision(Movement adjustedMovement)
        {
            Debug.Assert(adjustedMovement != null);
            this.adjustedMovement = adjustedMovement;
        }

        private readonly Movement adjustedMovement;

        /// <summary>
        ///     The adjusted <see cref="Movement"/> for the colliding body
        ///     after collisions are taken into account.
        /// </summary>
        public Movement AdjustedMovement
        {
            get
            {
                return adjustedMovement;
            }
        }

        /// <summary>
        ///     Create a string representation of this
        ///     <see cref="Collision"/>.
        /// </summary>
        /// <returns>
        ///     A string representation of this <see cref="Collision"/>.
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
