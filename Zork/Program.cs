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
