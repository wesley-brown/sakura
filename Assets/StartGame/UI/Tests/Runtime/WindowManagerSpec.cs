using NUnit.Framework;
using Sakura.StartGame.Domain;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sakura.StartGame.UI.Tests
{
    class A_window_manager
    {
        protected Simulation theSimulation;
        protected GameObject eventBusGameObject;
        protected EventBus theEventBus;
        protected GameObject windowManagerGameObject;

        [SetUp]
        public virtual void SetUp()
        {
            theSimulation = ScriptableObject.CreateInstance<Simulation>();
            eventBusGameObject = new GameObject("Event Bus");
            theEventBus = eventBusGameObject.AddComponent<EventBus>();
            theEventBus.forSimulation = theSimulation;
            windowManagerGameObject = new GameObject("Window Manager");
        }

        [TearDown]
        public virtual void TearDown()
        {
            Object.Destroy(theSimulation);
            Object.Destroy(eventBusGameObject);
            Object.Destroy(windowManagerGameObject);
        }

        class Created : A_window_manager
        {
            sealed class Without_an_event_bus : Created
            {
                [UnityTest]
                public IEnumerator Is_invalid()
                {
                    var windowManager = windowManagerGameObject
                        .AddComponent<WindowManager>();
                    yield return null;
                    LogAssert.Expect(
                        LogType.Exception,
                        "InvalidOperationException: communicatesWith must " +
                        "not be null");
                }
            }

            sealed class With_a_window : Created
            {
                private GameObject windowGameObject;
                private Window theWindow;

                [SetUp]
                public override void SetUp()
                {
                    base.SetUp();
                    windowGameObject = new GameObject("Window");
                    theWindow = windowGameObject.AddComponent<Window>();
                    theWindow.communicatesWith = theEventBus;
                }

                [TearDown]
                public override void TearDown()
                {
                    base.TearDown();
                    Object.Destroy(windowGameObject);
                }

                [UnityTest]
                public IEnumerator Has_that_as_its_active_window()
                {
                    var windowManager = windowManagerGameObject
                        .AddComponent<WindowManager>();
                    windowManager.communicatesWith = theEventBus;
                    windowManager.initialWindow = theWindow;
                    yield return null;
                    Assert.That(
                        windowManager.ActiveWindow,
                        Is.EqualTo(theWindow));
                }
            }
        }
    }
}
