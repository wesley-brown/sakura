using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventory.Tests
{
    sealed class When_adding_an_item
	{
        [TestFixture]
        sealed class To_a_non_full_inventory
        {
            [Test]
            public void That_item_is_put_in_the_list_of_all_inventory_items()
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
}
