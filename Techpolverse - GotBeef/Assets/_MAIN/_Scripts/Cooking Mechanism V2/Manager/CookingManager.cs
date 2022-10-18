using UnityEngine;

public class CookingManager : MonoBehaviour
{
  [SerializeField] CookingController _cooking;
  [SerializeField] AreaController _area;

  [SerializeField] CookingTimer _timerUI;
  [SerializeField] CookingResult _scoreResult;
  [SerializeField] GameObject _cookingResultUI;

  private bool _isGameOver;
  private float _totalTimeInArea;


  private void Update()
  {
    _timerUI.isPointerInArea = _cooking.insideCookingArea;
    _isGameOver = _timerUI.isDead || _timerUI.isFinish;


    Debug.Log(_totalTimeInArea.ToString("0.00"));
    if (_isGameOver)
    {
      FoodManager.instance.OnBalanceCookingFinished.Invoke();
      
      _totalTimeInArea = _timerUI.timeInArea;
      _cookingResultUI.SetActive(true);
      _scoreResult.gameObject.SetActive(true);

      var score = float.Parse(_totalTimeInArea.ToString("0.00"));
      _scoreResult.scoreResult = _timerUI.isDead ? ((score / 2) * 100) : (score * 100);
    }
  }
}