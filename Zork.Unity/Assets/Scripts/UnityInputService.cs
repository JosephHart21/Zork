using UnityEngine;
using TMPro;
using Zork.Common;
using System;

public class UnityInputService : MonoBehaviour, IInputService
{
    [SerializeField] TMP_InputField InputField;

    public event EventHandler<string> InputReceived;

    public void ProcessInput()
    {
        if (string.IsNullOrWhiteSpace(InputField.text) == false)
        {
            InputReceived?.Invoke(this, InputField.text.Trim());
        }
        InputField.text = String.Empty;
    }

    public void SetFocus()
    {
        InputField.Select();
        InputField.ActivateInputField();
    }
}