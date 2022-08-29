using System;

namespace Zork
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Zork!");
			
			string inputString = Console.ReadLine().Trim();
			
			Commands command; command = ToCommand(inputString);

            switch (commad)
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
		
			if(Enum.TryParse<Commands>(commmandString, true, out Commands command))
			{
				return command;
			}
			else
			{
				return Commands.Unknown;
			}
			
		}
		
    }
	
}
