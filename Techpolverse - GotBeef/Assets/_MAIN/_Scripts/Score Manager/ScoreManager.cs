using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float balanceScore;
    
    [Header("Cooking Components")]
    [SerializeField] CookingResult _balanceCookingScore;
    [SerializeField] V1_CookingManager _perfectTimingCookingScore;

    public void GenerateBalanceCookingScore(TextMeshProUGUI scoreText)
    {
        // konversi score untuk balance cooking
        if (_balanceCookingScore.scoreResult < 1000)
        {
            balanceScore = 10;
            scoreText.text = balanceScore.ToString();
        }
        else
        {
            balanceScore = 50;
            scoreText.text = balanceScore.ToString();
        }
        
    }

    public void GeneratePerfectTimingScore()
    {
        // konversi score perfect timing cooking
    }
}
