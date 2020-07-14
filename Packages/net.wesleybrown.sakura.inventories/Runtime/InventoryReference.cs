using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A reference to an inventory.
    /// </summary>
    [CreateAssetMenu(
        fileName = "InventoryReference",
        menuName = "Inventories/Inventory Reference")]
    public sealed class InventoryReference : ScriptableObject
	{
        [SerializeField]
        private int capacity = 0;

        [SerializeField]
        private List<ItemTemplate> initialItemTemplates = null;

        private Inventory inventory = null;

        private InventoryUpdate onInventoryUpdate = null;

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        public void Subscribe(UnityAction<Inventory> action)
        {
            onInventoryUpdate.AddListener(action);
        }

        public void Unsubscribe(UnityAction<Inventory> action)
        {
            onInventoryUpdate.RemoveListener(action);
        }

        private void OnEnable()
        {
            if (initialItemTemplates != null)
            {
                var items = new List<Item>();
                foreach(var itemTemplate in initialItemTemplates)
                {
                    var item = Item.FromTemplate(itemTemplate);
                    items.Add(item);
                }
                inventory = Inventory.WithCapacityAndInitialItems(capacity, items);
            }
            onInventoryUpdate = inventory.OnInventoryUpdate;
        }
    }
}
