using System;

namespace AdventureGame
{
    class Game
    {
        public Room[] map;
        public static Door[] doors;
        public static Player player;
        
        private bool victory = false;


        public Game()
        {
            SetUpGame();
            
            Console.WriteLine(player.name);
            Intro();


            while (!victory)
            {
                HandleCommand(Console.ReadLine());
                ShowRoom();
            }



            //HandleCommand(player1, Console.ReadLine());
            //Console.WriteLine($"{player1.name} has {player1.ShowInventory()}");
            //Console.WriteLine($"on the floor you see {player1.currentRoom.key}");
        }

        public void HandleCommand(string command)
        {
            // Unlock red door
            string[] parameters = command.ToLower().Split(' ');

            // Evaluate 
            Console.Clear();
            switch (parameters[0]) 
            {
                case "unlock": player.UnlockDoor(parameters[1]); break;
                case "enter": player.Enter(parameters[1]); break;
                case "pickup": player.PickUp(player.currentRoom.key); break;
                case "inventory": Console.WriteLine(player.inventory.ToString()); break;
                case "inspect": break;
            }
            return;
        }

        Room[] CreateMap()
        {
            return new Room[]
            {
                new Room('A', "red"),
                new Room('B', "green"),
                new Room('C', "black"),
                new Room('D', "blue"),
                new Room('E', "yellow"),
                new Room('F',  null),
            };
        }

        Door[] CreateDoors(Room[] map)
        {
            return new Door[]
            {
                new Door("red", map),
                new Door("green", map),
                new Door("yellow", map),
                new Door("blue", map),
                new Door("black", map),
            };
        }

        void Intro()
        {
            Console.WriteLine($"Welcome, {player.name}.");
            Console.WriteLine("You awaken and find yourself in a dark room");
            ShowRoom();
        }

        void ShowRoom()
        {
            Key key = player.currentRoom.key;
            Door[] currentDoors = player.currentRoom.ConnectedDoors();
            string keyText = key != null ? $"On the floor you see a {key.FetchColor()} key." : "There is nothing here..";
            string isAre = currentDoors.Length == 1 ? "is" : "are";
            string doorDoors = currentDoors.Length == 1 ? "door" : "doors";


            Console.WriteLine(keyText);
            Console.WriteLine($"There {isAre} {currentDoors.Length} {doorDoors} leading out of the room.");
            foreach (Door door in currentDoors)
            {
                string lockedDoor = door.locked ? "locked" : "unlocked";
                Console.WriteLine($"One door is {door.color}, it is {lockedDoor} ");
            }
        }

        void SetUpGame()
        {
            map = CreateMap();
            doors = CreateDoors(map);
            Console.WriteLine("Enter player name:");
            player = new Player(Console.ReadLine());
            player.currentRoom = map[0];
        }

        void Outro()
        {
            Console.WriteLine("You finally see the light.");
            Console.WriteLine("From this room you can finally get out!");
            Console.WriteLine("Ctrl + C");
            Console.ReadLine();
            
        }
    }
}
