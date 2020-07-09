using UnityEngine;
using UnityEngine.UI;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;

namespace Sakura.InventoryUI.Items
{
    /// <summary>
    /// A UI button that produces a slot selection event when interacted with.
    /// </summary>
    [RequireComponent(typeof(SlotParameter))]
    [RequireComponent(typeof(InventoryVariableParameter))]
    public sealed class SlotSelectionButton : MonoBehaviour
    {
        private SlotParameter slotParameter = null;
        private InventoryVariableParameter inventoryVariableParameter = null;
        private Responder<Slot> responder = null;

        private Sprite icon = null;
        private Image image = null;
        private Button button = null;

        private void Awake()
        {
            slotParameter = GetComponent<SlotParameter>();
            inventoryVariableParameter =
                GetComponent<InventoryVariableParameter>();

            responder = GetComponentInParent<Responder<Slot>>();

            image = GetComponentInChildren<Image>();
            image.sprite = icon;
            button = GetComponentInChildren<Button>();
            button.onClick.AddListener(Respond);
        }

        private void Respond()
        {
            if (responder != null)
            {
                responder.RespondTo(slotParameter.Value);
            }
        }

        private void Update()
        {
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            var item = inventoryVariableParameter.InventoryVariable.Inventory
                .Items[slotParameter.Value.Number];
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
