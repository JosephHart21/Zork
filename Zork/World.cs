using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    internal class World
    {
        public Room[,] Rooms
        {
            get;
        }

        public World(Room[,] rooms)
        {
            Rooms = rooms;
        }

    }

}
