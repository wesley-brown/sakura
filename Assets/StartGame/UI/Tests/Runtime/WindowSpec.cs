using Sakura.StartGame.Domain;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.StartGame.UI.Tests
{
    public sealed class WindowSpec
    {
        [UnityTest]
        public IEnumerator Windows_created_without_an_event_bus_are_invalid()
        {
            var simulation = ScriptableObject.CreateInstance<Simulation>();
            var eventBusGameObject = new GameObject("Event Bus");
            var eventBus = eventBusGameObject.AddComponent<EventBus>();
            eventBus.forSimulation = simulation;
            var windowGameObject = new GameObject("Window");
            var window = windowGameObject.AddComponent<Window>();
            yield return null;
            LogAssert.Expect(
                LogType.Exception,
                "InvalidOperationException: communicatesWith must not be null");
            Object.Destroy(simulation);
            Object.Destroy(eventBusGameObject);
            Object.Destroy(windowGameObject);
        }
    }
}
