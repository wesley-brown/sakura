using UnityEngine;

namespace Sakura.Interactions
{
    /// <summary>
    /// A component that instantiates a prefab at the same place as its
    /// attached game object when interacted with.
    /// </summary>
    public sealed class InplacePrefabInstantiator : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab = null;

        public void PlacePrefabInplace()
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
