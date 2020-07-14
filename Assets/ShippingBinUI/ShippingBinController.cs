using Sakura.Inventories.Runtime;

namespace Sakura
{
    public sealed class ShippingBinController
    {
        private readonly Inventory inventory;

        public ShippingBinController(Inventory inventory)
        {
            this.inventory = inventory;
        }
    }
}
