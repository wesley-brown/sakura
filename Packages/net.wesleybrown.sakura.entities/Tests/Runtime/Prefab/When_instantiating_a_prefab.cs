using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Sakura.Entities.Methods.Tests
{
    [TestFixture]
    internal abstract class When_instantiating_a_prefab
    {
        protected static readonly string testsPath =
            "Packages/"
            + "net.wesleybrown.sakura.entities/"
            + "Tests/"
            + "Runtime/"
            + "Prefab/";
        protected static readonly string testPrefabFilename =
            "testPrefab.prefab";
        protected static readonly string testPrefabPath =
            testsPath
            + testPrefabFilename;
        protected static readonly GameObject testPrefabPrefab =
            AssetDatabase
            .LoadAssetAtPath<GameObject>(testPrefabPath);

        protected Prefab testPrefab;

        [SetUp]
        public void SetUp()
        {
            testPrefab =
                Object
                .Instantiate(testPrefabPrefab)
                .GetComponent<Prefab>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(testPrefab.gameObject);
            testPrefab = null;
        }

        [TestFixture]
        internal class As_a_child_game_object : When_instantiating_a_prefab
        {
            [TestFixture]
            internal sealed class Of_a_given_entity :
                As_a_child_game_object
            {
                [UnityTest]
                public IEnumerator It_appears_as_a_child_of_that_entity()
                {
                    var instantiateAsChildOfEntity =
                        testPrefab
                        .GetComponent<InstantiateAsChildOfEntity>();
                    instantiateAsChildOfEntity.enabled = true;
                    yield return null;
                    var instantiatedGameObject =
                        instantiateAsChildOfEntity
                        .InstantiatedGameObject;
                    Assert.That(
                        instantiatedGameObject.transform.parent.gameObject,
                        Is.EqualTo(
                            instantiateAsChildOfEntity.Entity.GameObject));
                }
            }
        }

        [TestFixture]
        internal class As_a_root_game_object : When_instantiating_a_prefab
        {
            [TestFixture]
            internal sealed class At_the_same_location_as_a_given_entity :
                As_a_root_game_object
            {
                [UnityTest]
                public IEnumerator That_game_object_appears_at_that_location()
                {
                    var instantiateAtLocationOfEntity =
                        testPrefab
                        .GetComponent<InstantiateAtLocationOfEntity>();
                    instantiateAtLocationOfEntity.enabled = true;
                    yield return null;
                    var instantiatedGameObject =
                        instantiateAtLocationOfEntity
                        .InstantiatedGameObject;
                    Assert.That(
                        instantiatedGameObject.transform.position,
                        Is.EqualTo(instantiateAtLocationOfEntity.Location));
                }
            }
        }
    }
}
