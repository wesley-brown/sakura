using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    [TestFixture]
    class When_adding_an_item
	{
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

        protected Inventory theInventory;
        protected readonly int inventorySize = 4;
        private readonly string templateName = "TestItem.asset";
        private ItemTemplate theTemplate;
        protected Item theItem;

        [SetUp]
        public virtual void SetUp()
        {
            theTemplate = AssetDatabase.LoadAssetAtPath<ItemTemplate>(
                path + templateName);
            theItem = Item.FromTemplate(theTemplate);
        }

        sealed class To_an_unoccupied_inventory_slot : When_adding_an_item
        {
            [SetUp]
            public override void SetUp()
            {
                base.SetUp();
                theInventory = Inventory.WithCapacityAndEmpty(inventorySize);
            }

            [Test]
            public void It_succeeds()
            {
                var result = theInventory.AddItemToSlot(theItem, 0);
                Assert.That(result, Is.True);
            }

            [Test]
            public void That_item_is_put_in_the_list_of_all_inventory_items()
            {
                var expectedItemList = new List<Item>() {
                    theItem,
                    Item.NullItem,
                    Item.NullItem,
                    Item.NullItem
                };
                theInventory.AddItemToSlot(theItem, 0);
                Assert.That(theInventory.Items,
                    Is.EquivalentTo(expectedItemList));
            }
        }

        sealed class To_an_occupied_inventory_slot : When_adding_an_item
        {
            private IList<Item> initialItems;

            [SetUp]
            public override void SetUp()
            {
                base.SetUp();
                initialItems = new List<Item> {
                    theItem
                };
                theInventory = Inventory.WithCapacityAndInitialItems(
                    inventorySize, initialItems);
            }

            [Test]
            public void It_fails()
            {
                var result = theInventory.AddItemToSlot(theItem, 0);
                Assert.That(result, Is.False);
            }

            [Test]
            public void The_inventorys_item_list_remains_the_same()
            {
                var expectedItems = new List<Item> {
                    theItem,
                    Item.NullItem,
                    Item.NullItem,
                    Item.NullItem
                };
                theInventory.AddItemToSlot(theItem, 0);
                Assert.That(theInventory.Items, Is.EquivalentTo(expectedItems));
            }
        }
	}
}
