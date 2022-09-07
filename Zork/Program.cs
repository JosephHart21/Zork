using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Zork
{
    class Program
    {
		private static readonly string[] _rooms = {"Rocky Trail", "South of House", "Canyon View"};

        private static int _currentRoom = 1;

        static void Main()
        {
			Console.WriteLine("Welcome to Zork!");
			
			bool isRunning = true;
			while (isRunning)
			{
				Console.Write($"You are in {_rooms[_currentRoom]}\n> ");
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
				case Commands.North:
					break;

				case Commands.South:
					break;

				case Commands.West when _currentRoom > 0:
                    _currentRoom--;
                    didMove = true;
                    break;

				case Commands.East when _currentRoom < _rooms.Length -1:
                    _currentRoom++;
                    didMove = true;
                    break;
			}
			return didMove;
		}
    }
}
