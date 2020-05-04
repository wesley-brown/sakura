using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventory.Tests
{
    sealed class When_checking_an_inventory
    {
        [TestFixture]
        sealed class For_an_existing_item
        {
            [Test]
            public void It_succeeds()
            {
                var potatoSeed = new InventoryItem("Potato Seed");
                var initialItems = new List<InventoryItem> { potatoSeed };
                var inventory =
                    Inventory.WithCapacityAndInitialItems(1, initialItems);
                var hasPotatoSeed = inventory.Contains(potatoSeed);
                Assert.That(hasPotatoSeed, Is.True);
            }
        }
    }
}
