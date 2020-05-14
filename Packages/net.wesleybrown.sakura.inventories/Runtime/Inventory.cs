using System;
using System.Collections.Generic;
using System.Linq;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// An inventory with a certain number of slots for items.
    /// </summary>
    public sealed class Inventory
    {
        private readonly int capacity;
        private readonly List<Item> items;

        private Inventory(int capacity, IList<Item> initialItems)
        {
            this.capacity = capacity;
            items = new List<Item>(capacity);
            items.AddRange(Enumerable.Repeat(Item.NullItem, capacity));
            for (var itemSlot = 0; itemSlot < initialItems.Count;
                itemSlot = itemSlot + 1)
            {
                items[itemSlot] = initialItems[itemSlot];
            }
        }

        /// <summary>
        /// Create a new empty inventory with a given capacity.
        /// </summary>
        /// <param name="capacity">
        /// The maximum number of items the new inventory can hold.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// capacity is less than or equal to 0.
        /// </exception>
        /// <returns>An empty inventory with the given capacity.</returns>
        public static Inventory WithCapacityAndEmpty(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("capacity");
            }
            else
            {
                var initialItems = new List<Item>();
                initialItems.AddRange(
                    Enumerable.Repeat(Item.NullItem, capacity));
                return new Inventory(capacity, initialItems);
            }
        }

        /// <summary>
        /// Create a new inventory with a given capacity and items initially in
        /// it.
        /// </summary>
        /// <param name="capacity">
        /// The maximum number of items the new inventory can hold.
        /// </param>
        /// <param name="initialItems">
        /// The items the new inventory will initially have in it.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// initialItems is null.
        /// </exception>
        /// <returns>
        /// A new inventory the given capacity and the given list of initial
        /// items taking up the slots.
        /// </returns>
        public static Inventory WithCapacityAndInitialItems(int capacity,
            IList<Item> initialItems)
        {
            if (initialItems == null)
            {
                throw new ArgumentNullException("initialItems");
            }
            else
            {
                return new Inventory(capacity, initialItems);
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
        public IList<Item> Items
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
        public bool AddItemToSlot(Item item, int inventorySlot)
        {
            var itemInSlot = items[inventorySlot];
            if (itemInSlot.Equals(Item.NullItem))
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
        /// Remove the first item in this inventory that was made from a given
        /// item template, if one exists.
        /// </summary>
        /// <param name="template">The item template to check for.</param>
        /// <returns>
        /// If there were any items made from the given item template, then
        /// returns the first one found. Otherwise, returns the null item.
        /// </returns>
        public Item RemoveFirstItemMadeFromTemplate(ItemTemplate template)
        {
            var firstItemMadeFromTemplate = Item.NullItem;
            for (var i = 0; i < items.Count; i = i + 1)
            {
                var item = items[i];
                if (item.Template.Equals(template))
                {
                    firstItemMadeFromTemplate = RemoveItemFromSlot(i);
                    break;
                }
            }
            return firstItemMadeFromTemplate;
        }

        /// <summary>
        /// Remove the item in the given inventory slot.
        /// </summary>
        /// <param name="slotNumber">
        /// The inventory slot number to remove the item from.
        /// </param>
        /// <returns>The removed item.</returns>
        public Item RemoveItemFromSlot(int slotNumber)
        {
            var requestedItem = items[slotNumber];
            items[slotNumber] = Item.NullItem;
            return requestedItem;
        }

        /// <summary>
        /// Check if this inventory contains the given item.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <returns>
        /// Returns true if this inventory contains the given item. Otherwise,
        /// returns false.
        /// </returns>
        public bool Contains(Item item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// Check if this inventory contains an item made from a given item
        /// template.
        /// </summary>
        /// <param name="template">The item template to check for.</param>
        /// <returns>Returns true.</returns>
        public bool ContainsItemMadeFromTemplate(ItemTemplate template)
        {
            return true;
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
