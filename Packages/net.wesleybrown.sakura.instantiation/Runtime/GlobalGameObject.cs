using UnityEngine;
using System;

namespace Sakura.Instantiation
{
    /// <summary>
    /// A game object that has no parent.
    /// </summary>
    public sealed class GlobalGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;

        private GameObject instantiatedGameObject = null;

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
        public GameObject AppearInScene()
        {
            return Instantiate(prefab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void AppearInSceneAtLocationOf(GameObject other)
        {
            instantiatedGameObject = AppearInScene();
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
