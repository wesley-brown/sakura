using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    class When_removing_an_item
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

        protected readonly string templateName = "TestItem.asset";
        protected readonly ItemTemplate theTemplate;
        protected readonly IList<Item> initialItems;
        protected readonly int inventoryCapacity;
        protected readonly Inventory theInventory;
        protected readonly Item theItem;

        private When_removing_an_item()
        {
            theTemplate = AssetDatabase
                .LoadAssetAtPath<ItemTemplate>(path + templateName);
            theItem = Item.FromTemplate(theTemplate);
            initialItems = new List<Item> { theItem };
            inventoryCapacity = 2;
            theInventory = Inventory.WithCapacityAndInitialItems(
                inventoryCapacity, initialItems);
        }

        [TestFixture]
        sealed class From_an_occupied_inventory_slot : When_removing_an_item
        {
            [Test]
            public void The_item_in_that_inventory_slot_is_returned()
            {
                var removedItem = RemoveItemInFirstSlot();
                Assert.That(removedItem, Is.EqualTo(theItem));
            }

            [Test]
            public void The_null_item_fills_that_slot()
            {
                RemoveItemInFirstSlot();
                Assert.That(theInventory.Items[0], Is.EqualTo(Item.NullItem));
            }

            private Item RemoveItemInFirstSlot()
            {
                return theInventory.RemoveItemFromSlot(0);
            }
        }

        [TestFixture]
        public class From_an_unoccupied_inventory_slot : When_removing_an_item
        {
            [Test]
            public void The_null_item_is_returned()
            {
                var removedItem = theInventory.RemoveItemFromSlot(1);
                Assert.That(removedItem, Is.EqualTo(Item.NullItem));
            }
        }
    }
}
