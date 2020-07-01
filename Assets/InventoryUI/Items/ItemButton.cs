using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura.InventoryUI.Items
{
    /// <summary>
    /// A 
    /// </summary>
    [RequireComponent(typeof(SlotParameter))]
    [RequireComponent(typeof(InventoryVariableParameter))]
    [RequireComponent(typeof(EventParameter))]
    public sealed class ItemButton : MonoBehaviour
    {
        private InventoryVariable inventoryVariable = null;
        private Slot slot = null;

        private EventParameter with = null;

        private Sprite icon = null;
        private Image image = null;
        private Button button = null;

        private void Awake()
        {
            var @for = GetComponent<SlotParameter>();
            slot = @for.Slot;

            var @in = GetComponent<InventoryVariableParameter>();
            inventoryVariable = @in.InventoryVariable;

            with = GetComponent<EventParameter>();

            image = GetComponentInChildren<Image>();
            image.sprite = icon;

            button = GetComponentInChildren<Button>();
            button.onClick.AddListener(Test);
            
        }

        private void Test()
        {
            var @event = with.Event;
            @event.Invoke();
        }

        private void Update()
        {
            UpdateSprite();
        }

        public void RemoveItemFromSlot()
        {
            inventoryVariable.Inventory.RemoveItemFromSlot(slot.Number);
        }

        private void UpdateSprite()
        {
            var item = inventoryVariable.Inventory.Items[slot.Number];
            if (item.Equals(Item.NullItem))
            {
                image.sprite = null;
            }
            else
            {
                image.sprite = item.Template.Icon;
            }
        }
    }
}
