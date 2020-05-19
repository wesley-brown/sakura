using UnityEngine;
using Sakura.Inventories.Runtime;

namespace Sakura.Interactions
{
    /// <summary>
    /// Removes the item from a given inventory slot.
    /// </summary>
    public sealed class InventorySlotItemRemover : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference inventoryReference = null;
        private Inventory inventory = null;

        /// <summary>
        /// Remove the item at the given inventory slot.
        /// </summary>
        /// <param name="slotNumber">The slot to remove the item from.</param>
        public void RemoveItemFromInventory(int slotNumber)
        {
            inventory.RemoveItemFromSlot(slotNumber);
        }

        private void Awake()
        {
            inventory = inventoryReference.Inventory;
        }
    }
}
