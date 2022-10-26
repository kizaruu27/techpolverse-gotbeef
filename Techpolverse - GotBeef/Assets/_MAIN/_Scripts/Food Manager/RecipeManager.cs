using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{ 
    public GameObject recipeItem;
    public Transform RecipeTransform;
    public ItemDatabase foodDatabase;

    void Start()
    {
        ShowRecipe(GameFlow.instance.foodIndex);
    }

    void ShowRecipe(int index)
    {
        for (int i = 0; i < foodDatabase.foodList[index].formulas.Length; i++)
        {
            Instantiate(recipeItem, RecipeTransform);
            recipeItem.GetComponent<TextMeshProUGUI>().text = foodDatabase.foodList[index].formulas[i];
        }
    }

}
