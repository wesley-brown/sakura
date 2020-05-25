using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;

namespace Sakura.Entities.Entity.Methods.Tests
{
    [TestFixture]
    internal sealed class When_destroying_an_entity
    {
        private static readonly string testsPath =
            "Packages/"
            + "net.wesleybrown.sakura.entities/"
            + "Tests/"
            + "Runtime/";
        private static readonly string testEntityFilename = "testEntity.prefab";
        private static readonly string testEntityPath =
            testsPath
            + testEntityFilename;
        private static readonly GameObject testEntityPrefab = AssetDatabase
            .LoadAssetAtPath<GameObject>(testEntityPath);

        private Entity testEntity;

        [SetUp]
        public void SetUp()
        {
            testEntity = Object
                .Instantiate(testEntityPrefab)
                .GetComponent<Entity>();
        }

        [UnityTest]
        public IEnumerator Its_game_object_is_removed_from_the_current_scene()
        {
            DestroyEntity();
            // Destroyed game objects aren't removed from the scene until the
            // next frame.
            yield return null;
            var rootGameObjects = RootGameObjects;
            Assert.That(
                rootGameObjects.Contains(testEntity.GameObject),
                Is.False);
        }

        private void DestroyEntity()
        {
            var testEntityDestroy = testEntity.GetComponent<Destroy>();
            testEntityDestroy.enabled = true;
        }

        private static IList<GameObject> RootGameObjects
        {
            get
            {
                var rootGameObjects = new List<GameObject>();
                var scene = SceneManager.GetActiveScene();
                scene.GetRootGameObjects(rootGameObjects);
                return rootGameObjects;
            }
        }
    }
}
