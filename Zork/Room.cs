using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zork
{
    public class Room
    {
        public string Name { get;}
        public string Description { get; set; }
        public bool HasBeenVisited { get; set; }

        [JsonIgnore]
        public List<Item> Inventory { get; set; }
        [JsonProperty]
        public string[] InventoryNames { get; set; }
        public Dictionary<Directions,Room> Neighbors { get; set; }

        [JsonProperty]
        private Dictionary<Directions,string> neighborNames { get; set; }


        public Room(string name)
        {
            Name = name;
        }

        public Room(string name, string description, Dictionary<Directions,string> neighborNames, List<Item> inventory)
        {
            Name = name;
            Description = description;
            this.neighborNames = neighborNames ?? new Dictionary<Directions, string>();
            Inventory = inventory ?? new List<Item>();
        }

        public void UpdateNeighbors(World world)
        {
            Neighbors = new Dictionary<Directions, Room>();
            foreach(KeyValuePair<Directions,string> neighborName in neighborNames)
            {
                Neighbors.Add(neighborName.Key, world.RoomsByName[neighborName.Value]);
            }
        }

        public void UpdateInventory(World world)
        {
            Inventory = new List<Item>();
            foreach(var invName in InventoryNames)
            {
                Inventory.Add(world.ItemsByName[invName]);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}