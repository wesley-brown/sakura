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
        /// <param name="presenter">
        ///     The <see cref="CollidableMovementSystemPresenter"/>.
        /// </param>
        /// <returns>
        ///     A <see cref="CollidableMovementSystem"/> that moves entities
        ///     with the given non-negative speed and collection of collidable
        ///     bodies.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given collection of all bodies is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when the given movement speed is negative.
        /// </exception>
        internal static CollidableMovementSystem
            WithSpeedAndCollidableBodiesAndPresenter(
                float movementSpeed,
                CollidableBodies collidableBodies,
                CollidableMovementSystemPresenter presenter)
        {
            if (movementSpeed < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(movementSpeed),
                    "The given movement speed must be non-negative.");
            if (collidableBodies == null)
                throw new ArgumentNullException(nameof(collidableBodies));
            throw new NotImplementedException();
        }
    }
}
