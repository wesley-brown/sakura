﻿using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    class When_checking_an_inventory
    {
        protected Item potatoSeed;
        protected Inventory inventory;

        private When_checking_an_inventory()
        {
            potatoSeed = new Item("Potato Seed");
        }
        
        [TestFixture]
        sealed class For_an_existing_item : When_checking_an_inventory
        {
            private IList<Item> initialItems;

            [SetUp]
            public void SetUp()
            {
                initialItems = new List<Item> { potatoSeed };
                inventory =
                    Inventory.WithCapacityAndInitialItems(1, initialItems);
            }

            [Test]
            public void It_succeeds()
            {
                var hasPotatoSeed = inventory.Contains(potatoSeed);
                Assert.That(hasPotatoSeed, Is.True);
            }
        }

        [TestFixture]
        sealed class For_a_nonexistent_item : When_checking_an_inventory
        {
            [SetUp]
            public void SetUp()
            {
                inventory = Inventory.WithCapacityAndEmpty(1);
            }

            [Test]
            public void It_fails()
            {
                var hasPotatoSeed = inventory.Contains(potatoSeed);
                Assert.That(hasPotatoSeed, Is.False);
            }
        }
    }
}
