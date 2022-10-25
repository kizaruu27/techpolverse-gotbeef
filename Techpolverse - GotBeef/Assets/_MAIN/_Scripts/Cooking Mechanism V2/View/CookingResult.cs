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
      if (scoreResult > 800)
      {
        balanceScore = 3;
      }
      else if (scoreResult < 800 && scoreResult > 400)
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
    
    // _scoreUI.text = "Score: " + (scoreResult * 100).ToString();
  }
}