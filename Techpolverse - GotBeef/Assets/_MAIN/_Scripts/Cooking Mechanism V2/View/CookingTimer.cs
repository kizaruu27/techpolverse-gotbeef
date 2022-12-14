using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookingTimer : MonoBehaviour
{
    public bool isPointerInArea;
    public bool isDead;
    public bool isFinish;
    public float time;
    public float timeInArea;
    [SerializeField] float _deadTime;
    [SerializeField] float _finishTime;

    public TextMeshProUGUI timeUI;

    public Slider _ProgressBar;

    private void Update()
    {
        GetTime();
        ShowTime();
        InGameFinish();
    }
    
    void GetTime()
    {
        timeInArea = isPointerInArea ?
          timeInArea + (Time.deltaTime * 1f) :
          timeInArea > 0 ?
            timeInArea - (Time.deltaTime * 1f) : 0;

        time += Time.deltaTime * 1f;

        _ProgressBar.value = timeInArea;
    }

    void ShowTime()
    {
        timeUI.text = timeInArea.ToString("0.00") + " Detik";
    }

    void InGameFinish()
    {
        isDead = time >= _deadTime;
        isFinish = timeInArea >= _finishTime;
    }
}