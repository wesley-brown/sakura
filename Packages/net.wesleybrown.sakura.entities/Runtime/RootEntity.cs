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
            instantiatedGameObject = Instantiate(prefab);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void AppearInSceneAtLocationOf(GameObject other)
        {
            AppearInScene();
        }

        private void Awake()
        {
            if (prefab == null)
            {
                throw new InvalidOperationException("Prefab must not be null.");
            }
        }
    }
}
