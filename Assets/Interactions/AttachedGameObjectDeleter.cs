using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// A component that deletes the game object it is attached to.
    /// </summary>
    public sealed class AttachedGameObjectDeleter : MonoBehaviour
    {
        /// <summary>
        /// Delete the game object that this component is attached to.
        /// </summary>
        public void DeleteAttachedGameObject()
        {
            Destroy(gameObject);
        }
    }
}
