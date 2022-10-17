using Newtonsoft.Json;
using System;
using System.IO;

namespace Zork
{
	class Program
	{
        static void Main(string[] args)
        {
			Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(@"Content\Game.json"));

			Console.WriteLine("Welcome to Zork!");

			game.Run(args);

			Console.WriteLine("Finished!");

        }

    }

}