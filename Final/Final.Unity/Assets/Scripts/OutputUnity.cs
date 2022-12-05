using UnityEngine;
using Final.Common;
using TMPro;

public class OutputUnity : MonoBehaviour, OutputAPI
{

    [SerializeField] TextMeshProUGUI DescriptionText;

    public void Write(object obj) => ParseString(obj.ToString());

    public void Write(string message) => ParseString(message.ToString());

    public void WriteLine(object obj) => ParseString(obj.ToString());


    public void WriteLine(string message) => ParseString(message.ToString());


    public void ParseString(string message)
    {
        DescriptionText.text += message;
    }

}
