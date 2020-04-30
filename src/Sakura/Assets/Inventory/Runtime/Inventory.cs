using System.Collections.Generic;
using System.Linq;

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
        /// Create a new inventory with the given items initially in it.
        /// </summary>
        /// <param name="initialItems">
        /// The items the new inventory will initially have in it.
        /// </param>
        public Inventory(IList<InventoryItem> initialItems)
        {
            items = initialItems.ToList();
        }

        /// <summary>
        /// The maximum number of items an inventory can hold.
        /// </summary>
        public static int Capacity
        {
            get
            {
                return 28;
            }
        }

        /// <summary>
        /// The list of items this inventory currently contains.
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
        public bool AddItem(InventoryItem item)
        {
            if (ThereIsAnEmptyItemSlot)
            {
                items.Add(item);
            }
            return false;
        }

        public override string ToString()
        {
            var stringRepresentation = "<Inventory: ";
            for (int i = 0; i < items.Count; i = i + 1)
            {
                var item = items[i];
                stringRepresentation = stringRepresentation + item.ToString();
                if (i != items.Count - 1)
                {
                    stringRepresentation = stringRepresentation + ",";
                }
            }
            stringRepresentation = stringRepresentation + ">";
            return stringRepresentation;
        }

        private bool ThereIsAnEmptyItemSlot
        {
            get { return (items.Count < Capacity); }
        }
    }
}
