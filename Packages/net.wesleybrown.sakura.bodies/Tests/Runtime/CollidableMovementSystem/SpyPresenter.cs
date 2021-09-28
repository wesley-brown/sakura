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
        ///     Whether or not this <see cref="SpyPresenter"/> reported an
        ///     error.
        /// </summary>
        public bool ReportedError { get; private set; }

        /// <summary>
        ///     The location that a <see cref="CollidableMovementSystem"/>
        ///     moved the entity to.
        /// </summary>
        public Vector3 EndingLocation { get; private set; }

        /// <inheritdoc/>
        public void ReportError(string error)
        {
            ReportedError = true;
        }

        /// <inheritdoc/>
        public void Present(CollidableMovement collidableMovement)
        {
            EndingLocation = collidableMovement.EndingLocation;
        }
    }
}
