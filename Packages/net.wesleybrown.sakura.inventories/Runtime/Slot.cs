using Sakura.Parameters.Primitives;
using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A slot in an inventory.
    /// </summary>
    public sealed class Slot : MonoBehaviour
    {
        private IntVariable number = null;

        private void Awake()
        {
            var literal = GetComponent<IntVariableParameter>();
            if (literal)
            {
                number = literal.Value;
            }
        }

        private void Start()
        {
            var reference = GetComponent<SlotParameter>();
            if (reference)
            {
                number = reference.Value.number;
            }
        }

        public int Number
        {
            get
            {
                return number.Value;
            }
        }
    }
}
