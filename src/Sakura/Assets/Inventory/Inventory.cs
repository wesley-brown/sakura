using System.Collections.Generic;

namespace Sakura.Inventory
{
    public sealed class Inventory
	{
        private IList<InventoryItem> items;

        public IList<InventoryItem> Items
		{
			get
			{
				return items;
			}
		}

        public Inventory()
		{
			items = new List<InventoryItem>() {
                new InventoryItem("Potato Seeds") };
		}
    }
}
