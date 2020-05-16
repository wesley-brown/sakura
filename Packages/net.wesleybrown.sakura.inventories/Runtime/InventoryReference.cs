using UnityEngine;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A reference to an inventory.
    /// </summary>
    [CreateAssetMenu(fileName = "InventoryReference",
        menuName = "Inventories/Inventory Reference")]
    public sealed class InventoryReference : ScriptableObject
	{
        [SerializeField]
        private int capacity = 0;

        [SerializeField]
        private List<ItemTemplate> initialItemTemplates = null;

        private Inventory inventory = null;

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
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
        }
    }
}
