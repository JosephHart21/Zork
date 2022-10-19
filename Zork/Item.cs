namespace Zork
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; set; }

        public Item(string name, string description = null)
        {
            Name = name;
            Description = description;

        }

    }

}
