using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zork
{
    internal class Game
    {

        public World World { get; set; }

        public Player Player { get; set; }


        public void Run()
        {
            InitializeRoomDescriptions();

            Room previousRoom = null;

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(Player.CurrentRoom);

                if (previousRoom != Player.CurrentRoom && !Player.CurrentRoom.HasBeenVisited)
                {
                    Console.WriteLine(Player.CurrentRoom.Description);
                    previousRoom = Player.CurrentRoom;
                    Player.CurrentRoom.HasBeenVisited = true;
                }

                Console.Write(">");

                string inputString = Console.ReadLine().Trim();
                Commands command; command = ToCommand(inputString);

                string outputString;
                switch (command)
                {
                    case Commands.Quit:
                        outputString = "Thank you for playing!";
                        isRunning = false;
                        break;

                    case Commands.Look:
                        outputString = Player.CurrentRoom.Description;
                        break;

                    case Commands.North:
                    case Commands.West:
                    case Commands.South:
                    case Commands.East:
                        if (Player.Move(command))
                        {
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut.";
                        }
                        break;


                    default:
                        outputString = "Unkown command.";
                        break;
                }
                Console.WriteLine(outputString);
            }
        }

        private void InitializeRoomDescriptions()
        {

            var roomMap = new Dictionary<string, Room>();

            foreach (Room room in World.Rooms) //Add all our rooms to the dictionary using their Name fields as the key
            {
                roomMap[room.Name] = room; //same as .Add();
            }

            roomMap["Rocky Trail"].Description      = "You are on a rock-strewn trail.";
            roomMap["South of House"].Description   = "You are facing the south side of a white house. There is no door/";
            roomMap["Canyon View"].Description      = "You are at the top of the Great Canyon on its south wall.";
            roomMap["Forest"].Description           = "This is a forest, with trees in all directions around you.";
            roomMap["West of House"].Description    = "This is an open field west of a white house, wih a boarded front door/";
            roomMap["Behind House"].Description     = "You are behind the white house. In one corner of teh house there is/";
            roomMap["Dense Woods"].Description      = "This is a dimly lit forest, with large trees all around. To the east/";
            roomMap["North of House"].Description   = "You are facing the north side of a white house. There is no door here/";
            roomMap["Clearing"].Description         = "You are in a clearing, with a forest surrounding you on the west and/";
        }

        static Commands ToCommand(string commmandString)
        {
            return Enum.TryParse(commmandString, true, out Commands result) ? result : Commands.Unknown;
        }

    }

}