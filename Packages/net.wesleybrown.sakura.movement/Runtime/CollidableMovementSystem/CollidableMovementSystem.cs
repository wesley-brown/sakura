using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Sakura.Movement.Tests")]
namespace Sakura.Client
{
    /// <summary>
    ///     A <see cref="MovementSystem"/> that checks for and resolves
    ///     collisions while moving entities.
    /// </summary>
    sealed class CollidableMovementSystem : MovementSystem
    {
        /// <summary>
        ///     Create a <see cref="CollidableMovementSystem"/> with a given
        ///     non-negative movement speed and collection of collidable
        ///     bodies.
        /// </summary>
        /// <param name="movementSpeed">
        ///     The non-negative movement speed to move entities with.
        /// </param>
        /// <param name="collidableBodies">
        ///     The collection of collidable bodies.
        /// </param>
        /// <returns>
        ///     A <see cref="CollidableMovementSystem"/> that moves entities
        ///     with the given non-negative speed and collection of collidable
        ///     bodies.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the given movement speed is negative.
        /// </exception>
        internal static CollidableMovementSystem WithSpeedAndCollidableBodies(
            float movementSpeed,
            CollidableBodies collidableBodies)
        {
            if (movementSpeed < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(movementSpeed),
                    "The given movement speed must be non-negative.");
            throw new NotImplementedException();
        }
    }
}
