using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CookingController : MonoBehaviour
{
  [SerializeField] private Slider _slider;
  [SerializeField] private float _reduceValue = .05f;
  [SerializeField] private float _increaseValue = 5f;

  public bool insideCookingArea;
  private bool isTapping;

  private void Update()
  {
    if (!isTapping) OnLooseTapping();
  }

  void OnLooseTapping()
  {
    _slider.value = _slider.value <= 0 ? 0 : _slider.value - _reduceValue;
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    insideCookingArea = other.tag == "Handle";
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    insideCookingArea = false;
  }

  public void OnTapping()
  {
    _slider.value += _increaseValue;
    StartCoroutine(StartLooseValue());
  }

  IEnumerator StartLooseValue()
  {
    isTapping = true;
    yield return new WaitForSeconds(.2f);
    isTapping = false;
  }
}