using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Value")]
public class ScriptableValue : ScriptableObject
{
    private void OnEnable()
    {
        value = null;
        floatValue = 0;
    }

    public string value;
    public float floatValue;
}
