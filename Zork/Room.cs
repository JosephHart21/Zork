using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zork
{
    public class Room
    {
        public string Name { get;}
        public string Description { get; set; }

        public bool HasBeenVisited { get; set; }
        public Dictionary<Directions,Room> Neighbors { get; set; }

        [JsonProperty]
        private Dictionary<Directions,string> neighborNames { get; set; }

        public Room(string name)
        {
            Name = name;
        }

        public Room(string name, string description, Dictionary<Directions,string> neighborNames)
        {
            Name = name;
            Description = description;
            this.neighborNames = neighborNames ?? new Dictionary<Directions, string>();
        }

        public void UpdateNeighbors(World world)
        {
            Neighbors = new Dictionary<Directions, Room>();
            foreach(KeyValuePair<Directions,string> neighborName in neighborNames)
            {
                Neighbors.Add(neighborName.Key, world.RoomsByName[neighborName.Value]);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}