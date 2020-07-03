using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A constructor parameter for a slot selection event.
    /// </summary>
    public sealed class SlotSelectionParameter : MonoBehaviour
    {
        public SlotSelection Literal = null;
        public SlotSelectionParameter Reference = null;

        /// <summary>
        /// The slot selection event that this slot selection parameter
        /// represents.
        /// </summary>
        public SlotSelection Value
        {
            get
            {
                // Check Reference because it can be implicitly converted to a
                // bool which allows us to avoid checking it against null and
                // using Unity.Object's overloaded == operator.
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
