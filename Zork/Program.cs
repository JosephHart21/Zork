using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Zork
{
	class Program
	{

        static void Main()
        {
			Console.WriteLine("Welcome to Zork!");

			Game game = new Game();
			game.Run();

        }

    }

}