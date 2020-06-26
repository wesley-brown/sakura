using UnityEngine;
using UnityEngine.UI;
using Sakura.Inventories.Runtime;

namespace Sakura
{
    public sealed class ItemButton : MonoBehaviour
    {
        [SerializeField]
        private int forSlot = 0;
        private int slot = 0;
        [SerializeField]
        [Tooltip("The inventory from which to access the given slot of.")]
        private InventoryReference of = null;
        private Inventory inventory = null;
        private Sprite icon = null;
        private Image image = null;

        private void Awake()
        {
            slot = forSlot;
            inventory = of.Inventory;
            icon = inventory.Items[slot].Template.Icon;
            image = GetComponentInChildren<Image>();
            image.sprite = icon;
        }
    }
}
