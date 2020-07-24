using Sakura.Inventories.Runtime;
using Sakura.InventoryUI;
using Sakura.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Sakura
{
    [RequireComponent(typeof(WindowController))]
    public sealed class ShippingBinUIViewController : MonoBehaviour
    {
        [SerializeField]
        private NewInventoryUIViewController sellPanel = null;
        [SerializeField]
        private NewInventoryUIViewController keepPanel = null;
        [SerializeField]
        private InventoryReference playersInventory = null;
        [SerializeField]
        private InventoryReference shippingBinsInventory = null;
        [SerializeField]
        private WalletReference playersWallet = null;
        [SerializeField] private GameObject HUD = null;

        private void Start()
        {
            playersInventory.Subscribe(UpdateKeepPanel);
            shippingBinsInventory.Subscribe(UpdateSellPanel);
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
            var shippingBin = shippingBinsInventory.Inventory;
            var player = playersInventory.Inventory;
            for (var i = 0; i < shippingBin.Items.Count; ++i)
            {
                var item = shippingBin.RemoveItemFromSlot(i);
                player.Store(item);
            }
            DisplayHUD();
        }

        private void DisplayHUD()
        {
            Instantiate(HUD);
        }

        public void Confirm()
        {
            foreach (var item in shippingBinsInventory.Inventory.Items)
            {
                if (!item.Equals(Item.NullItem))
                {
                    playersWallet.Wallet.Add(100);
                }
            }
            Debug.Log(playersWallet.Wallet.Balance);
            shippingBinsInventory.Inventory.Clear();
            DisplayHUD();
        }

        private void OnDestroy()
        {
            playersInventory.Unsubscribe(UpdateKeepPanel);
            shippingBinsInventory.Unsubscribe(UpdateSellPanel);
        }
    }
}
