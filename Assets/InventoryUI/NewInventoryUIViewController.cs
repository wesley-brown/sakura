using Sakura.Inventories.Runtime;
using UnityEngine;

namespace Sakura.InventoryUI
{
    public sealed class NewInventoryUIViewController : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference inventoryReference = null;
        [SerializeField]
        private GameObject buttonPrefab = null;

        private Inventory inventory = null;

        private void Awake()
        {
            inventory = inventoryReference.Inventory;
            for (var i = 0; i < inventory.Capacity; ++i)
            {
                Instantiate(buttonPrefab, transform);
            }
        }
    }
}
