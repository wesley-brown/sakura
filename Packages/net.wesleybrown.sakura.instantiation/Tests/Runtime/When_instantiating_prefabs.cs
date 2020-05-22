using NUnit.Framework;
using UnityEngine;
using UnityEditor;

namespace Sakura.Instantiation.Tests
{
    sealed class When_instantiating_prefabs
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

            [Test]
            public void They_have_no_parent()
            {
                var globalGameObjectPrefab = AssetDatabase
                    .LoadAssetAtPath<GameObject>(globalGameObjectPrefabPath);
                var globalGameObject = globalGameObjectPrefab
                    .GetComponent<GlobalGameObject>();
                var newGlobalGameObject = globalGameObject.AppearInScene();
                Assert.That(
                    newGlobalGameObject.transform.parent,
                    Is.EqualTo(null));
            }
        }
    }
}
