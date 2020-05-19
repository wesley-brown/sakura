using UnityEngine;
using UnityEngine.UI;
using Sakura.Inventories.Runtime;

namespace Sakura.Runtime.InventoryUI
{
    /// <summary>
    /// Displays the icon of an item in an inventory.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public sealed class InventoryItemIconDisplayer : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference inventoryReference = null;

        [SerializeField]
        private int slotNumber = 0;

        private Inventory inventory = null;
        private Item item = Item.NullItem;
        private Image image = null;

        /// <summary>
        /// Update the sprite that is displayed to reflect the item currently
        /// in the slot this is displaying.
        /// </summary>
        public void UpdateSprite()
        {
            item = inventory.Items[slotNumber];
            if (!item.Equals(Item.NullItem))
            {
                image.sprite = item.Template.Icon;
            }
            else
            {
                image.sprite = null;
            }
        }

        private void Awake()
        {
            inventory = inventoryReference.Inventory;
            image = GetComponent<Image>();
            UpdateSprite();
        }
    }
}
