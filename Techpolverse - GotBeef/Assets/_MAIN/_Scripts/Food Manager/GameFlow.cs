using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;

    public ScriptableValue plate;
    
    [Header("Food Value")]
    public string orderValue;
    public string plateValue;
    public string foodName;
    public int foodIndex;

    private void Awake()
    {
        instance = this;
    }
}
