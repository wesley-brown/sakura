using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    class When_checking_an_inventory
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

        private readonly string templateName = "TestItem.asset";
        protected readonly ItemTemplate theTemplate;
        protected Item theItem;
        protected Inventory theInventory;

        private When_checking_an_inventory()
        {
            theTemplate = AssetDatabase
                .LoadAssetAtPath<ItemTemplate>(path + templateName);
            theItem = Item.FromTemplate(theTemplate);
        }
        
        [TestFixture]
        sealed class For_an_existing_item : When_checking_an_inventory
        {
            private IList<Item> initialItems;

            [SetUp]
            public void SetUp()
            {
                initialItems = new List<Item> { theItem };
                theInventory =
                    Inventory.WithCapacityAndInitialItems(1, initialItems);
            }

            [Test]
            public void It_succeeds()
            {
                var hasTheItem = theInventory.Contains(theItem);
                Assert.That(hasTheItem, Is.True);
            }
        }

        [TestFixture]
        sealed class For_a_nonexistent_item : When_checking_an_inventory
        {
            [SetUp]
            public void SetUp()
            {
                theInventory = Inventory.WithCapacityAndEmpty(1);
            }

            [Test]
            public void It_fails()
            {
                var hasTheItem = theInventory.Contains(theItem);
                Assert.That(hasTheItem, Is.False);
            }
        }
    }
}
