using NUnit.Framework;

namespace Sakura.Inventory.Tests
{
    [TestFixture]
    sealed class When_comparing_items
    {
        private InventoryItem potatoSeed;

        [SetUp]
        public void SetUp()
        {
            potatoSeed = new InventoryItem("Potato Seed");
        }

        [Test]
        public void Identical_items_have_the_same_hash_codes()
        {
            var potatoSeedClone = new InventoryItem("Potato Seed");
            Assert.That(potatoSeedClone.GetHashCode(),
                Is.EqualTo(potatoSeed.GetHashCode()));
        }

        [Test]
        public void Identical_items_are_equal()
        {
            var potatoSeedClone = new InventoryItem("Potato Seed");
            Assert.That(potatoSeedClone, Is.EqualTo(potatoSeed));
        }
    }
}
