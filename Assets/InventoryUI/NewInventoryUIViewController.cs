using Sakura.Inventories.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sakura.InventoryUI
{
    public sealed class NewInventoryUIViewController : MonoBehaviour
    {
        [SerializeField]
        private InventoryReference inventoryReference = null;
        [SerializeField]
        private GameObject buttonPrefab = null;
        [SerializeField]
        private UnityEvent<Button> onSlotSelection = null;

        private ScrollRect scrollRect = null;
        private Inventory inventory = null;

        public ScrollRect ScrollRect
        {
            get
            {
                return scrollRect;
            }
        }

        private void Awake()
        {
            scrollRect = GetComponentInChildren<ScrollRect>();
            inventory = inventoryReference.Inventory;
            for (var i = 0; i < inventory.Capacity; ++i)
            {
                var button = Instantiate(buttonPrefab, scrollRect.content);
                button.SetActive(true);
            }
        }

        public void SelectSlot(Button sender)
        {
            onSlotSelection.Invoke(sender);
        }
    }
}
