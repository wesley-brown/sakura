using UnityEngine.Events;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// An event representing an inventory that was updated in some way.
    /// </summary>
    public sealed class InventoryUpdate : UnityEvent<Inventory>
    {
        //private readonly Inventory inventory;

        //public InventoryUpdate(Inventory inventory)
        //{
        //    this.inventory = inventory;
        //}

        //public Inventory Inventory
        //{
        //    get
        //    {
        //        return inventory;
        //    }
        //}
    }
}
