using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A reference to an inventory.
    /// </summary>
    [CreateAssetMenu(fileName = "InventoryReference",
        menuName = "Inventories/Inventory")]
    public sealed class InventoryReference : ScriptableObject
	{
        private Inventory inventory = null;

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        private void OnEnable()
        {
            inventory = Inventory.WithCapacityAndEmpty(4);
        }
    }
}
