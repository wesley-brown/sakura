using UnityEngine;
using UnityEngine.Events;
using Sakura.Inventories.Runtime;
using System;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// Causes a game object to react to inventory slot item type conditions.
    /// </summary>
    public sealed class InventorySlotTypeConditionReactor : MonoBehaviour
	{
        [SerializeField] private InventoryReference inventoryReference = null;
        [SerializeField] private int slot = 0;
        [SerializeField] private ItemType type = null;
        [SerializeField] private UnityEvent whenTrue = null;

        private Inventory inventory = null;

        public void React()
        {
            var itemInSlot = inventory.Items[slot];
            if (itemInSlot != Item.NullItem && itemInSlot.Type.Equals(type))
            {
                whenTrue.Invoke();
            }
        }

        private void Awake()
        {
            if (inventoryReference == null)
            {
                throw new InvalidOperationException(
                    "inventoryReference must not be null");
            }
            else if (slot < 0)
            {
                throw new InvalidOperationException("slot must be >= 0");
            }
            else if (type == null)
            {
                throw new InvalidOperationException("type must not be null");
            }
            else
            {
                inventory = inventoryReference.Inventory;
            }
        }
    }
}
