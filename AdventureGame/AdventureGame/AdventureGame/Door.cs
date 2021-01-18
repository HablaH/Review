namespace AdventureGame
{
    class Door
    {
        public bool locked = true;
        public string color;
        public Room[] connectedRooms;

        public Door(string color, Room[] rooms)
        {
            this.color = color;
            FromTo(color, rooms);
        }

        public void FromTo(string color, Room[] rooms)
            {
                if (color == "red") connectedRooms = new Room[] { rooms[0], rooms[1]};
                if (color == "green") connectedRooms = new Room[] { rooms[0], rooms[3]};
                if (color == "yellow") connectedRooms = new Room[] { rooms[1], rooms[2]};
                if (color == "blue") connectedRooms = new Room[] { rooms[1], rooms[4]};
                if (color == "black") connectedRooms = new Room[] { rooms[4], rooms[5]};
            }

        public void Unlock()
        {
            locked = false;
        }

        public Room GetRoom(Room currentRoom)
        {
            return currentRoom == connectedRooms[0] ? connectedRooms[1] : connectedRooms[0];
        }
    }
}
