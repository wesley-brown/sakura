using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Sakura.Entities.Tests
{
    [TestFixture]
    public sealed class EntityTest
    {
        private GameObject gameObject;
        private Entity entity;

        [SetUp]
        public void SetUp()
        {
            gameObject = new GameObject();
            entity = gameObject.AddComponent<Entity>();
        }

        [TearDown]
        public void TearDown()
        {
            gameObject = null;
            entity = null;
        }


        [UnityTest]
        public IEnumerator Its_game_object_is_destroyed_the_next_frame()
        {
            entity.Destroy();
            yield return null;
            var rootGameObjects = new List<GameObject>(
                SceneManager.GetActiveScene().GetRootGameObjects());
            Assert.That(rootGameObjects.Contains(gameObject), Is.False);
        }
    }
}
