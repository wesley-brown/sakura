using Sakura.Client;
using UnityEngine;

namespace Collidable_Movement_System_Spec
{
    /// <summary>
    ///     A spy test double for a
    ///     <see cref="CollidableMovementSystemPresenter"/>.
    /// </summary>
    sealed class SpyPresenter : CollidableMovementSystemPresenter
    {
        /// <summary>
        ///     The location that a <see cref="CollidableMovementSystem"/>
        ///     moved the entity to.
        /// </summary>
        public Vector3 EndingLocation { get; private set; }

        /// <inheritdoc/>
        public void Present(CollidableMovement collidableMovement)
        {
            EndingLocation = collidableMovement.EndingLocation;
        }
    }
}
