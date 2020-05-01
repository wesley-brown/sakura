using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventory.Tests
{
    sealed class When_removing_an_item
    {
        [TestFixture]
        sealed class From_an_inventory
        {
            [Test]
            public void The_item_in_that_slot_is_returned()
            {
                var initialItems = new List<InventoryItem>() {
                    new InventoryItem("Potato Seed")
                };
                var inventory = new Inventory(initialItems);
                var expectedItem = new InventoryItem("Potato Seed");

                var removedItem = inventory.RemoveItemFromSlot(0);
                Assert.That(removedItem, Is.EqualTo(expectedItem));
            }
        }
    }
}
