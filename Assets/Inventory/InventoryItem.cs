namespace Sakura.Inventory
{
    public sealed class InventoryItem
	{
        public string ItemName
		{
            get
			{
				return itemName;
			}
		}

		private string itemName;

        public InventoryItem(string itemName)
		{
			this.itemName = itemName;
		}
	}
}