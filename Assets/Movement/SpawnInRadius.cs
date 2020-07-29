using UnityEngine;

namespace Sakura.Movement
{
    public sealed class SpawnInRadius : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = null;

        public void Spawn()
        {
            var location = Random.insideUnitSphere * 2;
            location += gameObject.transform.position;
            location.y = gameObject.transform.position.y * 2;
            Instantiate(prefab, location, Quaternion.identity);
            Debug.Log("spawned at " + location);
        }
    }
}