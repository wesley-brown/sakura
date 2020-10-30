using Sakura.UI;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.PlantSeed.UI.Tests
{
    sealed class When_canceling_seed_planting
    {
        [UnityTest]
        public IEnumerator The_screen_is_destroyed()
        {
            var plantSeedScreen = new GameObject("Plant Seed Screen");
            plantSeedScreen.AddComponent<Window>();
            var screen = plantSeedScreen.AddComponent<Screen>();            
            screen.Cancel();
            yield return null;
            Assert.That(screen == null);
        }
    }
}
