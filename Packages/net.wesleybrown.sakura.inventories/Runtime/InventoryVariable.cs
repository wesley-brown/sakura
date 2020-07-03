using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A component representation of an inventory.
    /// </summary>
    public sealed class InventoryVariable : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference @for = null;

        private Inventory inventory = null;

        private void Awake()
        {
            inventory = @for.Inventory;
        }

        /// <summary>
        /// The inventory that this inventory variable represents.
        /// </summary>
        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        /// <summary>
        /// Remove the item in the given slot from this inventory.
        /// </summary>
        /// <param name="slot">The slot of the item to remove.</param>
        public void RemoveItemFrom(Slot slot)
        {
            inventory.RemoveItemFromSlot(slot.Number);
        }
    }
}
