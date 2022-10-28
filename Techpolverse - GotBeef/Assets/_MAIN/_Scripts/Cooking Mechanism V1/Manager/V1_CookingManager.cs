using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class V1_CookingManager : MonoBehaviour
{
    public bool isPlay;

    [Header("Slider Components")]
    public Slider slider;
    public float setSliderSpeed;
    [SerializeField] float sliderSpeed;
    public float speedDifficulty;
    //? settingan difficulty
    [SerializeField] float nextActionTime = 0.0f;
    float period = 0.1f;

    [Header("Target Area")]
    public GameObject targetArea;
    public AreaStatus StatusResult;

    [Header("PopUp Result")]
    public DisplayCookingProcess _DisplayCookingProcess;

    [Header("Timer Components")]
    public float setDuration;
    float duration;
    string stringTimer = "00:00";

    [Header("Patty Material")] 
    public Material rawPattyMaterial;
    public Material overcookPattyMaterial;

    public AreaStatus GenerateStatusResult
    {
        get
        {
            return StatusResult;
        }
        set
        {
            StatusResult = value;
        }
    }

    protected string GenerateScore(AreaStatus _status)
    {
        return _status switch
        {
            AreaStatus.OverCook => "Gosong",
            AreaStatus.Raw => "Belum Matang",
            AreaStatus.Great => "Great",
            AreaStatus.Perfect => "Perfect",
            _ => "null"
        };
    }

    private void Start()
    {
        targetArea.transform.localPosition = new Vector3(targetArea.transform.localPosition.x + Random.Range(25, 120),
        targetArea.transform.localPosition.y,
        targetArea.transform.localPosition.z);
    }

    private void OnEnable()
    {
        isPlay = true;

        ResetChallengeSetting();
    }

    public void ResetChallengeSetting()
    {
        //? Reset setting
        duration = setDuration;
        sliderSpeed = setSliderSpeed;
        // nextActionTime = 0.0f;
    }

    private void Update()
    {
        if (isPlay)
            slider.value = Mathf.PingPong(Time.time * sliderSpeed, 10f);

        // Debug.Log(GenerateStatusResult);

        Timer();

        // SetDinamicdifficulty();
    }

    public void OnClickFinishCook()
    {
        StartCoroutine(DisplayPopUpResult());
        FoodManager.instance.OnTimingCookingFinished.Invoke();
        ResetChallengeSetting();
    }

    public IEnumerator DisplayPopUpResult()
    {
        isPlay = false;

        yield return new WaitForEndOfFrame();

        _DisplayCookingProcess.SetActivePopUpResult("RESULT", GenerateScore(GenerateStatusResult));
    }

    // ! Timer Method
    private void Timer()
    {
        if (isPlay && duration > 0)
        {
            stringTimer = TimeCalculation();

            _DisplayCookingProcess.SetTimerTextValue(stringTimer);

            if (duration <= 0)
            {
                duration = 0;
                _DisplayCookingProcess.SetTimerTextValue("00:00");

                isPlay = false;
                _DisplayCookingProcess.SetActivePopUpResult("DEFEAT", "You're Loser");
                ResetChallengeSetting();
            }
        }
    }

    private string TimeCalculation()
    {
        duration -= Time.deltaTime;

        float minutes = Mathf.FloorToInt((duration / 60));
        float seconds = Mathf.FloorToInt((duration % 60));

        return string.Format("{1:00}", minutes, seconds);
    }

    public void SetDinamicdifficulty()
    {
        if (!isPlay) return;

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            sliderSpeed += speedDifficulty * Time.deltaTime;
        }
    }

    public void DisplayPerfectTimingCooking(TextMeshProUGUI messege)
    {
        messege.text = GenerateScore(GenerateStatusResult);
    }

    public void SetPattyResult()
    {
        if (StatusResult == AreaStatus.OverCook)
        {
            Debug.Log("Gosong");
            changePattyMaterial(overcookPattyMaterial);
        }
        else if (StatusResult == AreaStatus.Raw)
        {
            Debug.Log("Mentah");
            changePattyMaterial(rawPattyMaterial);
        }
        else
        {
            Debug.Log("Matang");
        }
    }

    void changePattyMaterial(Material mat)
    {
        Renderer beef = GameObject.FindGameObjectWithTag("Beef").GetComponent<Renderer>();
        beef.material = mat;
    }
}
