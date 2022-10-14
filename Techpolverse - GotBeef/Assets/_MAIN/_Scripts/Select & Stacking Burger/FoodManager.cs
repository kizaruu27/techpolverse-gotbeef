using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    [Header("Scriptable Value")]
    public ScriptableValue plateValue;
    public Food BeefBurger;
    public Food ChickenBurger;

    private void Awake()
    {
        instance = this;
    }

    #region SetIngredientValue
    
    public void SetBottomBunValue()
    {
        bottomBun += 1;;
    }

    public void SetMeatValue()
    {
        beef += 1;
    }

    public void SetCheeseValue()
    {
        cheese += 1;
    }

    public void SetTomatoValue()
    {
        tomato += 1;
    }

    public void SetCucumberValue()
    {
        cucumber += 1;
    }

    public void SetTopBunnValue()
    {
        topBun =+ 1;
    }

    public void SetChickenBeef()
    {
        chickenBeef += 1;
    }
    
    #endregion



    #region FoodManager

    public void FoodChecker()
    {
        if (GameFlow.instance.foodName == BeefBurger.foodName)
        {
            if (topBun == 1 && cucumber == 1 && tomato == 1 && beef == 1 && bottomBun == 1 && cheese == 1 && chickenBeef == 0)
            {
                Debug.Log("Correct");
                ChooseIngredientUI.SetActive(false);
                BurgerUI.SetActive(true);
            }
            else
            {
                Warning("Bahan tidak sesuai!");
            }
        }

        if (GameFlow.instance.foodName == ChickenBurger.foodName)
        {
            if (topBun == 1 && cucumber == 1 && tomato == 1 && beef == 0 && bottomBun == 1 && cheese == 1 && chickenBeef == 1)
            {
                Debug.Log("Correct");
                ChooseIngredientUI.SetActive(false);
                BurgerUI.SetActive(true);
            }
                
            else
            {
                Warning("Bahan tidak sesuai!");
            }
                
        }
    }

    public void BurgerCheck()
    {
        if (plateValue.value == GameFlow.instance.orderValue)
            Debug.Log("Correct");
        else
            Warning("Urutan burger salah!");
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
            beefSelection.isMaked = true;
            beefSelection.isInteractable = true;
        }
    }

    public void OnFinishTimingCook()
    {
        BeefSelection[] beef = FindObjectsOfType<BeefSelection>();
        foreach (var beefSelection in beef)
        {
            beefSelection.isCooked = true;
            beefSelection.isInteractable = true;
        }
    }

    void Warning(string messege)
    {
        WarningUI.SetActive(true);
        warningText.text = messege;
        Debug.Log("Wrong");
    }

}
