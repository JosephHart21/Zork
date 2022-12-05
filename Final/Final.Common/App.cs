using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Final.Common
{
    public class App
    {
        [JsonIgnore]
        public bool running = true;

        [JsonIgnore]
        public InputAPI input { get; private set; }
        [JsonIgnore]
        public OutputAPI output { get; private set; }

        public Inventory inventory { get; set; }

        public event EventHandler<string> Organized;


        public void Run(InputAPI input, OutputAPI output)
        {
            this.input = input;
            this.output = output;

            input.InputTaken += OnInput;

            inventory.ItemsByCount = Organizer.OrganizeStorage(inventory.Storage);

            PrintInventory();
            Organized?.Invoke(this, "");

        }

        public void PrintInventory()
        {
            output.WriteLine("");
            foreach (var key in inventory.ItemsByCount)
            {
                output.WriteLine($"{key.Value} of {key.Key.Name}");
            }
            if (inventory.ItemsByCount.Count <= 0)
            {
                output.WriteLine("No Items");
            }
        }

        public void OnInput(object sender, string input)
        {
            inventory.ByCountToName();
            var name = input.Trim().ToLower();

            if (inventory.ItemsByName.ContainsKey(input))
            {
                output.WriteLine($"{inventory.ItemsByName[input].Description}");
            }
            else
            {
                output.WriteLine("Did not find that item.");
            }

        }

    }

}