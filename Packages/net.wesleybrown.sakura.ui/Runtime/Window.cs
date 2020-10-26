using UnityEngine;

namespace Sakura.UI
{
    /// <summary>
    /// Represents an independent portion of a screen and its contents.
    /// </summary>
    public sealed class Window : MonoBehaviour
    {
        /// <summary>
        /// Close this window.
        /// </summary>
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}
