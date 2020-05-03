using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Sakura.Inventory.Tests
{
    class When_adding_an_item
	{
        protected Inventory inventory;
        protected readonly int inventorySize = 4;
        protected InventoryItem potatoSeed;

        private When_adding_an_item()
        {
            potatoSeed = new InventoryItem("Potato Seed");
        }

        [TestFixture]
        sealed class To_an_unoccupied_inventory_slot : When_adding_an_item
        {
            [SetUp]
            public void SetUp()
            {
                inventory = Inventory.WithCapacityAndEmpty(inventorySize);
            }

            [Test]
            public void It_succeeds()
            {
                var result = inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(result, Is.True);
            }

            [Test]
            public void That_item_is_put_in_the_list_of_all_inventory_items()
            {
                var expectedItemList = new List<InventoryItem>() {
                    new InventoryItem("Potato Seed"),
                    InventoryItem.NullItem,
                    InventoryItem.NullItem,
                    InventoryItem.NullItem
                };
                inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(inventory.Items, Is.EquivalentTo(expectedItemList));
            }
        }

        [TestFixture]
        sealed class To_an_occupied_inventory_slot : When_adding_an_item
        {
            private List<InventoryItem> _initialItems;
            private IEnumerable<InventoryItem> initialItems;

            [SetUp]
            public void SetUp()
            {
                initialItems = Enumerable.Repeat(new InventoryItem("Potato Seed"), inventorySize);
                inventory = Inventory.WithInitialItems(initialItems);
            }

            [Test]
            public void It_fails()
            {
                var result = inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(result, Is.False);
            }

            [Test]
            public void The_inventorys_item_list_remains_the_same()
            {
                inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(inventory.Items, Is.EquivalentTo(initialItems));
            }
        }
	}
}
