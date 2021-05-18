using System;

namespace Sakura.Client
{
    /// <summary>
    ///     An attempt to move during the current frame.
    /// </summary>
    public sealed class CurrentFrameMove
    {
        /// <summary>
        ///     Create a new current frame move using given movements and
        ///     collisions.
        /// </summary>
        /// <param name="allMovements">
        ///     All movements in the simulation.
        /// </param>
        /// <param name="allCollisions">
        ///     All collisions in the simulation.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collisions are null.
        /// </exception>
        public CurrentFrameMove(
            AllMovements allMovements,
            AllCollisions allCollisions)
        {
            if (allCollisions == null)
                throw new ArgumentNullException(
                    nameof(allCollisions),
                    "The collisions must not be null");
        }
    }
}
 