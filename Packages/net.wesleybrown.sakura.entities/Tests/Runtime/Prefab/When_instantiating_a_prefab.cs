using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Sakura.Entities.Methods.Tests
{
    internal sealed class When_instantiating_a_prefab
    {
        [TestFixture]
        internal sealed class At_the_same_location_as_a_given_entity
        {
            private static readonly string testsPath =
                "Packages/"
                + "net.wesleybrown.sakura.entities/"
                + "Tests/"
                + "Runtime/"
                + "Prefab/";
            private static readonly string testPrefabFilename =
                "testPrefab.prefab";
            private static readonly string testPrefabPath =
                testsPath
                + testPrefabFilename;
            private static readonly GameObject testPrefabPrefab =
                AssetDatabase
                .LoadAssetAtPath<GameObject>(testPrefabPath);

            private Prefab testPrefab;

            [SetUp]
            public void SetUp()
            {
                testPrefab =
                    Object
                    .Instantiate(testPrefabPrefab)
                    .GetComponent<Prefab>();
            }

            [UnityTest]
            public IEnumerator The_instantiated_game_object_appears_at_that_location()
			{
                var testPrefabInstantiateAtLocationOfEntity =
                    testPrefab
                    .GetComponent<InstantiateAtLocationOfEntity>();
                testPrefabInstantiateAtLocationOfEntity.enabled = true;
                yield return null;
                var instantiatedGameObject =
                    testPrefabInstantiateAtLocationOfEntity
                    .InstantiatedGameObject;
                Assert.That(
                    instantiatedGameObject.transform.position,
                    Is.EqualTo(testPrefabInstantiateAtLocationOfEntity.Location));
			}
        }
    }
}
