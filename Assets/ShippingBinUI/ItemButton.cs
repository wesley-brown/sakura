using UnityEngine;
using UnityEngine.UI;
using Sakura.Inventories.Runtime;

namespace Sakura
{
    /// <summary>
    /// A 
    /// </summary>
    [RequireComponent(typeof(InventoryVariable))]
    [RequireComponent(typeof(Slot))]
    public sealed class ItemButton : MonoBehaviour
    {
        private InventoryVariable inventoryVariable = null;
        private Slot slot = null;
        private Sprite icon = null;
        private Image image = null;

        private void Awake()
        {
            inventoryVariable = GetComponent<InventoryVariable>();
            slot = GetComponent<Slot>();
            image = GetComponentInChildren<Image>();
            image.sprite = icon;
        }

        private void Start()
        {
            UpdateSprite();
        }

        private void Update()
        {
            UpdateSprite();
        }

        public void RemoveItemFromSlot()
        {
            inventoryVariable.Inventory.RemoveItemFromSlot(slot.Number);
            //UpdateSprite();
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
