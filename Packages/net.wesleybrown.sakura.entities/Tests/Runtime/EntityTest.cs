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
        private List<GameObject> initialRootGameObjects;
        private GameObject gameObject;
        private GameObjectParameter gameObjectParameter;
        private Entity entity;

        [SetUp]
        public void SetUp()
        {
            initialRootGameObjects = new List<GameObject>(
                SceneManager.GetActiveScene().GetRootGameObjects());
            gameObject = new GameObject();
            gameObjectParameter = gameObject
                .AddComponent<GameObjectParameter>();
            gameObjectParameter.Literal = gameObject;
            entity = gameObject.AddComponent<Entity>();
        }

        [UnityTearDown]
        public void TearDown()
        {
            gameObject = null;
            entity = null;
            gameObjectParameter = null;
        }


        [UnityTest]
        public IEnumerator Its_game_object_is_destroyed_the_next_frame()
        {
            entity.Destroy();
            yield return null;
            var actualRootGameObjects = new List<GameObject>(
                SceneManager.GetActiveScene().GetRootGameObjects());
            Assert.That(
                actualRootGameObjects,
                Is.EqualTo(initialRootGameObjects));
        }
    }
}
