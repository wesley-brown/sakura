using UnityEngine;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura.InventoryUI
{
    [RequireComponent(typeof(SlotSelectionParameter))]
    [RequireComponent(typeof(InventoryVariableParameter))]
    public sealed class InventoryPanel : Responder<Slot>
    {
        [SerializeField]
        private ItemType requiredType = null;
        private SlotSelectionParameter slotSelectionParameter = null;
        private InventoryVariableParameter inventoryVariableParameter = null;

        public Inventory Inventory
        {
            get
            {
                return inventoryVariableParameter.InventoryVariable.Inventory;
            }
        }

        private void Awake()
        {
            slotSelectionParameter = GetComponent<SlotSelectionParameter>();
            inventoryVariableParameter =
                GetComponent<InventoryVariableParameter>();
        }

        public override void RespondTo(Slot slot)
        {
            if (Inventory.Items[slot.Number].Template.Type.Equals(requiredType))
            {
                slotSelectionParameter.Value.Invoke(slot);
            }
        }
    }
}
