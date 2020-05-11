using NUnit.Framework;

namespace Sakura.Inventories.Runtime.Tests
{
    [TestFixture]
    sealed class When_comparing_items
    {
        [Test]
        public void Each_inventory_item_is_unique()
        {
            var firstPotatoSeed = new InventoryItem("Potato Seed");
            var secondPotatoSeed = new InventoryItem("Potato Seed");
            Assert.That(secondPotatoSeed, Is.Not.EqualTo(firstPotatoSeed));
        }
    }
}
