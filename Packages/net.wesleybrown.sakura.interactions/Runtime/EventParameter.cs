using UnityEngine;
using UnityEngine.Events;

namespace Sakura.Interactions
{
    /// <summary>
    /// A constructor parameter for an event.
    /// </summary>
    public sealed class EventParameter : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The literal value of the event to use as a parameter.")]
        private UnityEvent asLiteral = null;

        [SerializeField]
        [Tooltip("A reference to another event parameter to use the event value of.")]
        private EventParameter asReference = null;

        /// <summary>
        /// The event that this event parameter represents.
        /// </summary>
        public UnityEvent Event
        {
            get
            {
                // A UnityEvent will always be non-null even if its list of
                // callbacks is empty.
                if (asLiteral.GetPersistentEventCount() > 0)
                {
                    return asLiteral;
                }
                else
                {
                    return asReference.Event;
                }
            }
        }
    }
}
