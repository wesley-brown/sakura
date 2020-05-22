using UnityEngine;
using System;

namespace Sakura.Instantiation
{
    /// <summary>
    /// An entity that has no parent.
    /// </summary>
    public sealed class RootEntity : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;

        private GameObject instantiatedGameObject = null;

        /// <summary>
        /// The game object representation of this root entity.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return instantiatedGameObject;
            }
        }

        /// <summary>
        /// Make this global game object appear in the current scene.
        /// </summary>
        /// <returns></returns>
        public void AppearInScene()
        {
            instantiatedGameObject = AppearAtLocation(Vector3.zero);
        }

        /// <summary>
        /// Make this root entity appear in the current scene at the same
        /// location as a given game object.
        /// </summary>
        /// <param name="other">
        /// The other game object to appear at the same location as.
        /// </param>
        public void AppearInSceneAtLocationOf(GameObject other)
        {
            instantiatedGameObject = AppearAtLocation(other.transform.position);
        }

        private void Awake()
        {
            if (prefab == null)
            {
                throw new InvalidOperationException("Prefab must not be null.");
            }
        }

        private GameObject AppearAtLocation(Vector3 location)
        {
            return Instantiate(prefab, location, Quaternion.identity);
        }
    }
}
