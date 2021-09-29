using System;
using Sakura.Core;
using Sakura.Bodies.CollidableMovement.Data;

namespace In_Memory_Collidable_Bodies_Spec
{
    /// <summary>
    ///     A dummy test double for a <see cref="Collisions"/>.
    /// </summary>
    sealed class DummyCollisions : Collisions
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
        ///     Never returns.
        /// </returns>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public Collision CollisionCausedByMovingBody(
            Movement movement,
            Body body)
        {
            throw new NotImplementedException();
        }
    }
}