using Sakura.StartGame.Domain;
using System;
using UnityEngine;

namespace Sakura.StartGame.UI
{
    /// <summary>
    /// An independent portion of a screen and its contents.
    /// </summary>
    public sealed class Window : MonoBehaviour
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
