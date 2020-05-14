using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    public class When_checking_an_inventory_for_an_item_template
    {
        [TestFixture]
        sealed class It_has : When_checking_an_inventory_for_an_item_template
        {
            private static readonly string path = "Packages/" +
                "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

            private readonly string templateName = "TestItem.asset";

            [Test]
            public void It_succeeds()
            {
                var theTemplate = AssetDatabase
                    .LoadAssetAtPath<ItemTemplate>(path + templateName);
                var theItem = Item.FromTemplate(theTemplate);
                var initialItems = new List<Item> { theItem };
                var theInventory = Inventory
                    .WithCapacityAndInitialItems(1, initialItems);
                var theInventoryHasAnItemMadeFromTheTemplate = theInventory
                    .ContainsItemMadeFromTemplate(theTemplate);
                Assert.That(theInventoryHasAnItemMadeFromTheTemplate, Is.True);
            }
        }
    }
}
