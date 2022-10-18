using UnityEngine;
using TMPro;

public class CookingResult : MonoBehaviour
{
  public TextMeshProUGUI _scoreUI;

  // public float scoreResult;
  public float scoreResult;


  private void Start()
  {
    _scoreUI.text = "Score: " + (scoreResult * 100).ToString();
  }
}