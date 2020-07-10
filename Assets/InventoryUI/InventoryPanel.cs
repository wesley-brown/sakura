using Sakura.Interactions;
using Sakura.Inventories.Runtime;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// Displays an inventory.
    /// </summary>
    [RequireComponent(typeof(SlotSelectionParameter))]
    public sealed class InventoryPanel : MonoBehaviour, Responder<Slot>
    {
        [SerializeField]
        private ItemType requiredType = null;
        private SlotSelectionParameter slotSelectionParameter = null;
        private Inventory inventory = null;

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        private void Awake()
        {
            slotSelectionParameter = GetComponent<SlotSelectionParameter>();
            var inventoryVariableParameter =
                GetComponent<InventoryVariableParameter>();
            inventory = inventoryVariableParameter.Value.Inventory;
        }

        public void RespondTo(Slot slot)
        {
            if (inventory.Items[slot.Number].Template.Type.Equals(requiredType))
            {
                slotSelectionParameter.Value.Invoke(slot);
            }
        }
    }
}
