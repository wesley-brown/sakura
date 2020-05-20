using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// Causes a game object to delete its parent game object.
    /// </summary>
    public sealed class ParentGameObjectDeleter : MonoBehaviour
    {
        /// <summary>
        /// Delete this game object's parent game object.
        /// </summary>
        public void DeleteParent()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
