using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Final.Common;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private App app;

    [SerializeField] private InputUnity inputU;

    [SerializeField] private OutputUnity outputU;

    [SerializeField] private Sprite[] Icons = new Sprite[3];

    [SerializeField] private Image[] Slots = new Image[9];

    [SerializeField] private TextMeshProUGUI[] Counters = new TextMeshProUGUI[9];

    [SerializeField] private Dictionary<Item, Sprite> Items = new Dictionary<Item, Sprite>();


    private void Awake()
    {
        TextAsset appJson = Resources.Load<TextAsset>("appContent");
        app = JsonConvert.DeserializeObject<App>(appJson.text);
        app.Organized += SetUp;
        app.Run(inputU, outputU);
        outputU.Write("Hover over an item.");
    }

    private void SetUp(object sender, string message)
    {
        var index = 0;
        foreach (var item in app.inventory.ItemsByCount)
        {

            switch (item.Key.Name.ToLower())
            {
                case "sword":
                    Items.Add(item.Key, Icons[0]);
                    UpdateIcon(index, Icons[0]);
                    break;

                case "phone":
                    Items.Add(item.Key, Icons[1]);
                    UpdateIcon(index, Icons[1]);
                    break;

                case "bike":
                    Items.Add(item.Key, Icons[2]);
                    UpdateIcon(index, Icons[2]);
                    break;

                default:
                    Items.Add(item.Key, Icons[3]);
                    UpdateIcon(index, Icons[3]);
                    break;
            }

            UpdateCounter(index, item.Value);
            ++index;
        }
    }

    public void UpdateIcon(int index, Sprite sprite)
    {
        Slots[index].sprite = sprite;
    }

    public void UpdateCounter(int index, int sum)
    {
        Counters[index].GetComponent<TextMeshProUGUI>().enabled = true;
        Counters[index].text = sum.ToString();
    }

    public void HoverEvent(Image slot)
    {
        try
        {
            Item key = NonGeneric.KeyByValue(Items, slot.sprite);
            outputU.Write(key.Description);
        }
        catch
        {
            ;
        }

    }

}

public static class NonGeneric
{
    public static T KeyByValue<T, W>(this Dictionary<T, W> dict, W val)
    {
        T key = default;
        foreach (KeyValuePair<T, W> pair in dict)
        {
            if (EqualityComparer<W>.Default.Equals(pair.Value, val))
            {
                key = pair.Key;
                break;
            }
        }

        return key;
    }
}