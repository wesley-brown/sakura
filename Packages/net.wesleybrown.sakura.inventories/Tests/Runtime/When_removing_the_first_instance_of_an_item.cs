using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    sealed class When_removing_the_first_instance_of_an_item
    {
        [TestFixture]
        sealed class That_an_inventory_has
        {
            [Test]
            public void The_first_instance_of_it_is_removed()
            {
                var potatoSeed = new InventoryItem("Potato Seed");
                var initialItems = new List<InventoryItem> {
                    potatoSeed,
                    potatoSeed
                };
                var inventory =
                    Inventory.WithCapacityAndInitialItems(2, initialItems);
                inventory.RemoveFirstInstanceOfItem(potatoSeed);
                var expectedItems = new List<InventoryItem> {
                    InventoryItem.NullItem,
                    potatoSeed
                };
                Assert.That(inventory.Items, Is.EqualTo(expectedItems));
            }
        }
    }
}
