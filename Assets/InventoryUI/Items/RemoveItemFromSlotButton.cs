using UnityEngine;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura.InventoryUI.Items
{
    [RequireComponent(typeof(SlotParameter))]
    [RequireComponent(typeof(InventoryVariableParameter))]
    [RequireComponent(typeof(EventParameter))]
    public sealed class RemoveItemFromSlotButton : MonoBehaviour
    {
        private Slot slot = null;
        private InventoryVariable inventoryVariable = null;

        private void Awake()
        {
            var @for = GetComponent<SlotParameter>();
            slot = @for.Slot;
            var @in = GetComponent<InventoryVariableParameter>();
            inventoryVariable = @in.InventoryVariable;
        }

        //private void Start()
        //{
        //    var @with = GetComponent<EventParameter>();
        //    @with.Event.Invoke();
        //}
    }
}
