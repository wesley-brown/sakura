using UnityEngine;

namespace Sakura.UI
{
    /// <summary>
    /// A view controller.
    /// </summary>
    /// <remarks>
    /// Each view controller will attempt to become the main view controller
    /// for the current scene during its Start() method.
    /// </remarks>
    public class ViewController : MonoBehaviour
    {
        public Window Window = null;

        protected virtual void Start()
        {
        }
    }
}
