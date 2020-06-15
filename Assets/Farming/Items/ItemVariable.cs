using UnityEngine;
using Sakura.Inventories.Runtime;

namespace Sakura.Runtime
{
    /// <summary>
    /// A game object hierarchy representation of an item.
    /// </summary>
    public sealed class ItemVariable : MonoBehaviour
    {
        [SerializeField]
        private ItemTemplate fromTemplate = null;

        private ItemTemplate itemTemplate = null;

        private void Awake()
        {
            itemTemplate = fromTemplate;
        }

        public Item Item
        {
            get
            {
                return Item.FromTemplate(itemTemplate);
            }
        }
    }
}
