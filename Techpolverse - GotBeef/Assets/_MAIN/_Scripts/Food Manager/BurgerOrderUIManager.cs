using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerOrderUIManager : MonoBehaviour
{
    public ItemDatabase foodDatabase;
    public Transform menuGrid;

    private void Start()
    {
        ShowBurgerOrderUI(GameFlow.instance.foodIndex);
    }

    void ShowBurgerOrderUI(int index)
    {
        for (int i = 0; i < foodDatabase.foodList[index].formulaImages.Length; i++)
        {
            Instantiate(foodDatabase.foodList[index].formulaImages[i], menuGrid);
        }
    }
}
