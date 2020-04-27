namespace Sakura.Inventory
{
    /// <summary>
    /// An item that is in an inventory.
    /// </summary>
    public struct InventoryItem
	{
        private readonly string itemName;

        /// <summary>
        /// Create a new inventory item.
        /// </summary>
        /// <param name="itemName">
        /// The name of the item that the new inventory item will represent.
        /// </param>
        public InventoryItem(string itemName)
        {
            this.itemName = itemName;
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
                return (itemName == otherInventoryItem.itemName);
            }
        }

        public override int GetHashCode()
        {
            int result = itemName.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return "<InventoryItem: itemName=" + itemName + ">";
        }
    }
}
