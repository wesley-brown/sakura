using System;
using Sakura.Client;

namespace Collidable_Movement_System_Spec
{
    /// <summary>
    ///     A dummy test double for a
    ///     <see cref="CollidableMovementSystemPresenter"/>.
    /// </summary>
    sealed class DummyCollidableMovementSystemPresenter :
        CollidableMovementSystemPresenter
    {
        /// <summary>
        ///     Present a given <see cref="CollidableMovement"/>.
        /// </summary>
        /// <param name="collidableMovement">
        ///     The <see cref="CollidableMovement"/> to present.
        /// </param>
        /// <exception cref="NotImplementedException">
        ///     Always thrown.
        /// </exception>
        public void Present(CollidableMovement collidableMovement)
        {
            throw new NotImplementedException();
        }
    }
}
