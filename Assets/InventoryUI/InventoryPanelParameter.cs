using UnityEngine;

namespace Sakura.InventoryUI
{
    public sealed class InventoryPanelParameter : MonoBehaviour
    {
        public InventoryPanel Literal = null;
        public InventoryPanelParameter Reference = null;

        public InventoryPanel Value
        {
            get
            {
                if (Reference)
                {
                    return Reference.Value;
                }
                else
                {
                    return Literal;
                }
            }
        }
    }
}
