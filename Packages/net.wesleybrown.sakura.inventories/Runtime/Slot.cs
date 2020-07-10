using UnityEngine;
using System;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A slot in an inventory.
    /// </summary>
    public sealed class Slot : MonoBehaviour
    {
        [SerializeField]
        private int number = 0;

        private void Awake()
        {
            var slotParameter = GetComponent<SlotParameter>();
            if (slotParameter)
            {
                number = slotParameter.Value.Number;
            }
            else
            {
                if (number < 0)
                {
                    throw new InvalidOperationException("Number must be >= 0.");
                }
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
        }
    }
}
