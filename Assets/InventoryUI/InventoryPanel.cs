using UnityEngine;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura.InventoryUI
{
    [RequireComponent(typeof(SlotSelectionParameter))]
    [RequireComponent(typeof(InventoryVariableParameter))]
    [RequireComponent(typeof(ConditionListParameter))]
    public sealed class InventoryPanel : MonoBehaviour
    {
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
            inventoryVariableParameter = GetComponent<InventoryVariableParameter>();
        }
    }
}
