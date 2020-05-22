using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Sakura.Instantiation.Tests
{
    sealed class When_instantiating_a_prefab
    {
        [TestFixture]
        sealed class Globally
        {
            private static string path = "Packages/" +
                "net.wesleybrown.sakura.instantiation/" + "Tests/" + "Runtime/";
            private static string globalGameObjectFilename =
                "GlobalGameObject.prefab";
            private static string globalGameObjectPrefabPath =
                path + globalGameObjectFilename;

            private GlobalGameObject globalGameObject;

            [SetUp]
            public void SetUp()
            {
                var globalGameObjectPrefab = AssetDatabase
                    .LoadAssetAtPath<GameObject>(globalGameObjectPrefabPath);
                globalGameObject = globalGameObjectPrefab
                    .GetComponent<GlobalGameObject>();
            }

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
                Assert.That(
                    allGameObjects.Contains(newGlobalGameObject),
                    Is.True);
            }
        }
    }
}
