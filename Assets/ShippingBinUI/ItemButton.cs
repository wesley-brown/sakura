using UnityEngine;
using UnityEngine.UI;
using Sakura.Inventories.Runtime;

namespace Sakura
{
    /// <summary>
    /// A 
    /// </summary>
    public sealed class ItemButton : MonoBehaviour
    {
        [SerializeField]
        private Slot @for = null;

        [SerializeField]
        [Tooltip("The inventory from which to access the given slot of.")]
        private InventoryReference of = null;

        private Inventory inventory = null;
        private Sprite icon = null;
        private Image image = null;

        private void Awake()
        {
            inventory = of.Inventory;
            icon = inventory.Items[@for.Number].Template.Icon;
            image = GetComponentInChildren<Image>();
            image.sprite = icon;
        }
    }
}
