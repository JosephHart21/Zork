using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Final.Common;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private App app;

    [SerializeField] private InputUnity inputU;

    [SerializeField] private OutputUnity outputU;

    [SerializeField] private Sprite[] Icons = new Sprite[3];

    [SerializeField] private Image[] Slots = new Image[9];

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

            ++index;
        }
    }

    public void UpdateIcon(int index, Sprite sprite)
    {
        Debug.Log($"Index: {index}\nSprite: {sprite.name}");
        Slots[index].sprite = sprite;
    }

    public void HoverEvent()
    {
        outputU.Write("");
    }

}
