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
        ///     <see cref="CollidableBodies"/> and
        ///     <see cref="CollidableMovementSystemPresenter"/>.
        /// </summary>
        /// <param name="collidableBodies">
        ///     The <see cref="CollidableBodies"/>.
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
        internal static CollidableMovementSystem
            WithCollidableBodiesAndPresenter(
                CollidableBodies collidableBodies,
                CollidableMovementSystemPresenter presenter)
        {
            if (collidableBodies == null)
                throw new ArgumentNullException(nameof(collidableBodies));
            throw new NotImplementedException();
        }
    }
}
