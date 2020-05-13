using System;

namespace Sakura.Inventories.Runtime
{
    /// <summary>
    /// An instance of an item template.
    /// </summary>
    public sealed class Item
	{
        private static readonly Item nullItem = new Item("Null Item");

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
            if (template.Equals(null))
            {
                return nullItem;
            }
            else
            {
                return new Item(template);
            }
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

        private Item(string name)
        {
            id = Guid.NewGuid();
            this.name = name;
            template = null;
        }

        private Item(ItemTemplate template)
        {
            id = Guid.NewGuid();
            this.name = template.ExternalItemName;
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
