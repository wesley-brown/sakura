using UnityEngine;
using UnityEngine.UI;
using Sakura.Inventories.Runtime;

namespace Sakura.InventoryUI.Items
{
    /// <summary>
    /// A 
    /// </summary>
    [RequireComponent(typeof(SlotParameter))]
    [RequireComponent(typeof(SlotSelectionParameter))]
    [RequireComponent(typeof(InventoryPanelParameter))]
    public sealed class ItemButton : MonoBehaviour
    {
        private SlotParameter slotParameter = null;
        private SlotSelectionParameter slotSelectionParameter = null;
        private InventoryPanelParameter inventoryPanelParameter = null;

        private Sprite icon = null;
        private Image image = null;
        private Button button = null;

        private void Awake()
        {
            slotParameter = GetComponent<SlotParameter>();
            inventoryPanelParameter = GetComponent<InventoryPanelParameter>();
            slotSelectionParameter = GetComponent<SlotSelectionParameter>();
            image = GetComponentInChildren<Image>();
            image.sprite = icon;
            button = GetComponentInChildren<Button>();
            button.onClick.AddListener(Respond);
            
        }

        private void Respond()
        {
            var slotSelection = slotSelectionParameter.Value;
            slotSelection.Invoke(slotParameter.Value);
        }

        private void Update()
        {
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            var item = inventoryPanelParameter.Value.Inventory.Items[slotParameter.Value.Number];
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
