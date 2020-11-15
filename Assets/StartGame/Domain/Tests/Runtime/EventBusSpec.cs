using NUnit.Framework;
using UnityEngine;

namespace Sakura.StartGame.Domain.Tests
{
    sealed class EventBusSpec
    {
        [Test]
        public void Registering_an_unregistered_entity_succeeds()
        {
            var eventBus = ScriptableObject.CreateInstance<EventBus>();
            var player = new GameObject("Player");
            var playerEntity = player.AddComponent<Entity>();
            var playerWasRegistered = eventBus.Register(playerEntity);
            Assert.That(playerWasRegistered, Is.True);
        }
    }
}
