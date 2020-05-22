using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Sakura.Instantiation.Tests
{
    [SetUpFixture]
    public class When_putting_a_root_entity_in_a_scene
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.entities/" + "Tests/" + "Runtime/";
        private static readonly string rootEntityPrefabFilename =
            "TestRootEntity.prefab";
        private static readonly string rootEntityPrefabPath =
            path + rootEntityPrefabFilename;

        protected RootEntity rootEntity;

        [OneTimeSetUp]
        public void SetUp()
        {
            var rootEntityPrefab = AssetDatabase
                .LoadAssetAtPath<GameObject>(rootEntityPrefabPath);
            rootEntity = rootEntityPrefab
                .GetComponent<RootEntity>();
        }

        [TestFixture]
        sealed class At_no_specific_location :
            When_putting_a_root_entity_in_a_scene
        {
            [Test]
            public void It_has_no_parent()
            {
                rootEntity.AppearInScene();
                var rootGameObject = rootEntity.GameObject;
                Assert.That(rootGameObject.transform.parent, Is.EqualTo(null));
            }

            [Test]
            public void It_appears_in_the_current_scene()
            {
                rootEntity.AppearInScene();
                var rootGameObject = rootEntity.GameObject;
                var allGameObjects = new List<GameObject>();
                var scene = SceneManager.GetActiveScene();
                scene.GetRootGameObjects(allGameObjects);
                Assert.That(allGameObjects.Contains(rootGameObject));
            }

            [Test]
            public void It_appears_at_the_origin()
            {
                rootEntity.AppearInScene();
                Assert.That(
                    rootEntity.GameObject.transform.position,
                    Is.EqualTo(Vector3.zero));
            }
        }

        [TestFixture]
        sealed class At_the_same_location_as_another_game_object :
            When_putting_a_root_entity_in_a_scene
        {
            [Test]
            public void It_appears_in_the_scene()
            {
                var other = new GameObject("Other");
                other.transform.position = new Vector3(1.0f, 1.0f, 1.0f);
                rootEntity.AppearInSceneAtLocationOf(other);
                var allGameObjects = new List<GameObject>();
                var rootGameObject = rootEntity.GameObject;
                var scene = SceneManager.GetActiveScene();
                scene.GetRootGameObjects(allGameObjects);
                Assert.That(allGameObjects.Contains(rootGameObject));
            }
        }
    }
}
