using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Zork
{
	class Program
	{

        static void Main()
        {
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
						outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat says 'Welcome to Zork!'";
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
					_location.Column++;
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


        private static readonly string[,] _rooms = {
            { "Rocky Trail", "South of House", "Canyon View" },
            { "Forest","West of House","Behind House"},
            { "Dense Woods","North of House","Clearing"}
        };

        private static Location _location = new Location() { Row = 1, Column = 1 };

        private static string CurrentRoom
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
