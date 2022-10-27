using UnityEngine;
using TMPro;

public class CookingResult : MonoBehaviour
{
  public TextMeshProUGUI _scoreUI;
  public float scoreResult;

  public GameObject[] stars;
  private float balanceScore;
  
  private void Start()
  {
    // scoreResult = scoreResult / 100;
    
      if (scoreResult > 80)
      {
        balanceScore = 3;
      }
      else if (scoreResult < 80 && scoreResult > 40)
      {
        balanceScore = 2;
      }
      else
      {
        balanceScore = 1;
      }
      
      for (int i = 0; i < balanceScore; i++)
      {
        stars[i].SetActive(true);
      }
    
    _scoreUI.text = "Score: " + (scoreResult).ToString();
  }
}