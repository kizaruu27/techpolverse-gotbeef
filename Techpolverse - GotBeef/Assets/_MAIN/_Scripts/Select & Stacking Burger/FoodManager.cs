using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

public class FoodManager : MonoBehaviour
{
    public static FoodManager instance;

    [Header("Events")]
    public UnityEvent OnBalanceCookingFinished;
    public UnityEvent OnTimingCookingFinished;

    [Header("Ingredients")]
    public int
        bottomBun,
        beef,
        chickenBeef,
        cheese,
        tomato,
        cucumber,
        topBun;

    [Header("UI Components")]
    public GameObject ChooseIngredientUI;
    public GameObject BurgerUI;
    public GameObject WarningUI;
    public TextMeshProUGUI warningText;
    public TextMeshProUGUI perfectCookingResultText;
    public TextMeshProUGUI balanceCookingResultText;
    public GameObject ResultUI;
    public GameObject balanceCookingUI;
    public GameObject timingCookingUI;

    [Header("Recip Staging")]
    public List<string> RecipStaging;

    [Header("Scriptable Value")]
    public ScriptableValue plateValue;
    public ItemDatabase _FoodDatabase;

    [SerializeField] V1_CookingManager _perfectCooking;
    [SerializeField] CookingResult _balanceCooking;
    [SerializeField] CameraManager _cameraManager;

    private void Awake()
    {
        instance = this;
    }

    #region SetIngredientValue

    public void SetBottomBunValue()
    {
        bottomBun += 1;

        RecipStaging.Add("bottom bun");
    }

    public void SetMeatValue()
    {
        beef += 1;
        RecipStaging.Add("beef");
    }

    public void SetCheeseValue()
    {
        cheese += 1;
        RecipStaging.Add("cheese");
    }

    public void SetTomatoValue()
    {
        tomato += 1;
        RecipStaging.Add("tomato");
    }

    public void SetCucumberValue()
    {
        cucumber += 1;
        RecipStaging.Add("cucumber");
    }

    public void SetTopBunnValue()
    {
        topBun = +1;
        RecipStaging.Add("top bun");
    }

    public void SetChickenBeef()
    {
        chickenBeef += 1;
        RecipStaging.Add("chiken Beef");
    }

    #endregion



    #region FoodManager
    
    public void FoodChecker()
    {
        var item = _FoodDatabase.foodList.Find((value) => value.foodName == GameFlow.instance.foodName);

        for (int i = 0; i < RecipStaging.Count; i++)
        {
            if (!item.formulas.Contains(RecipStaging[i]))
            {
                Warning($"Bahan {RecipStaging[i]} tidak sesuai!");
            }
            else
            {
                Debug.Log("Correct");
                ChooseIngredientUI.SetActive(false);
                ActivateBalanceCookingUI();
                _cameraManager.SetCameraToCookingMode();
            }
        }

    }

    public void BurgerCheck()
    {
        if (plateValue.value == GameFlow.instance.orderValue)
        {
            Debug.Log("Correct");
            ResultUI.SetActive(true);
            DisplayPerfectCookingScore();
            DisplayBalanceCookingScore();
        }
        else
        {
            Warning("Urutan burger salah!");
        }
    }

    public void OnClickResetIngredients()
    {
        bottomBun = 0;
        beef = 0;
        tomato = 0;
        cheese = 0;
        cucumber = 0;
        topBun = 0;
        chickenBeef = 0;
    }

    public void ResetBurger()
    {
        plateValue.value = null;
    }

    #endregion

    public void OnClickSetInteractable()
    {
        SelectParts[] parts = FindObjectsOfType<SelectParts>();
        foreach (var foodparts in parts)
        {
            foodparts.isInteractable = true;
        }
    }

    public void OnClickSetBeefInteractable()
    {
        BeefSelection[] beef = FindObjectsOfType<BeefSelection>();
        foreach (var beefSelection in beef)
        {
            beefSelection.isInteractable = true;
        }
    }

    public void OnFinishBalanceCook()
    {
        BeefSelection[] beef = FindObjectsOfType<BeefSelection>();
        foreach (var beefSelection in beef)
        {
            beefSelection.isInteractable = true;
        }
    }

    public void OnFinishTimingCook()
    {
        BeefSelection[] beef = FindObjectsOfType<BeefSelection>();
        foreach (var beefSelection in beef)
        {
            beefSelection.isInteractable = true;
        }
        _cameraManager.SetCameraToNormal();
    }

    void Warning(string messege)
    {
        WarningUI.SetActive(true);
        warningText.text = messege;
        Debug.Log("Wrong");
    }

    void DisplayPerfectCookingScore()
    {
        _perfectCooking.DisplayPerfectTimingCooking(perfectCookingResultText);
    }

    void DisplayBalanceCookingScore()
    {
        balanceCookingResultText.text = _balanceCooking.scoreResult.ToString();
    }
    
    public void ActivateBalanceCookingUI()
    {
        balanceCookingUI.SetActive(true);
    }

    public void ActivateTimingCookingUI()
    {
        timingCookingUI.SetActive(true);
    }


}
