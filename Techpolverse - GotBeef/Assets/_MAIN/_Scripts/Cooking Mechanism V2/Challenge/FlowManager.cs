using UnityEngine;

public class FlowManager : MonoBehaviour
{
  [Header("Pop-Up Dialog")]
  public PopUpDialog _PopUpDialog;

  [Header("Scoring")]
  public int score;

  [Header("Slider Components")]
  public SliderControl _SliderControl;

  private void Start()
  {
    _PopUpDialog.SetActivePopUpDialog("", "klick cook button when handle on the target area");
  }

  public void OnClickStartGame()
  {
    // _PopUpDialog.gameObject.SetActive(false);
  }

  public void FinishCooking(bool _result)
  {
    if (_result == true) _PopUpDialog.SetActivePopUpDialog("Result", "Your score: 100");
    else _PopUpDialog.SetActivePopUpDialog("Result", "Your score: 0");
  }
}
