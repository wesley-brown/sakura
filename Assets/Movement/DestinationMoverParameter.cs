using UnityEngine;

namespace Sakura.Movement
{
    /// <summary>
    /// A constructor parameter for a destination mover.
    /// </summary>
    public sealed class DestinationMoverParameter : MonoBehaviour
    {
        public DestinationMover Literal = null;
        public DestinationMoverParameter Reference = null;

        public DestinationMover Value
        {
            get
            {
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
