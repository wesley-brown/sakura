using Sakura.StartGame.Domain;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.StartGame.UI.Tests
{
    public sealed class WindowManagerSpec
    {
        [UnityTest]
        public IEnumerator Window_managers_created_without_an_event_bus_are_invalid()
        {
            var simulation = ScriptableObject.CreateInstance<Simulation>();
            var eventBusGameObject = new GameObject("Event Bus");
            var eventBus = eventBusGameObject.AddComponent<EventBus>();
            eventBus.forSimulation = simulation;
            var windowManagerGameObject = new GameObject("Window Manager");
            var windowManager = windowManagerGameObject
                .AddComponent<WindowManager>();
            yield return null;
            LogAssert.Expect(
                LogType.Exception,
                "InvalidOperationException: communicatesWith must not be null");
            Object.Destroy(simulation);
            Object.Destroy(eventBusGameObject);
            Object.Destroy(windowManagerGameObject);
        }
    }
}
