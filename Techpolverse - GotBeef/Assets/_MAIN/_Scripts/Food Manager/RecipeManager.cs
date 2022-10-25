using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{ 
    public GameObject recipeItem;
    public Transform RecipeTransform;
    public Food foods;

    void Start()
    {
        for (int i = 0; i < foods.formulas.Length; i++)
        {
            Instantiate(recipeItem, RecipeTransform);
            recipeItem.GetComponent<TextMeshProUGUI>().text = foods.formulas[i];
        }
    }

}
