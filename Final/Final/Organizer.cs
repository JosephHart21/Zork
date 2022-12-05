namespace Final.Common;

static public class Organizer
{

    static public Dictionary<Item, int> OrganizeStorage(List<Item> storage)
    {
        var data = new Dictionary<Item, int>();
        var set = new Dictionary<string, Item>();
        var names = new List<string>();

        foreach (var item in storage)
        {

            if (names.Contains(item.Name))
            {
                data[set[item.Name]]++;
            }

            else
            {
                data.Add(item, 1);
                set.Add(item.Name, item);
                names.Add(item.Name);
            }

        }

        return data;

    }

}