using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventureGame
{
    class Room
    {
        public Key key;
        public char roomName;


        public Room(char roomName, string color)
        {
            this.roomName = roomName;
            this.key = new Key(color);
        }

        public Door[] ConnectedDoors()
        {
            return AdventureGame.Game.doors.Where(d => d.connectedRooms.Contains(this)).ToArray();
        }
    }
}
