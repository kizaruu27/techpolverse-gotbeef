using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class DisplayFoodDetail : MonoBehaviour
{
    [Header("Item Database")]
    public ItemDatabase _ItemDatabase;

    [Header("Components")]
    public GameObject FoodDetail;
    public Image _foodImage;
    public GameObject formulaGrid;
    public Image formulaPrefab;

    public void DisplayImageDetail(Sprite _sprite)
    {
        _foodImage.sprite = _sprite;
    }

    public void OnOffFoodDetail(bool state)
    {
        FoodDetail.SetActive(state);
    }

    public void SetSpriteFormula(int _index)
    {
        for (int i = 0; i < formulaGrid.transform.childCount; i++)
        {
            GameObject child = formulaGrid.transform.GetChild(i).gameObject;
            Destroy(child);
        }

        foreach (var item in _ItemDatabase.foodList[_index].formulas)
        {
            foreach (var formula in _ItemDatabase.FormulasList.Formulas.FindAll((value) => (value.formulaName == item)))
            {
                // Debug.Log(formula.formulaName);

                Image Prefab = Instantiate(formulaPrefab, formulaGrid.transform);
                Prefab.sprite = formula.formulaSprite;
            }
        }
    }
}
