using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float balanceScore;
    
    [Header("Cooking Components")]
    [SerializeField] CookingResult _balanceCookingScore;
    [SerializeField] GameObject[] starsUI;

    private void Update()
    {
        // konversi score untuk balance cooking
        if (_balanceCookingScore.scoreResult > 80)
        {
            balanceScore = 3;
        }
        else if (_balanceCookingScore.scoreResult < 80 && _balanceCookingScore.scoreResult > 40)
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

    public void GeneratePerfectTimingScore()
    {
        // konversi score perfect timing cooking
    }
}
