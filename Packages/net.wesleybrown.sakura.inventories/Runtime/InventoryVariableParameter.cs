using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A constructor parameter for an inventory variable.
    /// </summary>
    public sealed class InventoryVariableParameter : MonoBehaviour
    {
        public InventoryVariable Literal = null;
        public InventoryVariableParameter Reference = null;

        public InventoryVariable Value
        {
            get
            {
                Destroy(this);
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
