using UnityEngine;

namespace Sakura.UI
{
    /// <summary>
    /// An MVC controller for a window with a game object as its contet view.
    /// </summary>
    /// <remarks>
    /// A window controller will cause any game object it is attached to to act
    /// as the content view for a "window" upon creation. Only one "window" can
    /// exist on screen at a time so having multiple game object's with
    /// window controller components will cause the last window controller that
    /// ran its Start method to act as the one "window" on screen, destroying
    /// all the others.
    /// </remarks>
    [RequireComponent(typeof(MainHook))]
    public sealed class WindowController : MonoBehaviour
    {
        private void Start()
        {
            var main = GetComponent<MainHook>().Main;
            main.RegisterWindowController(this);
        }

        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}
