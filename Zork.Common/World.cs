using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zork.Common
{
    public class World
    {
        public Room[] Rooms { get; }

        [JsonIgnore]
        public Dictionary<string, Room> RoomsByName { get; }

        public Item[] Items { get; }
        
        [JsonIgnore]
        public Dictionary<string, Item> ItemsByName { get; }

        public World(Room[] rooms, Item[] items)
        {
            Rooms = rooms;
            RoomsByName = new Dictionary<string, Room>(StringComparer.OrdinalIgnoreCase);
            foreach (Room room in rooms)
            {
                RoomsByName.Add(room.Name, room);
            }

            Items = items;
            ItemsByName = new Dictionary<string, Item>(StringComparer.OrdinalIgnoreCase);
            foreach (Item item in Items)
            {
                ItemsByName.Add(item.Name, item);
            }
        }

        public bool TakeItemFromRoom(string itemName, Room currentRoom, Player player)
        {
            Item itemToTake = null;
            foreach (Item item in currentRoom.Inventory)
            {
                if (itemName == item.Name)
                {
                    itemToTake = item;
                    break;
                }
            }
            if (itemToTake != null)
            {
                currentRoom.Inventory.Remove(itemToTake);
                player.Inventory.Add(itemToTake);
                return true;
            }
            else return false;
 
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext streamingContext)
        {
            foreach (Room room in Rooms)
            {
                room.UpdateNeighbors(this);
                room.UpdateInventory(this);
            }
        }
    }
}