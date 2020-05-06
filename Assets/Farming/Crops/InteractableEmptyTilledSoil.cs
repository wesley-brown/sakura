using UnityEngine;
using Sakura.Inventories.Runtime;

namespace Sakura.Crop
{
    public sealed class InteractableEmptyTilledSoil : MonoBehaviour
    {
        [SerializeField]
        private GameObject harvestableCropPotatoPrefab = null;

        [SerializeField]
        private InventoryReference playerInventoryReference = null;

        public void PlantPotato()
        {
            var playersInventory = playerInventoryReference.Inventory;
            var potatoSeed = new InventoryItem("Potato Seed");
            if (playersInventory.Contains(potatoSeed))
            {
                Instantiate(
                    harvestableCropPotatoPrefab,
                    transform.position,
                    transform.rotation
                );
                Destroy(gameObject);
            }
        }
    }
}