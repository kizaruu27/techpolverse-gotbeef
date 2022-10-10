using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;
    
    [Header("Food Value")]
    public string orderValue;
    public string plateValue;
    public string foodName;

    private void Awake()
    {
        instance = this;
    }
}
