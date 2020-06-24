using UnityEngine;
using Sakura.Inventories.Runtime;

namespace Sakura.Runtime
{
    /// <summary>
    /// Places a given item in a given inventory.
    /// </summary>
    [RequireComponent(typeof(ItemVariable))]
    public sealed class StoreItem : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference inInventory = null;

        private ItemVariable itemVariable = null;
        private Inventory inventory = null;

        private void Awake()
        {
            itemVariable = GetComponent<ItemVariable>();
            inventory = inInventory.Inventory;
        }

        private void OnEnable()
        {
            var item = itemVariable.Item;
            inventory.Store(item);
            enabled = false;
        }
    }
}
