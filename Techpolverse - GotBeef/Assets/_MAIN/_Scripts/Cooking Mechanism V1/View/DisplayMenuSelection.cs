using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class DisplayMenuSelection : MonoBehaviour
{
    public GameObject MenuSelection;

    [Header("Decription")]
    public TextMeshProUGUI descriptionText;
    public Image foodImage;

    [Header("Components")]
    public int selectionIndex;
    public GameObject menuGrid;
    public Button btnMenuPrefab;
    public GameObject panelRecipe;


    public void SetButtonSelection(List<Food> _foodList)
    {
        foreach (var (item, index) in _foodList.Select((value, i) => (value, i)))
        {
            Button objMenu = Instantiate(btnMenuPrefab, menuGrid.transform) as Button;
            objMenu.name = item.foodName;
            BtnMenuHandler handler = objMenu.GetComponent<BtnMenuHandler>();
            handler._btnIndex = index;
            handler._image.sprite = item.foodSprite;
            handler.foodName = item.foodName;
            handler.orderValue = item.orderValue;
        }
    }

    public void SetDescription(string txt, Sprite image)
    {
        descriptionText.text = txt;
        foodImage.sprite = image;
        
        panelRecipe.SetActive(true); // set gameobject btn
    }

    public void OnOffMenuSelection(bool state)
    {
        MenuSelection.SetActive(state);
    }

}
