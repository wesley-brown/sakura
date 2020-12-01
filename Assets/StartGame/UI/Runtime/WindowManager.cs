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

        private void Start()
        {
            if (!communicatesWith)
            {
                throw new InvalidOperationException(
                    "communicatesWith must not be null");
            }
        }
    }
}
