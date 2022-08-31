using System;

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
			Console.Write("> ");
			string inputString = Console.ReadLine().Trim();
			Commands command; command = ToCommand(inputString);
				
			string outputString;
			switch (command)
			{
				case command.Quit: 
					outputString = "Thank you for playing!"; 
					isRunning = false;
					break;
						
				case command.Look:
					outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat says 'Welcome to Zork!'";
					break;
						
				case command.North:
				case command.West:
				case command.South:
				case command.East:
					outputString = $"You moved {command}.";
					break;
						
						
				default: outputString = "Unkown command.";
					break;
			}
				
			Console.WriteLine(outputString);
				
		}
        }
		
	static Commands ToCommand(string commmandString)
	{
		
		return Enum.TryParse(commmandString, true, out Commands result) ? result : Commands.Unkown;
			
	}
    }
}
