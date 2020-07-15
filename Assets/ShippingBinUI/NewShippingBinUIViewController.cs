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
        private InventoryReference playersInventory = null;
        [SerializeField]
        private InventoryReference shippingBinsInventory = null;

        private void Awake()
        {
            playersInventory.Subscribe(UpdateKeepPanel);
            shippingBinsInventory.Subscribe(UpdateSellPanel);
        }

        private void Start()
        {
            UpdateKeepPanel(playersInventory.Inventory);
            UpdateSellPanel(shippingBinsInventory.Inventory);
        }

        private void UpdateKeepPanel(Inventory inventory)
        {
            var items = inventory.Items;
            var buttons = keepPanel.GetComponentsInChildren<Button>();
            for (var i = 0; i < items.Count; ++i)
            {
                var item = items[i];
                if (item.Equals(Item.NullItem))
                {
                    buttons[i].GetComponent<Image>().sprite = null;
                }
                else
                {
                    buttons[i].GetComponent<Image>().sprite = item.Template.Icon;
                }
            }
        }

        private void UpdateSellPanel(Inventory inventory)
        {
            var items = inventory.Items;
            var buttons = sellPanel.GetComponentsInChildren<Button>();
            for (var i = 0; i < items.Count; ++i)
            {
                var item = items[i];
                if (item.Equals(Item.NullItem))
                {
                    buttons[i].GetComponent<Image>().sprite = null;
                }
                else
                {
                    buttons[i].GetComponent<Image>().sprite = item.Template.Icon;
                }
            }
        }

        public void SellItem(Button sender)
        {
            var slotNumber = sender.transform.GetSiblingIndex();
            var item = playersInventory.Inventory.RemoveItemFromSlot(slotNumber);
            shippingBinsInventory.Inventory.Store(item);
        }

        public void KeepItem(Button sender)
        {
            var slotNumber = sender.transform.GetSiblingIndex();
            if (!playersInventory.Inventory.IsFull)
            {
                var item = shippingBinsInventory.Inventory.RemoveItemFromSlot(slotNumber);
                playersInventory.Inventory.Store(item);
            }
        }

        public void Cancel()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            playersInventory.Unsubscribe(UpdateKeepPanel);
            shippingBinsInventory.Unsubscribe(UpdateSellPanel);
        }
    }
}
