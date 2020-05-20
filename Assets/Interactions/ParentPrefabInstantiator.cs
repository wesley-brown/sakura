using UnityEngine;
using System;

namespace Sakura.Interactions
{
    /// <summary>
    /// Causes a game object to instantiate a given prefab at the same location
    /// as its parent game object's location.
    /// </summary>
    public sealed class ParentPrefabInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;

        /// <summary>
        /// Instantiate the given prefab at the same location as this game
        /// object's parent location.
        /// </summary>
        public void InstantiateAtParentLocation()
        {
            var parentTransform = transform.parent;
            Instantiate(
                prefab,
                parentTransform.position,
                parentTransform.rotation);
        }

        private void Awake()
        {
            if (prefab == null)
            {
                throw new InvalidOperationException("Prefab must not be null");
            }
        }
    }
}
