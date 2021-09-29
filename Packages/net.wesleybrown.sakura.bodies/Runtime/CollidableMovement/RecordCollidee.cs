using UnityEngine;

namespace Sakura.Bodies.CollidableMovement.Data
{
    sealed class RecordCollidee : MonoBehaviour
    {
        public GameObject Collidee { get; private set; }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Collidee = hit.collider.gameObject;
        }
    }
}
