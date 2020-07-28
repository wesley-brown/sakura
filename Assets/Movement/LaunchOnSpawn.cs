using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// Causes a game object to launch itself at a given trajectory.
    /// </summary>
    public sealed class LaunchOnSpawn : MonoBehaviour
    {
        [SerializeField] private float distance = 0.0f;
        [SerializeField] private Vector3 velocity = Vector3.zero;
        [SerializeField] private float speed = 1.0f;

        private Vector3 location = Vector3.zero;
        private Vector3 nextPosition = Vector3.zero;

        private void Start()
        {
            location = transform.position;
        }

        private void FixedUpdate()
        {
            nextPosition = location + (velocity * speed);
            location = nextPosition;
        }

        private void Update()
        {
            Vector3 interpolatedPosition = Vector3.Lerp(
                location,
                nextPosition,
                0.5f);
            transform.position = interpolatedPosition;
        }
    }
}
