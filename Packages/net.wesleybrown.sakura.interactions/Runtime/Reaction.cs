using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Interactions
{
    /// <summary>
    /// A reaction.
    /// </summary>
    public sealed class Reaction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onInteract = null;

        public void React()
        {
            onInteract.Invoke();
        }
    }

    
}
