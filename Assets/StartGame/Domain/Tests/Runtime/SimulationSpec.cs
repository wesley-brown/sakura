using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.StartGame.Domain.Tests
{
    sealed class SimulationSpec
    {
        [UnityTest]
        public IEnumerator Included_entities_appear_in_the_list_of_all_entities()
        {
            var simulation = ScriptableObject.CreateInstance<Simulation>();
            var player = new GameObject("Player");
            var playerEntity = player.AddComponent<Entity>();
            simulation.Include(playerEntity);
            yield return null;
            Assert.That(simulation.Entities, Does.Contain(playerEntity));
        }
    }
}
