using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.StartGame.Domain.Tests
{
    sealed class EventBusSpec
    {
        [UnityTest]
        public IEnumerator Registering_an_unregistered_entity_adds_it_to_the_simulation()
        {
            var simulation = ScriptableObject.CreateInstance<Simulation>();
            var eventBusGameObject = new GameObject("Event Bus");
            var eventBus = eventBusGameObject.AddComponent<EventBus>();
            eventBus.forSimulation = simulation;
            var player = new GameObject("Player");
            var playerEntity = player.AddComponent<Entity>();
            yield return null;
            eventBus.Register(playerEntity);
            Assert.That(simulation.Entities, Does.Contain(playerEntity));
            Object.Destroy(simulation);
            Object.Destroy(eventBusGameObject);
            Object.Destroy(player);
        }
    }
}
