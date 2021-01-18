using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventureGame
{
    class Key : Item
    {
        private readonly string color;

        public Key(string color) : base(color + " key", ItemType.Key, $"this is a {color} key")
        {
            this.color = color;
        }

        public string FetchColor()
        {
            return color;
        }

        public Key GetKey()
        {
            return this;
        }

    }
}
