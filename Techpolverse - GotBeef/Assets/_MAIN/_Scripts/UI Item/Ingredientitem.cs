using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ingredientitem : MonoBehaviour
{
    public enum Parts
    {
        topBunn,
        bottomBunn,
        Beef,
        ChickenBeef,
        tomato,
        cucumber,
        cheese
    }
    
    [SerializeField] TextMeshProUGUI ingredientQtyText;
    private FoodManager _foodManager;
    public Parts foodParts;

    private void Awake()
    {
        _foodManager = FindObjectOfType<FoodManager>();
    }
    
    private void Update()
    {
        switch (foodParts)
        {
            case Parts.topBunn:
                ingredientQtyText.text = _foodManager.topBun.ToString();
                break;
            case Parts.cheese:
                ingredientQtyText.text = _foodManager.cheese.ToString();
                break;
            case Parts.cucumber:
                ingredientQtyText.text = _foodManager.cucumber.ToString();
                break;    
            case Parts.tomato:
                ingredientQtyText.text = _foodManager.tomato.ToString();
                break;
            case Parts.Beef:
                ingredientQtyText.text = _foodManager.beef.ToString();
                break;
            case Parts.bottomBunn:
                ingredientQtyText.text = _foodManager.bottomBun.ToString();
                break;
            case Parts.ChickenBeef:
                ingredientQtyText.text = _foodManager.chickenBeef.ToString();
                break;
        }
    }
}
