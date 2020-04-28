using System.Collections.Generic;

namespace Sakura.Inventory
{
    /// <summary>
    /// An inventory.
    /// </summary>
    public sealed class Inventory
    {
        private readonly List<InventoryItem> items;

        /// <summary>
        /// Create a new empty inventory.
        /// </summary>
        public Inventory()
        {
            items = new List<InventoryItem>();
        }

        /// <summary>
        /// The list of items this inventory currenlty contains.
        /// </summary>
        public IList<InventoryItem> Items
        {
            get
            {
                return items.AsReadOnly();
            }
        }

        /// <summary>
        /// Add an item to this inventory.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(InventoryItem item)
        {
            items.Add(item);
        }
    }
}
