using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Sakura.Inventory.Tests
{
    class When_adding_an_item
	{
        protected Inventory inventory;
        protected InventoryItem potatoSeed;

        private When_adding_an_item()
        {
            potatoSeed = new InventoryItem("Potato Seed");
        }

        [TestFixture]
        sealed class To_a_non_full_inventory : When_adding_an_item
        {
            [SetUp]
            public void SetUp()
            {
                inventory = new Inventory();
            }

            [Test]
            public void That_item_is_put_in_the_list_of_all_inventory_items()
            {
                var expectedItemList = new List<InventoryItem>() {
                    new InventoryItem("Potato Seed")
                };
                inventory.AddItem(potatoSeed);
                Assert.That(inventory.Items, Is.EquivalentTo(expectedItemList));
            }
        }

        [TestFixture]
        sealed class To_a_full_inventory : When_adding_an_item
        {
            private List<InventoryItem> initialItems;

            [SetUp]
            public void SetUp()
            {
                initialItems = new List<InventoryItem>();
                initialItems.AddRange(Enumerable.Repeat(potatoSeed, 28));
                inventory = new Inventory(initialItems);
            }

            [Test]
            public void The_inventorys_item_list_remains_the_same()
            {
                inventory.AddItem(potatoSeed);
                Assert.That(inventory.Items, Is.EquivalentTo(initialItems));
            }

            [Test]
            public void It_fails()
            {
                var result = inventory.AddItem(potatoSeed);
                Assert.That(result, Is.False);
            }
        }
	}
}
