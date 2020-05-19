using UnityEngine;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// A type of an item used for classification.
    /// </summary>
    [CreateAssetMenu(
        fileName = "NewItemType",
        menuName = "Inventories/Item Type")]
    public sealed class ItemType : ScriptableObject
	{
        [SerializeField] private string displayName = "";
        [SerializeField] private string description = "";

        /// <summary>
        /// The in game name of this item type.
        /// </summary>
        public string DisplayName
        {
            get
            {
                return displayName;
            }
        }

        /// <summary>
        /// The in game description of this item type.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
        }

        public override string ToString()
        {
            return "<ItemType DisplayName=" + DisplayName + ">";
        }
    }
}