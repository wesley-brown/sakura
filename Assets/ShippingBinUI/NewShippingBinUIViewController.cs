using Sakura.InventoryUI;
using UnityEngine;
using UnityEngine.UI;

namespace Sakura
{
    public sealed class NewShippingBinUIViewController : MonoBehaviour
    {
        [SerializeField]
        private NewInventoryUIViewController sellPanel;
        [SerializeField]
        private NewInventoryUIViewController keepPanel;

        public void SellItem(Button sender)
        {
            var slotNumber = sender.transform.GetSiblingIndex();
        }
    }
}
