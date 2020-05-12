using System;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// An instance of an item template.
    /// </summary>
    public sealed class Item
	{
        private static readonly Item nullItem = new Item("Null Item", null);

        private readonly Guid id;
        private readonly string name;
        private readonly ItemTemplate template;

        /// <summary>
        /// Create a new item from an item template.
        /// </summary>
        /// <returns>
        /// A new item that is an instance of the given item template.
        /// </returns>
        public static Item FromTemplate(ItemTemplate template)
        {
            return new Item(template.ExternalItemName);
        }

        /// <summary>
        /// The null item.
        /// The null item is a special item that there is only one instance of.
        /// </summary>
        public static Item NullItem
        {
            get
            {
                return nullItem;
            }
        }

        /// <summary>
        /// Create a new item.
        /// </summary>
        /// <param name="name">
        /// The name of the new item.
        /// </param>
        public Item(string name)
        {
            id = Guid.NewGuid();
            this.name = name;
            template = null;
        }

        private Item(string name, ItemTemplate template)
        {
            id = Guid.NewGuid();
            this.name = name;
            this.template = template;
        }

        /// <summary>
        /// The unique identifier of this item.
        /// </summary>
        public Guid Id
        {
            get
            {
                return id;
            }
        }

        /// <summary>
        /// The name of this item.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// The item template from which this item was created.
        /// </summary>
        public ItemTemplate Template
        {
            get
            {
                return template;
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var otherInventoryItem = (Item) obj;
                return id == otherInventoryItem.id;
            }
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return "<Item: " + " Id=" + Id +  ", Name=" + Name + ", Template=" +
                Template + ">";
        }
    }
}
