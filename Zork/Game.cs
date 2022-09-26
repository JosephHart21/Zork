﻿using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork
{
    internal class Game
    {
        public World World { get; set; }
        public Player Player { get; set; }

        public void Run(string[] args)
        {
            string roomsFilename = args.Length > 0 ? args[0] : "Rooms.json";
            InitializeRoomDescriptions($@"Content\{roomsFilename}");

            Room previousRoom = null;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(Player.CurrentRoom);

                if (previousRoom != Player.CurrentRoom && !Player.CurrentRoom.HasBeenVisited)
                {
                    Console.WriteLine(Player.CurrentRoom.Description);
                    previousRoom = Player.CurrentRoom;
                    Player.CurrentRoom.HasBeenVisited = true;
                }

                Console.Write(">");

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
                        outputString = Player.CurrentRoom.Description;
                        break;

                    case Commands.North:
                    case Commands.West:
                    case Commands.South:
                    case Commands.East:
                        if (Player.Move(command))
                        {
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut.";
                        }
                        break;


                    default:
                        outputString = "Unkown command.";
                        break;
                }
                Console.WriteLine(outputString);
            }
        }

        private void InitializeRoomDescriptions(string roomsFilename)
        {
            var RoomMap = new Dictionary<string, Room>();
            foreach (Room room in World.Rooms)
            {
                RoomMap[room.Name] = room;
            }

            Room[] rooms = JsonConvert.DeserializeObject<Room[]>(File.ReadAllText(roomsFilename));
            foreach(Room room in rooms)
            {
                RoomMap[rooms.Name].Description = room.Description;
            }
        }

        static Commands ToCommand(string commmandString)
        {
            return Enum.TryParse(commmandString, true, out Commands result) ? result : Commands.Unknown;
        }

    }

}