using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public enum ItemType {Other, Key}

    class Item
    {
        public string Name;
        public ItemType Type;
        private readonly string Description;

        public Item(string name, ItemType type, string description = "nothing")
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public string Inspect()
        {
            return Description;
        }
    }
}
