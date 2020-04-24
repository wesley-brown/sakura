using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// Moves game objects towards a destination.
    /// </summary>
    public sealed class DestinationMover : MonoBehaviour
    {
        private CharacterController characterController;

        [SerializeField]
        private float speed = 0;

        /// <summary>
        /// Move towards a given destination.
        /// </summary>
        /// <param name="destination">the destination to move towards.</param>
        public void MoveTowardsDestination(Vector3 destination)
        {
            var yAdjustedDestination = new Vector3(
                destination.x, transform.position.y, destination.z);
            var direction =
                (yAdjustedDestination - transform.position).normalized;
            characterController.Move(direction * Time.deltaTime * speed);
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }
    }
}
