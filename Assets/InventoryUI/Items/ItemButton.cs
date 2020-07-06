using UnityEngine;
using UnityEngine.UI;
using Sakura.Interactions;
using Sakura.Inventories.Runtime;
using System.Collections.Generic;

namespace Sakura.InventoryUI.Items
{
    /// <summary>
    /// A 
    /// </summary>
    [RequireComponent(typeof(SlotParameter))]
    [RequireComponent(typeof(SlotSelectionParameter))]
    [RequireComponent(typeof(InventoryPanelParameter))]
    [RequireComponent(typeof(ConditionListParameter))]
    public sealed class ItemButton : MonoBehaviour
    {
        private SlotParameter slotParameter = null;
        private SlotSelectionParameter slotSelectionParameter = null;
        private InventoryPanelParameter inventoryPanelParameter = null;
        private ConditionListParameter conditionListParameter = null;

        private Sprite icon = null;
        private Image image = null;
        private Button button = null;

        private void Awake()
        {
            slotParameter = GetComponent<SlotParameter>();
            inventoryPanelParameter = GetComponent<InventoryPanelParameter>();
            slotSelectionParameter = GetComponent<SlotSelectionParameter>();
            conditionListParameter = GetComponent<ConditionListParameter>();
            image = GetComponentInChildren<Image>();
            image.sprite = icon;
            button = GetComponentInChildren<Button>();
            button.onClick.AddListener(Respond);
        }

        private void Respond()
        {
            var conditions = conditionListParameter.Value;
            var allConditionsAreMet = true;
            foreach (var condition in conditions)
            {
                if (!condition.IsTrue)
                {
                    allConditionsAreMet = false;
                    break;
                }
            }
            if (allConditionsAreMet)
            {
                var slotSelection = slotSelectionParameter.Value;
                slotSelection.Invoke(slotParameter.Value);
            }
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
