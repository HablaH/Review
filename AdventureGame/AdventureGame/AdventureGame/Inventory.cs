using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Inventory
    {
        private Dictionary<ItemType, List<Item>> Items;

        public Inventory()
        {
            Items = new Dictionary<ItemType, List<Item>>();
        }

        public void AddItem(Item item)
        {
            // Add dictionary item group
            if (!Items.ContainsKey(item.Type))
            {
                Items.Add(item.Type, new List<Item>());
            }

            // Add item to dictionary group
            Items[item.Type].Add(item);
        }

        public bool ContainsGroup(ItemType type)
        {
            return Items.ContainsKey(type);
        }

        public Item FetchItem(string name, ItemType group)
        {
            return Items[group].Find(i => i.Name == name);
        }

        public new string ToString()
        {
            string str = String.Empty;
            foreach (var group in Items)
            {
                foreach (var item in group.Value)
                {
                    str += item.Name + "\n";
                }
            }

            return str;
        }
    }
}
