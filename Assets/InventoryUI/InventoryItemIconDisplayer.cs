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

        private void Awake()
        {
            inventory = inventoryReference.Inventory;
            item = inventory.Items[slotNumber];
            image = GetComponent<Image>();

            if (!item.Equals(Item.NullItem))
            {
                image.sprite = item.Template.Icon;
            }
            else
            {
                image.sprite = null;
            }
        }
    }
}
