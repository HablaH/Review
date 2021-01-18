using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace AdventureGame
{
    class Player 
    {
        public Inventory inventory = new Inventory();
        public string name;
        public Room currentRoom;

        public Player(string _name)
        {
            name = _name;
        }

        public void PickUp(Key key)
        {
            inventory.AddItem(key);
            currentRoom.key = null;
        }

        public void UnlockDoor(string color)
        {
            // Does inventory contain keys group
            if (!inventory.ContainsGroup(ItemType.Key)) return;
            // Does key group contain this color

            Item key = inventory.FetchItem(color +" key", ItemType.Key);

            // Does this room contain a door with this color
            foreach (var door in currentRoom.ConnectedDoors())
            {
                if (door.color == color && key != null) door.Unlock();
            }

        }

        public void Enter(string color)
        {
            foreach (var door in currentRoom.ConnectedDoors())
            {
                if (door.color == color && !door.locked)
                { 
                    currentRoom = door.GetRoom(currentRoom); 
                }
            }

            Console.WriteLine($"you entered {color} room");

        }
    }
}
