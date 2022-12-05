using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Final.Common;
using TMPro;

public class GameManager : MonoBehaviour
{
    private App app;

    [SerializeField] private InputUnity inputU;
    [SerializeField] private OutputUnity outputU;


    private void Awake()
    {
        TextAsset appJson = Resources.Load<TextAsset>("appContent");
        app = JsonConvert.DeserializeObject<App>(appJson.text);
        app.Run(inputU, outputU);
    }

    private void Start()
    {
        foreach(KeyValuePair<Item, int> pair in app.inventory.ItemsByCount)
        {
            outputU.Write(pair.Key.Name);
        }
    }



}
