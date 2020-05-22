using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Sakura.Instantiation.Tests
{
    [SetUpFixture]
    public class When_putting_a_global_game_object_in_a_scene
    {
        private static string path = "Packages/" +
            "net.wesleybrown.sakura.instantiation/" + "Tests/" + "Runtime/";
        private static string globalGameObjectFilename =
            "TestGlobalGameObject.prefab";
        private static string globalGameObjectPrefabPath =
            path + globalGameObjectFilename;

        protected GlobalGameObject globalGameObject;

        [OneTimeSetUp]
        public void SetUp()
        {
            var globalGameObjectPrefab = AssetDatabase
                .LoadAssetAtPath<GameObject>(globalGameObjectPrefabPath);
            globalGameObject = globalGameObjectPrefab
                .GetComponent<GlobalGameObject>();
        }

        [TestFixture]
        sealed class At_no_specific_location :
            When_putting_a_global_game_object_in_a_scene
        {
            [Test]
            public void It_has_no_parent()
            {
                var newGlobalGameObject = globalGameObject.AppearInScene();
                Assert.That(
                    newGlobalGameObject.transform.parent,
                    Is.EqualTo(null));
            }

            [Test]
            public void It_appears_in_the_current_scene()
            {
                var newGlobalGameObject = globalGameObject.AppearInScene();
                var allGameObjects = new List<GameObject>();
                var scene = SceneManager.GetActiveScene();
                scene.GetRootGameObjects(allGameObjects);
                Assert.That(allGameObjects.Contains(newGlobalGameObject));
            }
        }

        [TestFixture]
        sealed class At_the_same_location_as_another_game_object :
            When_putting_a_global_game_object_in_a_scene
        {
            [Test]
            public void It_appears_in_the_scene()
            {
                var other = new GameObject("Other");
                other.transform.position = new Vector3(1.0f, 1.0f, 1.0f);
                globalGameObject.AppearInSceneAtLocationOf(other);
                var allGameObjects = new List<GameObject>();
                var scene = SceneManager.GetActiveScene();
                scene.GetRootGameObjects(allGameObjects);
                Assert.That(
                    allGameObjects.Contains(globalGameObject.GameObject));
            }
        }
    }
}
