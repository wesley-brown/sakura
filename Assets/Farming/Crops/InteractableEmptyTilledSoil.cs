using UnityEngine;

namespace Sakura.Crop
{
    public sealed class InteractableEmptyTilledSoil : MonoBehaviour
    {
        [SerializeField]
        private GameObject harvestableCropPotatoPrefab = null;

        public void PlantPotato()
        {
            var harvestableCropPotato = Instantiate(
                harvestableCropPotatoPrefab,
                transform.position,
                transform.rotation
            );
            Destroy(gameObject);
        }
    }
}