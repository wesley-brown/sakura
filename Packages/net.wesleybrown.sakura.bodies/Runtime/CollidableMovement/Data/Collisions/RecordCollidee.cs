using UnityEngine;

namespace Sakura.Bodies.CollidableMovement.Data
{
    /// <summary>
    ///     A component that is necessary to allow
    ///     <see cref="CharacterControllerCollisions"/>s to find the
    ///     <see cref="GameObject"/> that a <see cref="CharacterController"/>
    ///     collided with.
    /// </summary>
    /// <remarks>
    ///     Since <see cref="CharacterController"/>s report the
    ///     <see cref="GameObject"/>s they collide with through the
    ///     <see cref="OnControllerColliderHit(ControllerColliderHit)"/>
    ///     message, this component needs to be placed on any
    ///     <see cref="GameObject"/> a
    ///     <see cref="CharacterControllerCollisions"/> is looking at the
    ///     collisions for before any <see cref="CharacterController"/> methods
    ///     are called.
    /// </remarks>
    sealed class RecordCollidee : MonoBehaviour
    {
        /// <summary>
        ///     The <see cref="GameObject"/> that a
        ///     <see cref="CharacterController"/> collided with.
        /// </summary>
        public GameObject Collidee { get; private set; }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Collidee = hit.collider.transform.root.gameObject;
        }
    }
}
