using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// Causes a game object to move to a given destination.
    /// </summary>
    [RequireComponent(typeof(Transform))]
    [DisallowMultipleComponent]
    public sealed class MoveToDestination : MonoBehaviour
    {
        [SerializeField] private Vector3 destination = Vector3.zero;
        [SerializeField] private float speed = 0.0f;

        private Vector3 startingLocation = Vector3.zero;
        private Vector3 heading = Vector3.zero;

        private void Start()
        {
            startingLocation = transform.position;
            heading = destination - startingLocation;
        }

        private void Update()
        {
            if (speed > 0.0f)
            {
                var direction = Vector3.Normalize(destination - transform.position);
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
                var traveled = transform.position - startingLocation;
                if (traveled.magnitude > heading.magnitude)
                {
                    // Gone past destination
                    transform.position = destination;
                    Destroy(this);
                }
            }
        }
    }
}
