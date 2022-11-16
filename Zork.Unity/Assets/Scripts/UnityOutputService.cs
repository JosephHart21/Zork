using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zork.Common;

public class UnityOutputService : MonoBehaviour, IOutputService
{
    [SerializeField] private TextMeshProUGUI TextLinePrefab;

    [SerializeField] private Image NewLinePrefab;

    [SerializeField] private Transform ContentTransform;

    public void Write(object obj) => ParseAndWriteLine(obj.ToString());

    public void Write(string message) => ParseAndWriteLine(message);

    public void WriteLine(object obj) => ParseAndWriteLine(obj.ToString());

    public void WriteLine(string message) => ParseAndWriteLine(message);

    public void ParseAndWriteLine(string message)
    {
        var textLine = Instantiate(TextLinePrefab, ContentTransform);
        textLine.text = message;
        _entries.Add(textLine.gameObject);
    }

    private List<GameObject> _entries = new List<GameObject>(0);

}
