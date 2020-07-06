using UnityEngine;
using Sakura.Inventories.Runtime;

namespace Sakura.Interactions
{
    [RequireComponent(typeof(SlotParameter))]
    [RequireComponent(typeof(InventoryVariableParameter))]
    public sealed class ItemTypeCondition : Condition
    {
        [SerializeField]
        private ItemType type = null;

        private SlotParameter slotParameter = null;
        private InventoryVariableParameter inventoryVariableParameter = null;

        private void Awake()
        {
            slotParameter = GetComponent<SlotParameter>();
            inventoryVariableParameter =
                GetComponent<InventoryVariableParameter>();
        }

        public override bool IsTrue
        {
            get
            {
                return inventoryVariableParameter.InventoryVariable
                    .Inventory
                    .Items[slotParameter.Value.Number]
                    .Template
                    .Type
                    .Equals(type);
            }
        }
    }
}
