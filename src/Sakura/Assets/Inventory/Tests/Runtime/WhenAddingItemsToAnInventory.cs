using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventory.Tests
{
    [TestFixture]
    sealed class WhenAddingItemsToAnInventory
	{
        [Test]
        public void That_item_is_in_the_list_of_all_items()
		{
            var inventory = new Inventory();
            var potatoSeed = new InventoryItem("Potato Seed");
            var expectedItemList =
                new List<InventoryItem>() { new InventoryItem("Potato Seed") };
            inventory.AddItem(potatoSeed);
            Assert.That(inventory.Items, Is.EqualTo(expectedItemList));
		}
	}
}
