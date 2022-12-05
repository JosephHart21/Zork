using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Final.Common;
using System;

public class InputUnity : MonoBehaviour, InputAPI
{
    public event EventHandler<string> InputTaken;
}
