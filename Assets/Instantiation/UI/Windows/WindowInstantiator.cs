using Sakura.Events.Interactions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sakura.Instantiation.UI.Windows
{
    /// <summary>
    /// Creates new instances of windows.
    /// </summary>
    public sealed class WindowInstantiator :
        MonoBehaviour,
        SuccessfulInteractionReceiver
    {
        [SerializeField] private GameObject window = null;

        public void Receive()
        {
            InstantiateWindow();
        }

        private void InstantiateWindow()
        {
            var instantiatedWindow = Instantiate(window);
            var windowCreated = new WindowCreated(gameObject);
            ExecuteEvents.Execute<WindowCreationHandler>(
                instantiatedWindow,
                null,
                (target, data) => target.OnWindowCreated(windowCreated));
        }
    }
}
