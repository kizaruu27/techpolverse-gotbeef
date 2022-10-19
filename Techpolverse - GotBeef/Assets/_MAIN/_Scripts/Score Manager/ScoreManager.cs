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
        if (_balanceCookingScore.scoreResult > 80000)
        {
            balanceScore = 3;
            scoreText.text = balanceScore.ToString();
        }
        else if (_balanceCookingScore.scoreResult < 80000 && _balanceCookingScore.scoreResult > 40000)
        {
            balanceScore = 2;
            scoreText.text = balanceScore.ToString();
        }
        else
        {
            balanceScore = 1;
            scoreText.text = balanceScore.ToString();
        }
        
    }

    public void GeneratePerfectTimingScore()
    {
        // konversi score perfect timing cooking
    }
}
