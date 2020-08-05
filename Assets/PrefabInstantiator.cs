using UnityEngine;

namespace Sakura
{
    public sealed class PrefabInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;

        private void React()
        {
            Instantiate(prefab);
        }
    }
}
