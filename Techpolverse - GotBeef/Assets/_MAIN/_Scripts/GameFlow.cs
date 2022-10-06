using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow instance;
    
    [Header("Food Value")]
    public string orderValue = "12101";
    public string plateValue;

    private void Awake()
    {
        instance = this;
    }
}
