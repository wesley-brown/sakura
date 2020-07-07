using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// Moves game objects towards a destination.
    /// </summary>
    [RequireComponent(typeof(CharacterControllerParameter))]
    [RequireComponent(typeof(FloatParameter))]
    public sealed class DestinationMover : MonoBehaviour
    {
        private CharacterControllerParameter characterControllerParameter =
            null;
        private float speed = 0.0f;

        private void Awake()
        {
            characterControllerParameter =
                GetComponent<CharacterControllerParameter>();
            speed = GetComponent<FloatParameter>().Value;
        }

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
            characterControllerParameter
                .Value
                .Move(direction * Time.deltaTime * speed);
        }
    }
}
