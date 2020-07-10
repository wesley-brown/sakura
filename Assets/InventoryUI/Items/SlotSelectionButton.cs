using Sakura.Interactions;
using Sakura.Inventories.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Sakura.InventoryUI.Items
{
    /// <summary>
    /// A UI button that produces a slot selection event when interacted with.
    /// </summary>
    public sealed class SlotSelectionButton : MonoBehaviour, Responder<Slot>
    {
        private Slot slot = null;
        private Inventory inventory = null;
        private Responder<Slot> nextResponder = null;

        //private Sprite icon = null;
        private Image image = null;

        private void Awake()
        {
            var slotParameter = GetComponent<SlotParameter>();
            slot = slotParameter.Value;
            var inventoryVariableParameter =
                GetComponent<InventoryVariableParameter>();
            inventory = inventoryVariableParameter.Value.Inventory;
            // Using just GetComponentInParent would result in this
            // SlotSelectionButton being returned, resulting in a stack
            // overflow, because the GetComponentInParent method first checks
            // the object it is called on and then any parents.
            nextResponder = transform.parent.gameObject
                .GetComponent<Responder<Slot>>();
            image = GetComponentInChildren<Image>();
        }

        public void RespondTo(Slot slot)
        {
            nextResponder.RespondTo(slot);
        }

        private void Update()
        {
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            var item = inventory.Items[slot.Number];
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
