using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    internal class Player
    {
        public Room CurrentRoom { get; }
        public int Score { get; }
        public int Moves { get; }

        public Player(World world)
        {
            _world = world;

        }

        private World _world;

    }
}
