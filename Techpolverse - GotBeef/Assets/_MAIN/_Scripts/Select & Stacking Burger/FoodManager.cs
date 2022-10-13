using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int
        bottomBun,
        beef,
        chickenBeef,
        cheese,
        tomato,
        cucumber,
        topBun;

    public GameObject ChooseIngredientUI;
    public GameObject BurgerUI;

    public ScriptableValue plateValue;
    public Food BeefBurger;
    public Food ChickenBurger;
    
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
                SetInteractable();
            }
            else
            {
                Debug.Log("Wrong!!");
            }
        }

        if (GameFlow.instance.foodName == ChickenBurger.foodName)
        {
            if (topBun == 1 && cucumber == 1 && tomato == 0 && beef == 0 && bottomBun == 1 && cheese == 1 && chickenBeef == 1)
            {
                Debug.Log("Correct");
                ChooseIngredientUI.SetActive(false);
                BurgerUI.SetActive(true);
                SetInteractable();
            }
                
            else
            {
                Debug.Log("Wrong");
            }
                
        }
    }

    public void BurgerCheck()
    {
        if (plateValue.value == GameFlow.instance.orderValue)
            Debug.Log("Correct");
        else
            Debug.Log("Wrong!!");
    }

    public void OnClickReset()
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

    public void SetInteractable()
    {
        SelectParts[] parts = FindObjectsOfType<SelectParts>();

        foreach (var foodparts in parts)
        {
            foodparts.isInteractable = true;
        }

    }

}
