using System;
using System.Collections.Generic;
using System.Linq;

namespace Sakura.Inventory
{
    /// <summary>
    /// An inventory with a certain number of slots for items.
    /// </summary>
    public sealed class Inventory
    {
        private readonly int capacity;
        private readonly List<InventoryItem> items;

        private Inventory(IEnumerable<InventoryItem> initialItems)
        {
            items = initialItems.ToList();
        }

        /// <summary>
        /// Create a new empty inventory with a given capacity.
        /// </summary>
        /// <param name="capacity">
        /// The capacity of the new empty inventory.
        /// </param>
        /// <returns>An empty inventory with the given capacity.</returns>
        public static Inventory WithCapacityAndEmpty(int capacity)
        {
            var initialItems =
                Enumerable.Repeat(InventoryItem.NullItem, capacity);
            return new Inventory(initialItems);
        }

        /// <summary>
        /// Create a new inventory with the given items initially in it.
        /// </summary>
        /// <param name="initialItems">
        /// The items the new inventory will initially have in it.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// initialItems is null.
        /// </exception>
        public static Inventory WithInitialItems(
            IEnumerable<InventoryItem> initialItems)
        {
            if (initialItems == null)
            {
                throw new ArgumentNullException("initialItems");
            }
            else
            {
                return new Inventory(initialItems);
            }
        }

        /// <summary>
        /// The maximum number of items this inventory can hold.
        /// </summary>
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        /// <summary>
        /// The list of items in each inventory slot.
        /// </summary>
        public IEnumerable<InventoryItem> Items
        {
            get
            {
                return items;
            }
        }

        /// <summary>
        /// Add an item to the given inventory slot.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="inventorySlot">
        /// The inventory slot to put the item in.
        /// </param>
        /// <returns>
        /// Returns true if the given item was added to the given inventory
        /// slot. Otherwise, returns false.
        /// </returns>
        public bool AddItemToSlot(InventoryItem item, int inventorySlot)
        {
            var itemInSlot = items[inventorySlot];
            if (itemInSlot.Equals(InventoryItem.NullItem))
            {
                items[inventorySlot] = item;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove the item in the given inventory slot.
        /// </summary>
        /// <param name="slotNumber">
        /// The inventory slot number to remove the item from.
        /// </param>
        /// <returns>The removed item.</returns>
        public InventoryItem RemoveItemFromSlot(int slotNumber)
        {
            var requestedItem = items[slotNumber];
            return requestedItem;
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
    }
}
