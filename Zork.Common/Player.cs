using System;
using System.Collections.Generic;

namespace Zork.Common
{
    public class Player
    {
        public Room CurrentRoom
        {
            get => _currentRoom;
            set => _currentRoom = value;
        }

        public List<Item> Inventory { get; }

        public Player(World world, string startingLocation)
        {
            _world = world;

            if (_world.RoomsByName.TryGetValue(startingLocation, out _currentRoom) == false)
            {
                throw new Exception($"Invalid starting location: {startingLocation}");
            }

            Inventory = new List<Item>();
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

        public void DropItem(string itemName)
        {
            Item itemToDrop = null;
            foreach (Item item in Inventory)
            {
                if (itemName == item.Name)
                {
                    itemToDrop = item;
                    break;
                }
            }

            if (itemToDrop != null)
            {
                CurrentRoom.Inventory.Add(itemToDrop);
                Inventory.Remove(itemToDrop);
            }
        }

        public int Moves
        {
            get
            {
                return _moves;
            }
            set
            {
                _moves = value;
            }
        }


        private World _world;
        private Room _currentRoom;
        private int _moves;
    }
}
