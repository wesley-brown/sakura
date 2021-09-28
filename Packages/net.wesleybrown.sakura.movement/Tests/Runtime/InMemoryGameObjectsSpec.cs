using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sakura.Data;
using UnityEngine;

namespace In_Memory_Game_Objects_Spec
{
    [TestFixture]
    public class An_empty_collection_of_in_memory_game_objects
    {
        [Test]
        public void Has_no_game_objects()
        {
            var gameObjects = InMemoryGameObjects.Empty();
            var entity = new Guid("39de7404-4ac8-427a-9943-7a215ddc470b");
            Assert.IsNull(gameObjects.GameObjectForEntity(entity));
        }
    }

    [TestFixture]
    public class Creating_from_a_dictionary
    {
        [Test]
        public void Does_not_support_a_null_dictionary()
        {
            Dictionary<Guid, GameObject> initialGameObjects = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                InMemoryGameObjects.From(initialGameObjects);
            });
        }

        [Test]
        public void Includes_the_game_objects_in_that_dictionary()
        {
            var entity = new Guid("9713e6be-f68d-45af-856d-47d6229eff79");
            var gameObject = new GameObject();
            var initialGameObjects = new Dictionary<Guid, GameObject>
            {
                { entity, gameObject }
            };
            var gameObjects = InMemoryGameObjects.From(initialGameObjects);
            Assert.AreEqual(
                gameObject,
                gameObjects.GameObjectForEntity(entity));
        }
    }

    [TestFixture]
    public class Adding_a_game_object_for_an_entity
    {
        [Test]
        public void Does_not_support_a_null_game_object()
        {
            var entity = new Guid("166db526-42e6-4fdb-b4c3-212b5efed10e");
            GameObject gameObject = null;
            var gameObjects = InMemoryGameObjects.Empty();
            Assert.Throws<ArgumentNullException>(() =>
            {
                gameObjects.AddGameObjectForEntity(
                    gameObject,
                    entity);
            });
        }

        [Test]
        public void That_does_not_have_one_uses_that_game_object_for_that_entity()
        {
            var entity = new Guid("166db526-42e6-4fdb-b4c3-212b5efed10e");
            var gameObject = new GameObject();
            var gameObjects = InMemoryGameObjects.Empty();
            Assert.IsNull(gameObjects.GameObjectForEntity(entity));
            gameObjects.AddGameObjectForEntity(
                gameObject,
                entity);
            Assert.AreEqual(
                gameObject,
                gameObjects.GameObjectForEntity(entity));
        }
    }
}
