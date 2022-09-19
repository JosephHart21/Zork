using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Zork
{
	class Program
	{
        static void Main()
        {
			InitializeRoomDescriptions();
			Console.WriteLine("Welcome to Zork!");
			
			bool isRunning = true;
			while (isRunning)
			{
				Console.Write($"You are in {CurrentRoom}\n> ");
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
						outputString = CurrentRoom.Description;
						break;
						
					case Commands.North:
					case Commands.West:
					case Commands.South:
					case Commands.East:
						if (Move(command))
						{
							outputString = $"You moved {command}.";
						}
						else
						{
							outputString = "The way is shut.";
						}
						break;
						
						
					default: outputString = "Unkown command.";
						break;
				}
				Console.WriteLine(outputString);
			}
        }
		
		static Commands ToCommand(string commmandString)
		{
			return Enum.TryParse(commmandString, true, out Commands result) ? result : Commands.Unknown;
		}

		private static bool Move(Commands command)
		{
			bool didMove = false;
			switch (command)
			{
				case Commands.North when _location.Row < _rooms.GetLength(0) - 1:
					_location.Row++;
                    didMove = true;
                    break;

                case Commands.South when _location.Row > 0:
					_location.Row--;
                    didMove = true;
                    break;

                case Commands.East when _location.Column < _rooms.GetLength(1) -1:
					_location.Column++;
                    didMove = true;
                    break;

                case Commands.West when _location.Column > 0:
					_location.Column--;
                    didMove = true;
                    break;
                    
			}
			return didMove;
		}

        private static readonly Room[,] _rooms = {
            {new Room("Rocky Trail"), new Room ("South of House"), new Room ("Canyon View")},
            {new Room ("Forest"),new Room ("West of House"),new Room ("Behind House")},
            {new Room ("Dense Woods"),new Room ("North of House"),new Room ("Clearing")}
        };

		private static void InitializeRoomDescriptions()
		{

			Dictionary<string, Room> roomMap = new Dictionary<string, Room>();

			foreach(Room room in _rooms) //Add all our rooms to the dictionary using their Name fields as the key
			{
				roomMap[room.Name] = room; //same as .Add();
			}

			roomMap["Rocky Trail"].Description = "You are on a rock-stream trail.";
            roomMap["South of House"].Description = "You are facing the south side of a white house. There is no door/";
            roomMap["Canyon View"].Description = "You are at the top of the Great Canyon on its south wall.";
            roomMap["Forest"].Description = "This is a forest, with trees in all directions around you.";
            roomMap["West of House"].Description = "This is an open field west of a white house, wih a boarded front door/";
            roomMap["Behind House"].Description = "You are behind the white house. In one corner of teh house there is/";
            roomMap["Dense Woods"].Description = "This is a dimly lit forest, with large trees all around. To the east/";
            roomMap["North of House"].Description = "You are facing the north side of a white house. There is no door here/";
            roomMap["Clearing"].Description = "You are in a clearing, with a forest surrounding you on the west and/";
        }

        private static Location _location = new Location() { Row = 1, Column = 1 };

        private static Room CurrentRoom
        {
            get
            {
				return _rooms[_location.Row, _location.Column];
            }
        }
    }

	internal class Location
	{
		public int Row;
		public int Column;

		public override string ToString()
		{
			return $"{Row},{Column}";
		}
	}
}