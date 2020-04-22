using UnityEngine;

namespace Sakura.Crop
{
    public sealed class InteractableEmptyTilledSoil : MonoBehaviour
    {
        [SerializeField]
        private GameObject harvestableCropPotatoPrefab;

        public void PlantPotato()
        {
            GameObject harvestableCropPotato =
                GameObject.Instantiate(harvestableCropPotatoPrefab, transform.position, transform.rotation);
            Object.Destroy(gameObject);
        }
    }
}