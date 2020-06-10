using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

namespace Sakura.Entities.Methods.Tests
{
    [TestFixture]
    public class When_instantiating_a_prefab
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
        public virtual void SetUp()
        {
            testPrefab =
                Object
                .Instantiate(testPrefabPrefab)
                .GetComponent<Prefab>();
        }

        class As_a_child_game_object : When_instantiating_a_prefab
        {
            class Of_a_given_entity : As_a_child_game_object
            {
                class At_no_specific_location : Of_a_given_entity
                {
                    private InstantiateAsChildOfEntity method;

                    [SetUp]
                    public override void SetUp()
                    {
                        base.SetUp();
                        method =
                            testPrefab
                            .GetComponent<InstantiateAsChildOfEntity>();
                    }

                    [UnityTest]
                    public IEnumerator It_appears_as_a_child_of_that_entity()
                    {
                        method.enabled = true;
                        yield return null;
                        var instantiatedGameObject =
                            method
                            .InstantiatedGameObject;
                        Assert.That(
                            instantiatedGameObject.transform.parent.gameObject,
                            Is.EqualTo(
                                method.Entity.GameObject));
                    }
                }

                class At_the_location_of_an_entity : Of_a_given_entity
                {
                    private InstantiateAsChildOfAtLocationOf method;

                    [SetUp]
                    public override void SetUp()
                    {
                        base.SetUp();
                        method =
                            testPrefab
                            .GetComponent<InstantiateAsChildOfAtLocationOf>();
                    }

                    [UnityTest]
                    public IEnumerator It_appears_as_a_child_at_that_location()
                    {
                        method.enabled = true;
                        yield return null;
                        var instantiatedGameObject =
                            method
                            .InstantiatedGameObject;
                        Assert.That(
                            instantiatedGameObject.transform.position,
                            Is.EqualTo(method.Location));
                    }
                }
            }
        }

        class As_a_root_game_object : When_instantiating_a_prefab
        {
            class At_the_same_location_as_a_given_entity : As_a_root_game_object
            {
                private InstantiateAtLocationOfEntity method;

                [SetUp]
                public override void SetUp()
                {
                    base.SetUp();
                    method =
                        testPrefab
                        .GetComponent<InstantiateAtLocationOfEntity>();
                }

                [UnityTest]
                public IEnumerator That_game_object_appears_at_that_location()
                {
                    method.enabled = true;
                    yield return null;
                    var instantiatedGameObject =
                        method
                        .InstantiatedGameObject;
                    Assert.That(
                        instantiatedGameObject.transform.position,
                        Is.EqualTo(method.Location));
                }
            }
        }
    }
}
