using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    public class When_checking_an_inventory_for_an_item_template
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";
        private static readonly string templateName = "TestItem.asset";

        private ItemTemplate theTemplate;

        private When_checking_an_inventory_for_an_item_template()
        {
            theTemplate = AssetDatabase
                .LoadAssetAtPath<ItemTemplate>(path + templateName);
        }

        [TestFixture]
        sealed class It_has : When_checking_an_inventory_for_an_item_template
        {
            [Test]
            public void It_succeeds()
            {
                var theItem = Item.FromTemplate(theTemplate);
                var initialItems = new List<Item> { theItem };
                var theInventory = Inventory
                    .WithCapacityAndInitialItems(1, initialItems);
                var theInventoryHasAnItemMadeFromTheTemplate = theInventory
                    .ContainsItemMadeFromTemplate(theTemplate);
                Assert.That(theInventoryHasAnItemMadeFromTheTemplate, Is.True);
            }
        }

        [TestFixture]
        sealed class It_doesnt_have
            : When_checking_an_inventory_for_an_item_template
        {
            [Test]
            public void It_fails()
            {
                var theInventory = Inventory.WithCapacityAndEmpty(1);
                var theInventoryHasAnItemMadeFromTheTemplate = theInventory
                    .ContainsItemMadeFromTemplate(theTemplate);
                Assert.That(theInventoryHasAnItemMadeFromTheTemplate, Is.False);
            }
        }
    }
}
