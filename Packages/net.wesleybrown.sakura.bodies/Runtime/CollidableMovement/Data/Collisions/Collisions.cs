using System;
using Sakura.Bodies.Core;

namespace Sakura.Bodies.CollidableMovement.Data
{
    /// <summary>
	///     A collection of <see cref="Collision"/>s.
	/// </summary>
    internal interface Collisions
    {
        /// <summary>
        ///     The <see cref="Collision"/> caused by moving a given
        ///     <see cref="Body"/> with a given <see cref="Movement"/>.
        /// </summary>
        /// <param name="movement">
        ///     The <see cref="Movement"/> to move the <see cref="Body"/>
        ///     with.
        /// </param>
        /// <param name="body">
        ///     The <see cref="Body"/> to move with the <see cref="Movement"/>.
        /// </param>
        /// <returns>
        ///     The <see cref="Collision"/> caused by moving the given
        ///     <see cref="Body"/> with the given <see cref="Movement"/>, if
        ///     there is one; null otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when the given <see cref="Movement"/> is null.
        ///
        ///     -or-
        ///
        ///     Thrown when the given <see cref="Body"/> is null.
        /// </exception>
        Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body);
    }
}
