﻿using NUnit.Framework;
using System.Collections.Generic;

namespace Sakura.Inventories.Runtime.Tests
{
    class When_adding_an_item
	{
        protected Inventory inventory;
        protected readonly int inventorySize = 4;
        protected Item potatoSeed;

        private When_adding_an_item()
        {
            potatoSeed = new Item("Potato Seed");
        }

        [TestFixture]
        sealed class To_an_unoccupied_inventory_slot : When_adding_an_item
        {
            [SetUp]
            public void SetUp()
            {
                inventory = Inventory.WithCapacityAndEmpty(inventorySize);
            }

            [Test]
            public void It_succeeds()
            {
                var result = inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(result, Is.True);
            }

            [Test]
            public void That_item_is_put_in_the_list_of_all_inventory_items()
            {
                var expectedItemList = new List<Item>() {
                    potatoSeed,
                    Item.NullItem,
                    Item.NullItem,
                    Item.NullItem
                };
                inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(inventory.Items, Is.EquivalentTo(expectedItemList));
            }
        }

        [TestFixture]
        sealed class To_an_occupied_inventory_slot : When_adding_an_item
        {
            private IList<Item> initialItems;

            [SetUp]
            public void SetUp()
            {
                initialItems = new List<Item> {
                    potatoSeed
                };
                inventory = Inventory.WithCapacityAndInitialItems(
                    inventorySize, initialItems);
            }

            [Test]
            public void It_fails()
            {
                var result = inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(result, Is.False);
            }

            [Test]
            public void The_inventorys_item_list_remains_the_same()
            {
                var expectedItems = new List<Item> {
                    potatoSeed,
                    Item.NullItem,
                    Item.NullItem,
                    Item.NullItem
                };
                inventory.AddItemToSlot(potatoSeed, 0);
                Assert.That(inventory.Items, Is.EquivalentTo(expectedItems));
            }
        }
	}
}
