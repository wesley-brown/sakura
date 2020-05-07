using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    class When_removing_an_item
    {
        protected readonly IList<InventoryItem> initialItems;
        protected readonly int inventoryCapacity;
        protected readonly Inventory inventory;

        private When_removing_an_item()
        {
            initialItems = new List<InventoryItem> {
                new InventoryItem("Potato Seed")
            };
            inventoryCapacity = 2;
            inventory = Inventory.WithCapacityAndInitialItems(
                inventoryCapacity, initialItems);
        }

        [TestFixture]
        sealed class From_an_occupied_inventory_slot : When_removing_an_item
        {
            [Test]
            public void The_item_in_that_inventory_slot_is_returned()
            {
                var expectedItem = new InventoryItem("Potato Seed");
                var removedItem = RemoveItemInFirstSlot();
                Assert.That(removedItem, Is.EqualTo(expectedItem));
            }

            [Test]
            public void The_null_item_fills_that_slot()
            {
                RemoveItemInFirstSlot();
                Assert.That(
                    inventory.Items[0],
                    Is.EqualTo(InventoryItem.NullItem)
                );
            }

            private InventoryItem RemoveItemInFirstSlot()
            {
                return inventory.RemoveItemFromSlot(0);
            }
        }

        [TestFixture]
        public class From_an_unoccupied_inventory_slot : When_removing_an_item
        {
            [Test]
            public void The_null_item_is_returned()
            {
                var removedItem = inventory.RemoveItemFromSlot(1);
                Assert.That(removedItem, Is.EqualTo(InventoryItem.NullItem));
            }
        }
    }
}
