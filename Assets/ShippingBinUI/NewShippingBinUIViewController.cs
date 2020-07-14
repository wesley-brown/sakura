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
            inventoryReference.Subscribe(Test);
        }

        public void Test(Inventory inventory)
        {
            Debug.Log("Inventory Updated!");
        }

        public void SellItem(Button sender)
        {
            var slotNumber = sender.transform.GetSiblingIndex();
        }
    }
}
