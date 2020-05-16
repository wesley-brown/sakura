using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// Causes a game object to delete a given game object.
    /// </summary>
    public sealed class GameObjectDeleter : MonoBehaviour
    {
        [SerializeField]
        private GameObject otherGameObject = null;

        /// <summary>
        /// Delete the given game object.
        /// </summary>
        public void DeleteGameObject()
        {
            Destroy(otherGameObject);
        }
    }
}
