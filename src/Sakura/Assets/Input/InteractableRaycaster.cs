using UnityEngine;

namespace Sakura.Input
{
    /// <summary>
    /// Determines if any interactable game objects are hit by a raycast.
    /// </summary>
    public sealed class InteractableRaycaster : MonoBehaviour
    {
        /// <summary>
        /// Casts a give ray and determines if any interactable game objects
        /// are hit.
        /// </summary>
        /// <param name="ray">The ray to cast.</param>
        /// <param name="raycastHit">The ray cast hit output.</param>
        /// <returns>
        /// True if the raycast hits any interactable game objects; false
        /// otherwise.
        /// </returns>
        public bool DidHitInteractable(Ray ray, out RaycastHit raycastHit)
        {
            return Physics.Raycast(ray, out raycastHit, float.PositiveInfinity,
                1 << LayerMask.NameToLayer("Interactable"));
        }
    }
}
