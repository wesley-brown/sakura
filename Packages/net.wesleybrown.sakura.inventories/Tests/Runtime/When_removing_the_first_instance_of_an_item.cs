using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    sealed class When_removing_the_first_instance_of_an_item
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

        [TestFixture]
        sealed class That_an_inventory_has
        {
            private readonly string templateName = "TestItem.asset";
            private ItemTemplate theTemplate;
            private Item theFirstItem;
            private Item theSecondItem;
            private Inventory playersInventory;

            [SetUp]
            public void SetUp()
            {
                theTemplate = AssetDatabase
                    .LoadAssetAtPath<ItemTemplate>(path + templateName);
                theFirstItem = Item.FromTemplate(theTemplate);
                theSecondItem = Item.FromTemplate(theTemplate);
                var playersInitialItems = new List<Item> {
                    theFirstItem,
                    theSecondItem
                };
                playersInventory = Inventory.WithCapacityAndInitialItems(2,
                    playersInitialItems);
            }

            [Test]
            public void The_first_instance_of_it_is_removed()
            {
                var playersExpectedInventoryAfterPlanting =
                    new List<Item> {
                        Item.NullItem,
                        theSecondItem
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
                Assert.That(removedItem, Is.EqualTo(theFirstItem));
            }

            private Item PlayerPlantsAPotatoSeed()
            {
                return playersInventory.RemoveFirstInstanceOfItem(theFirstItem);
            }
        }
    }
}
