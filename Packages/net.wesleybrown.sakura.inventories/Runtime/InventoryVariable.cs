using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    public sealed class InventoryVariable : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference @for = null;
        [SerializeField]
        private InventoryVariable referencing = null;

        private Inventory inventory = null;

        private void Awake()
        {
            if (@for != null)
            {
                inventory = @for.Inventory;
            }
            else
            {
                inventory = referencing.Inventory;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        public void RemoveItemFrom(Slot slot)
        {
            inventory.RemoveItemFromSlot(slot.Number);
        }
    }
}
