using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
  [SerializeField] private bool isPlay;
  public Slider slider;
  public float sliderSpeed;
  private float valueResult { get; set; }

  [Header("Target Area")]
  [SerializeField] private bool onTarget = false;
  public GameObject targetArea;

  public FlowManager _FlowManager;

  private void Start()
  {
    targetArea.transform.localPosition = new Vector3(Random.Range(-50, 50), 0, 0);
  }

  private void Update()
  {
    if (isPlay)
      slider.value = Mathf.PingPong(sliderSpeed * Time.time, 10f);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Handle") onTarget = true;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.tag == "Handle") onTarget = false;
  }

  public void StopHandle()
  {
    isPlay = false;

    StartCoroutine(CheckValue());
  }

  IEnumerator CheckValue()
  {
    yield return new WaitUntil(() => isPlay == false);

    if (onTarget == true)
    {
      Debug.Log("on target");
      _FlowManager.FinishCooking(true);
    }
    else
    {
      Debug.Log("fail");
      _FlowManager.FinishCooking(false);
    }
  }
}
