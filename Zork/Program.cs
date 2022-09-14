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

		private static void InitializeRoomDescriptions()
		{
			_rooms[0,0].Description = "";
            _rooms[0,1].Description = "";
            _rooms[0,2].Description = "";

            _rooms[1,0].Description = "";
            _rooms[1,1].Description = "";
            _rooms[1,2].Description = "";

            _rooms[2,0].Description = "";
            _rooms[2,1].Description = "";
            _rooms[2,2].Description = "";
        }

        private static readonly Room[,] _rooms = {
            {new Room("Rocky Trail"), new Room ("South of House"), new Room ("Canyon View")},
            {new Room ("Forest"),new Room ("West of House"),new Room ("Behind House")},
            {new Room ("Dense Woods"),new Room ("North of House"),new Room ("Clearing")}
        };

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
