using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    sealed class When_removing_the_first_instance_of_an_item
    {
        [TestFixture]
        sealed class That_an_inventory_has
        {
            private InventoryItem potatoSeed;
            private Inventory playersInventory;

            [SetUp]
            public void SetUp()
            {
                potatoSeed = new InventoryItem("Potato Seed");
                var playersInitialItems = new List<InventoryItem> {
                    potatoSeed,
                    potatoSeed
                };
                playersInventory = Inventory.WithCapacityAndInitialItems(2,
                    playersInitialItems);
            }

            [Test]
            public void The_first_instance_of_it_is_removed()
            {
                var playersExpectedInventoryAfterPlanting =
                    new List<InventoryItem> {
                        InventoryItem.NullItem,
                        potatoSeed
                };
                PlayerPlantsAPotatoSeed();
                Assert.That(
                    playersInventory.Items,
                    Is.EqualTo(playersExpectedInventoryAfterPlanting)
                );
            }

            [Test]
            public void The_removed_item_is_returned()
            {
                var removedItem = PlayerPlantsAPotatoSeed();
                Assert.That(removedItem, Is.EqualTo(potatoSeed));
            }

            private InventoryItem PlayerPlantsAPotatoSeed()
            {
                return playersInventory.RemoveFirstInstanceOfItem(potatoSeed);
            }
        }
    }
}
