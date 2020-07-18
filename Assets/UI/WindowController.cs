using UnityEngine;

namespace Sakura.UI
{
    public class WindowController : MonoBehaviour
    {
        public Window Window = null;

        protected virtual void Start()
        {
            // This window controller was not set as the main window controller
            if (Window != null)
            {
                //Window.Display();
            }
        }
    }
}
