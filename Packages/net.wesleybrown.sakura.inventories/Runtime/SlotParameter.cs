using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A constructor parameter for a slot.
    /// </summary>
    public sealed class SlotParameter : MonoBehaviour
    {
        [SerializeField]
        private Slot asLiteral = null;

        [SerializeField]
        private SlotParameter asReference = null;

        public Slot Slot
        {
            get
            {
                if (asLiteral != null)
                {
                    return asLiteral;
                }
                else
                {
                    return asReference.Slot;
                }
            }
        }
    }
}
