using NUnit.Framework;
using UnityEditor;

namespace Sakura.Inventories.Runtime.Tests
{
    [TestFixture]
    sealed class When_comparing_items
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.inventories/" + "Tests/" + "Runtime/";

        private readonly string templateName = "TestItem.asset";

        [Test]
        public void Each_inventory_item_is_unique()
        {
            var theTemplate = AssetDatabase
                .LoadAssetAtPath<ItemTemplate>(path + templateName);
            var theFirstItem = Item.FromTemplate(theTemplate);
            var theSecondItem = Item.FromTemplate(theTemplate);
            Assert.That(theSecondItem, Is.Not.EqualTo(theFirstItem));
        }
    }
}
