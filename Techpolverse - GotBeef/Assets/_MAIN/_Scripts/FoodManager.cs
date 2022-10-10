using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int
        bottomBun,
        meat,
        cheese,
        tomato,
        cucumber,
        topBun;

    public GameObject ChooseIngredientUI;


    #region SetIngredientValue
    
    public void SetBottomBunValue()
    {
        bottomBun += 1;
    }

    public void SetMeatValue()
    {
        meat += 1;
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
    
    #endregion



    #region FoodManager

    public void FoodChecker()
    {
        if (GameFlow.instance.foodName == "Burger A")
        {
            if (topBun == 1 && cucumber == 1 && tomato == 1 && meat == 1 && bottomBun == 1 && cheese == 0)
            {
                Debug.Log("Correct");
                ChooseIngredientUI.SetActive(false);
            }
            else
            {
                Debug.Log("Wrong!!");
            }
        }

        if (GameFlow.instance.foodName == "Burger B")
        {
            if (topBun == 1 && cucumber == 1 && tomato == 0 && meat == 1 && bottomBun == 1 && cheese == 1)
            {
                Debug.Log("Correct");
                ChooseIngredientUI.SetActive(false);
            }
                
            else
            {
                Debug.Log("Wrong");
            }
                
        }
    }

    public void OnClickReset()
    {
        bottomBun = 0;
        meat = 0;
        tomato = 0;
        cheese = 0;
        cucumber = 0;
        topBun = 0;
    }

    #endregion
}
