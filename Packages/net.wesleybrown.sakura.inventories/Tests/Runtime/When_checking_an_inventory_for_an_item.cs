using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    class When_checking_an_inventory_for_an_item
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

        private readonly string templateName = "TestItem.asset";
        protected readonly ItemTemplate theTemplate;
        protected Item theItem;
        protected Inventory theInventory;

        private When_checking_an_inventory_for_an_item()
        {
            theTemplate = AssetDatabase
                .LoadAssetAtPath<ItemTemplate>(path + templateName);
            theItem = Item.FromTemplate(theTemplate);
        }
        
        [TestFixture]
        class It_has : When_checking_an_inventory_for_an_item
        {
            protected IList<Item> initialItems;

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
        sealed class It_doesnt_have : When_checking_an_inventory_for_an_item
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
