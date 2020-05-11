using System;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// An instance of an item that is in an inventory.
    /// </summary>
    public sealed class InventoryItem
	{
        private static readonly InventoryItem nullItem =
            new InventoryItem("Null Item");

        private readonly Guid id;
        private readonly string itemName;

        public static InventoryItem NullItem
        {
            get
            {
                return nullItem;
            }
        }

        /// <summary>
        /// Create a new inventory item.
        /// </summary>
        /// <param name="itemName">
        /// The name of the item that the new inventory item will represent.
        /// </param>
        public InventoryItem(string itemName)
        {
            id = Guid.NewGuid();
            this.itemName = itemName;
        }

        /// <summary>
        /// The unique identifier of this inventory item.
        /// </summary>
        public Guid Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// The name of the item that this inventory item represents.
        /// </summary>
        public string ItemName
        {
            get
            {
                return itemName;
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var otherInventoryItem = (InventoryItem) obj;
                return id == otherInventoryItem.id;
            }
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return "<InventoryItem: itemName=" + itemName + ">";
        }
    }
}
