using NUnit.Framework;

namespace Sakura.Inventory
{
    sealed class WhenDealingWithItems
    {
        [Test]
        public void Identical_inventory_items_have_the_same_hash_codes()
        {
            var firstPotatoSeed = new InventoryItem("Potato Seed");
            var secondPotatoSeed = new InventoryItem("Potato Seed");
            Assert.That(secondPotatoSeed.GetHashCode(),
                Is.EqualTo(firstPotatoSeed.GetHashCode()));
        }
    }
}
