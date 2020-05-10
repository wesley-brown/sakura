using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Interactions
{
    /// <summary>
    /// Allows a game object to react to being interacted with.
    /// </summary>
    public sealed class InteractionReactor : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onInteract = null; 

        /// <summary>
        /// React to being interacted with.
        /// </summary>
        public void React()
        {
            if (onInteract != null)
            {
                onInteract.Invoke();
            }
        }
    }
}
