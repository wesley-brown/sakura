using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// Causes a game object to rotate in place.
    /// </summary>
    [RequireComponent(typeof(Transform))]
    public sealed class RotateInPlace : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAngle = Vector3.zero;

        private void Update()
        {
            if (rotationAngle != Vector3.zero)
            {
                transform.Rotate(rotationAngle.x, rotationAngle.y, rotationAngle.z);
            }
        }
    }
}
