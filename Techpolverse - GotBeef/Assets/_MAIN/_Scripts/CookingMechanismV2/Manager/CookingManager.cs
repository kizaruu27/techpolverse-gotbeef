using UnityEngine;

public class CookingManager : MonoBehaviour
{
  [SerializeField] CookingController _cooking;
  [SerializeField] AreaController _area;

  [SerializeField] CookingTimer _timerUI;
  [SerializeField] CookingResult _cookingResultUI;

  private bool _isGameOver;
  private float _totalTimeInArea;


  private void Update()
  {
    _timerUI.isPointerInArea = _cooking.insideCookingArea;
    _isGameOver = _timerUI.isDead || _timerUI.isFinish;


    Debug.Log(_totalTimeInArea.ToString("0.00"));
    if (_isGameOver)
    {
      _totalTimeInArea = _timerUI.timeInArea;
      _cookingResultUI.gameObject.SetActive(true);

      var score = float.Parse(_totalTimeInArea.ToString("0.00"));
      _cookingResultUI.scoreResult = _timerUI.isDead ? ((score / 2) * 100) : (score * 100);
    }
  }
}