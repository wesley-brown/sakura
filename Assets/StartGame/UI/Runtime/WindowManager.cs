using Sakura.StartGame.Domain;
using System;
using UnityEngine;

namespace Sakura.StartGame.UI
{
    /// <summary>
    /// Controls the placement and appearance of windows.
    /// </summary>
    public sealed class WindowManager : MonoBehaviour
    {
        [Header("Initialization")]
        public EventBus communicatesWith = null;
        public Window initialWindow = null;

        private Window activeWindow = null;

        public Window ActiveWindow
        {
            get
            {
                return activeWindow;
            }
        }

        private void Start()
        {
            if (!communicatesWith) throw new InvalidOperationException(
                "communicatesWith must not be null");
            activeWindow = initialWindow;
        }
    }
}
