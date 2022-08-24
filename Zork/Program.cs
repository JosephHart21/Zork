using System;

namespace Zork
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Welcome to Zork!");

            string inputString = Console.ReadLine().Trim().ToUpper();

            switch (inputString){
                case "QUIT": Console.WriteLine("Thank you for playing."); 
                    break;
                case "LOOK": Console.WriteLine("This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcom to Zork!' lies by the door."); 
                    break;
                case "": Console.WriteLine("Must type command"); 
                    break;
                default: Console.WriteLine($"'{inputString}' is not a recognized command."); 
                    break;
            }
        }
    }
}
