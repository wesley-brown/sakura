using Sakura.Inventories.Runtime;
using UnityEngine;
using UnityEngine.UI;

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
            var scrollRect = GetComponentInChildren<ScrollRect>();
            inventory = inventoryReference.Inventory;
            for (var i = 0; i < inventory.Capacity; ++i)
            {
                Instantiate(buttonPrefab, scrollRect.content);
            }
        }
    }
}
