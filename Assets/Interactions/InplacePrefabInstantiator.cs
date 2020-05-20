using UnityEngine;
using System;

namespace Sakura.Interactions
{
    /// <summary>
    /// A component that instantiates a prefab at the same place as its
    /// attached game object.
    /// </summary>
    /// <remarks>
    /// Can be configured to instantiate a given prefab as a child of itself.
    /// </remarks>
    public sealed class InplacePrefabInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private bool asChild = false;

        public void PlacePrefabInplace()
        {
            if (asChild == true)
            {
                Instantiate(prefab, transform);
            }
            else
            {
                Instantiate(prefab, transform.position, transform.rotation);
            }
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
