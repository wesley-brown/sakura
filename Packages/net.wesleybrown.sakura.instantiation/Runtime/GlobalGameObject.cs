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

        /// <summary>
        /// Make this global game object appear in the current scene.
        /// </summary>
        /// <returns></returns>
        public GameObject AppearInScene()
        {
            return Instantiate(prefab);
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
