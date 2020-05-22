using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Sakura.Instantiation.Tests
{    
    class When_putting_a_root_entity_in_a_scene
    {
        private static readonly string path = "Packages/" +
            "net.wesleybrown.sakura.entities/" + "Tests/" + "Runtime/";
        private static readonly string rootEntityPrefabFilename =
            "TestRootEntity.prefab";
        private static readonly string rootEntityPrefabPath =
            path + rootEntityPrefabFilename;

        protected RootEntity rootEntity;

        public When_putting_a_root_entity_in_a_scene()
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
            private GameObject other;
            private Scene scene;

            [SetUp]
            public void SetUp()
            {
                other = new GameObject("Other");
                other.transform.position = new Vector3(1.0f, 1.0f, 1.0f);
                scene = SceneManager.GetActiveScene();
            }

            [Test]
            public void It_appears_in_the_scene()
            {
                rootEntity.AppearInSceneAtLocationOf(other); 
                var rootGameObject = rootEntity.GameObject;
                var allGameObjects = new List<GameObject>();
                scene.GetRootGameObjects(allGameObjects);
                Assert.That(allGameObjects.Contains(rootGameObject));
            }

            [Test]
            public void It_appears_at_the_given_location()
            {
                rootEntity.AppearInSceneAtLocationOf(other);
                var rootGameObject = rootEntity.GameObject;
                Assert.That(
                    rootGameObject.transform.position,
                    Is.EqualTo(other.transform.position));
            }
        }
    }
}
