using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A template from which items are created.
    /// </summary>
    [CreateAssetMenu(fileName = "New Item Template",
        menuName = "Inventories/Item Template")]
    public sealed class ItemTemplate : ScriptableObject
    {
        [SerializeField]
        private string externalItemName = "";
        [SerializeField]
        private string internalItemName = "";
        [SerializeField]
        private string itemDescription = "";
        [SerializeField]
        private string description = "";

        [SerializeField]
        private Sprite icon = null;

        /// <summary>
        /// The in-game name of items created from this template.
        /// </summary>
        public string ExternalItemName
        {
            get
            {
                return externalItemName;
            }
        }

        /// <summary>
        /// The internal name of items created from this item template.
        /// </summary>
        public string InternalItemName
        {
            get
            {
                return internalItemName;
            }
        }

        /// <summary>
        /// The in-game description of items created from this template.
        /// </summary>
        public string ItemDescription
        {
            get
            {
                return itemDescription;
            }
        }

        /// <summary>
        /// The internal description of this item template.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// A copy of the sprite that is used as this item's icon.
        /// </summary>
        public Sprite Icon
        {
            get
            {
                return Instantiate(icon);
            }
        }

        public override string ToString()
        {
            return "<ItemTemplate:" + " name=" + name + ">";
        }
    }
}
