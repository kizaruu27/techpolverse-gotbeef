using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject balanceCookingUI;
    [SerializeField] GameObject timingCookingUI;

    public void ActivateBalanceCookingUI()
    {
        balanceCookingUI.SetActive(true);
    }

    public void ActivateTimingCookingUI()
    {
        timingCookingUI.SetActive(true);
    }
}
