using System;

namespace Zork.Common
{
    public class Game
    {
        public World World { get; }

        public Player Player { get; }

        public IOutputService Output { get; private set; }

        public Game(World world, string startingLocation)
        {
            World = world;
            Player = new Player(World, startingLocation);
        }

        public void Run(IOutputService output)
        {
            Output = output;

            Room previousRoom = null;
            bool isRunning = true;
            while (isRunning)
            {
                Output.WriteLine(Player.CurrentRoom);
                if (previousRoom != Player.CurrentRoom)
                {
                    Output.WriteLine(Player.CurrentRoom.Description);
                    Output.WriteLine(Player.CurrentRoom.SpotItems());
                    previousRoom = Player.CurrentRoom;
                }

                Output.Write("\n> ");

                string inputString = Console.ReadLine().Trim();
                // might look like:  "LOOK", "TAKE MAT", "QUIT"
                char  separator = ' ';
                string[] commandTokens = inputString.Split(separator);
                
                string verb = null;
                string subject = null;
                if (commandTokens.Length == 0)
                {
                    continue;
                }
                else if (commandTokens.Length == 1)
                {
                    verb = commandTokens[0];

                }
                else
                {
                    verb = commandTokens[0];
                    subject = commandTokens[1];
                }

                Commands command = ToCommand(verb);
                string outputString;
                switch (command)
                {
                    case Commands.Quit:
                        isRunning = false;
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.Look:
                        outputString = Player.CurrentRoom.Description;
                        outputString += "\n";
                        outputString += Player.CurrentRoom.SpotItems();
                        break;

                    case Commands.North:
                    case Commands.South:
                    case Commands.East:
                    case Commands.West:
                        Directions direction = (Directions)command;
                        if (Player.Move(direction))
                        {
                            outputString = $"You moved {direction}";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }
                        break;

                    case Commands.Take:
                        if (string.IsNullOrEmpty(subject))
                        {
                            outputString = "You must clarify what you wish to take";
                            break;
                        }
                        if (World.TakeItemFromRoom(subject, Player.CurrentRoom, Player)) 
                            outputString = $"You take {subject}";
                        else outputString = "There is no such thing";

                        break;

                    case Commands.Drop:
                        if (string.IsNullOrEmpty(subject))
                        {
                            outputString = "You must clarify what you wish to drop";
                            break;
                        }
                        if (Player.DropItem(subject)) 
                            outputString = $"You dropped {subject}";
                        else outputString = "You have no such thing";
                        break;

                    case Commands.Inventory:
                        outputString = Player.CheckInventory();
                        break;

                    default:
                        outputString = "Unknown command";
                        break;
                }

                Output.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse(commandString, true, out Commands result) ? result : Commands.Unknown;
    }
}
