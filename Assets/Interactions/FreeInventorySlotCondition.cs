using UnityEngine;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura
{
    /// <summary>
    /// A condition based on whether or not a given inventory has a free slot
    /// or not.
    /// </summary>
    public sealed class FreeInventorySlotCondition : Condition
    {
        [SerializeField]
        private InventoryReference forInventory = null;
        private Inventory inventory = null;

        private void Awake()
        {
            inventory = forInventory.Inventory;
        }

        public override bool IsTrue
        {
            get
            {
                return !inventory.IsFull;
            }
        }
    }
}
