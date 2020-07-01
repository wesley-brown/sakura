using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A constructor parameter for an inventory variable.
    /// </summary>
    public sealed class InventoryVariableParameter : MonoBehaviour
    {
        [SerializeField]
        private InventoryVariable asLiteral = null;
        [SerializeField]
        private InventoryVariableParameter asReference = null;

        public InventoryVariable InventoryVariable
        {
            get
            {
                if (asLiteral != null)
                {
                    return asLiteral;
                }
                else
                {
                    return asReference.InventoryVariable;
                }
            }
        }
    }
}
