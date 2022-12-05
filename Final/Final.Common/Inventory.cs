using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Final.Common
{
    public class Inventory
    {

        public List<Item> Storage = new List<Item>();

        [JsonIgnore]
        public Dictionary<Item, int> ItemsByCount = new Dictionary<Item, int>();

        [JsonIgnore]
        public Dictionary<string, Item> ItemsByName = new Dictionary<string, Item>(StringComparer.InvariantCultureIgnoreCase);

        public void ByCountToName()
        {
            ItemsByName.Clear();

            foreach(var item in ItemsByCount)
            {
                ItemsByName.Add(item.Key.Name, item.Key);
            }

        }
    }
}