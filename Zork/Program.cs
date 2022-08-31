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
		}

            	switch (command)
			{
                case Commands.Quit: Console.WriteLine("Thank you for playing."); 
                    break;
					
                case Commands.Look: Console.WriteLine("This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcom to Zork!' lies by the door."); 
                    break;
					
                case Commands.Unknown: Console.WriteLine("Must type command"); 
                    break;
					
                default: Console.WriteLine($"'{inputString}' is not a recognized command."); 
                    break;
            	}	
        }
		
	static Commands ToCommand(string commmandString)
	{
		
		return Enum.TryParse(commmandString, true, out Commands result) ? result : Commands.Unkown;
			
	}	
    }
}
