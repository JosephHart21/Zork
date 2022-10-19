using System;
using System.Collections.Generic;
using System.Text;

namespace Zork
{
    public class Player
    {

        public int Score { get; }
        public int Moves { get; }
        public List<Item> Inventory { get; set; }

        public Room CurrentRoom
        {
            get => _currentRoom;
            set => _currentRoom = value;
        }

        public bool Move(Directions direction)
        {
            bool didMove = _currentRoom.Neighbors.TryGetValue(direction, out Room neighbor);
            if (didMove)
            {
                CurrentRoom = neighbor;
            }

            return didMove;

        }

        private World _world;
        private Room _currentRoom;

        public Player(World world, string startingLocation)
        {
            _world = world;

            if (_world.RoomsByName.TryGetValue(startingLocation, out _currentRoom) == false)
            {
                throw new Exception($"Invalid starting location: {startingLocation}");
            }

        }

    }

}
