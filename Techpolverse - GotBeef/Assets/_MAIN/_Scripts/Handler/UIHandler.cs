using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject balanceCookingUI;

    public void ActivateBalanceCookingUI()
    {
        balanceCookingUI.SetActive(true);
    }
}
