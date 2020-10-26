using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.UI.Tests
{
    sealed class When_closing_a_window
    {
        [UnityTest]
        public IEnumerator Its_game_object_is_destroyed()
        {
            var inventoryScreen = new GameObject("Inventory Screen");
            var window = inventoryScreen.AddComponent<Window>();
            window.Close();
            yield return null;
            Assert.That(inventoryScreen == null);
        }
    }
}
