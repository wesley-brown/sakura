using UnityEngine;

namespace Sakura
{
    public sealed class PrefabInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;

        private void React(Entity player)
        {
            var distance = Vector3.Distance(player.Location, transform.position);
            Debug.Log(distance);
            if (distance <= 2)
            {
                InstantiatePrefab();
            }
        }

        public void InstantiatePrefab()
        {
            Instantiate(prefab);
        }
    }
}
