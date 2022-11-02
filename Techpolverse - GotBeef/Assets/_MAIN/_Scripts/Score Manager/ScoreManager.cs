using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float balanceScore;
    
    [Header("Cooking Components")]
    [SerializeField] ScriptableValue _balanceCookingScore;
    [SerializeField] GameObject[] starsUI;

    private void Update()
    {
        // konversi score untuk balance cooking
        if (_balanceCookingScore.floatValue > 80)
        {
            balanceScore = 3;
        }
        else if (_balanceCookingScore.floatValue < 80 && _balanceCookingScore.floatValue > 40)
        {
            balanceScore = 2;
        }
        else
        {
            balanceScore = 1;
        }
    }

    public void GenerateBalanceCookingScore(TextMeshProUGUI scoreText)
    {
        for (int i = 0; i < balanceScore; i++)
        {
            starsUI[i].SetActive(true);
        }
        
    }

    public void ResetScore()
    {
        _balanceCookingScore.floatValue = 0;
        BeefMeshBehaviour.instance.isSpawning = false;
    }
}
