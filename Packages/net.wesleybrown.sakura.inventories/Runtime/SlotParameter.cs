using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A constructor parameter for a slot.
    /// </summary>
    public sealed class SlotParameter : MonoBehaviour
    {
        public Slot Literal = null;
        public SlotParameter Reference = null;

        public Slot Value
        {
            get
            {
                Destroy(this);
                if (Reference)
                {
                    return Reference.Value;
                }
                else
                {
                    return Literal;
                }
            }
        }
    }
}
