using Sakura.Inventories.Runtime;
using Sakura.InventoryUI;
using UnityEngine;
using UnityEngine.UI;

namespace Sakura
{
    public sealed class NewShippingBinUIViewController : MonoBehaviour
    {
        [SerializeField]
        private NewInventoryUIViewController sellPanel = null;
        [SerializeField]
        private NewInventoryUIViewController keepPanel = null;
        [SerializeField]
        private InventoryReference inventoryReference = null;
        [SerializeField]
        private ItemTemplate template = null;

        private void Awake()
        {
            inventoryReference.Subscribe(UpdateButtonIcons);
            UpdateButtonIcons(inventoryReference.Inventory);
        }

        private void UpdateButtonIcons(Inventory inventory)
        {
            var items = inventory.Items;
            var buttons = keepPanel.GetComponentsInChildren<Button>();
            for (var i = 0; i < items.Count; ++i)
            {
                var item = items[i];
                buttons[i].GetComponent<Image>().sprite = item.Template.Icon;
            }
        }

        public void SellItem(Button sender)
        {
            var slotNumber = sender.transform.GetSiblingIndex();
        }

        private void OnDestroy()
        {
            inventoryReference.Unsubscribe(UpdateButtonIcons);
        }
    }
}
