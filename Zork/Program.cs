using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Zork
{
	class Program
	{
        static void Main(string[] args)
        {
			Console.WriteLine("Welcome to Zork!");

			Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(@"..\..\..\Content\Game.json"));
			game.Run(args);

        }

    }

}