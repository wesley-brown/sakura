using UnityEngine;
using Sakura.Inventories.Runtime;

namespace Sakura.UI
{
    public sealed class InventoryPanel : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference inventoryReference = null;

        private Inventory inventory = null;

        private void Awake()
        {
            inventory = inventoryReference.Inventory;
        }
    }
}
