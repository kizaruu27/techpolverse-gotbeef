using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCookingProcess : MonoBehaviour
{
    [Header("Cooking Components")]
    public GameObject DisplayCooking;

    [Header("PopUp Result")]
    public GameObject popUpDialog;
    public TextMeshProUGUI title;
    public TextMeshProUGUI dialogMessage;

    [Header("Countdown Timer")]
    public TextMeshProUGUI TimeTxt;

    public void SetTimerTextValue(string _time)
    {
        TimeTxt.text = _time;
    }

    public void OnStartCookingProcess()
    {
        DisplayCooking.SetActive(true);
    }

    public void CloseDisplay()
    {
        DisplayCooking.SetActive(false);
        popUpDialog.SetActive(false);
    }

    public void SetActivePopUpResult(string _title, string _dialogMessage)
    {
        popUpDialog.SetActive(true);

        title.text = _title;
        dialogMessage.text = _dialogMessage;
    }
}
