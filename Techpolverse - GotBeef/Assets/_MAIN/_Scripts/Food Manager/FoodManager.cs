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
    public GameObject[] ingredientItems;
    public Transform itemContainer;

    [Header("Recipe Staging")]
    public List<string> RecipStaging;

    [Header("Scriptable Value")]
    public ScriptableValue plateValue;
    public ItemDatabase _FoodDatabase;

    [Header("Cooking Components")]
    [SerializeField] V1_CookingManager _perfectCooking;
    [SerializeField] CookingResult _balanceCooking;
    [SerializeField] CameraManager _cameraManager;
    [SerializeField] ScoreManager _scoreManager;

    [Header("Ingredient Slot")]
    public int slotMax;
    int currentSlot;
    public int pattySlotMax;
    int currentPattySlot;

    public GameObject balanceCookingPrefab;

    private bool isSpawned;


    private void Awake()
    {
        instance = this;
        isSpawned = false;
    }

    private void Start()
    {
        currentSlot = 0;
        currentPattySlot = 0;
    }

    #region SetIngredientValue

    public void SetBottomBunValue()
    {
        if (currentSlot < slotMax)
        {
            currentSlot++;
            if (bottomBun < 1)
            {
                SpawnIngredientItemUI(0);
            }
            bottomBun += 1;
            RecipStaging.Add("bottom bun");
        }
        else
        {
            Debug.Log("Slot Full!");
        }
    }

    public void SetMeatValue()
    {
        if (currentPattySlot < pattySlotMax)
        {
            currentPattySlot++;
            if (beef < 1)
            {
                SpawnIngredientItemUI(1);
            }
            beef += 1;
            RecipStaging.Add("beef");
        }
        else
        {
            Debug.Log("Slot Full!");
        }
    }

    public void SetCheeseValue()
    {
        if (currentSlot < slotMax)
        {
            currentSlot++;
            if (cheese < 1)
            {
                SpawnIngredientItemUI(2);
            }
            cheese += 1;
            RecipStaging.Add("cheese");
        }
        else
        {
            Debug.Log("Slot Full!");
        }
    }

    public void SetTomatoValue()
    {
        if (currentSlot < slotMax)
        {
            currentSlot++;
            if (tomato < 1)
            {
                SpawnIngredientItemUI(3);

            }
            tomato += 1;
            RecipStaging.Add("tomato");
        }
        else
        {
            Debug.Log("Slot Full!");
        }
    }

    public void SetCucumberValue()
    {
        if (currentSlot < slotMax)
        {
            currentSlot++;
            if (cucumber < 1)
            {
                SpawnIngredientItemUI(4);
            }
            cucumber += 1;
            RecipStaging.Add("cucumber");
        }
        else
        {
            Debug.Log("Slot Full!");

        }
    }

    public void SetTopBunnValue()
    {
        if (currentSlot < slotMax)
        {
            currentSlot++;
            if (topBun < 1)
            {
                SpawnIngredientItemUI(5);
            }
            topBun += 1;
            RecipStaging.Add("top bun");
        }
        else
        {
            Debug.Log("Slot Full!");
        }
    }

    public void SetChickenBeef()
    {
        if (currentPattySlot < pattySlotMax)
        {
            currentPattySlot++;
            if (chickenBeef < 1)
            {
                SpawnIngredientItemUI(6);
            }
            chickenBeef += 1;
            RecipStaging.Add("chiken Beef");
        }
        else
        {
            Debug.Log("Slot Full!");
        }
        
    }

    #endregion



    #region FoodManager

    public void FoodChecker()
    {
        var item = _FoodDatabase.foodList.Find((value) => value.foodName == GameFlow.instance.foodName);

        if (RecipStaging.Count > 0)
        {
            for (int i = 0; i < RecipStaging.Count; i++)
            {
                if (RecipStaging.Count < item.formulas.Length)
                {
                    Warning($"Bahan yang diperlukan kurang !!");
                    Debug.Log("less material");
                }
                else if (!item.formulas.Contains(RecipStaging[i]))
                {
                    Warning($"Bahan {RecipStaging[i]} tidak sesuai!");
                    Debug.Log("incorrect");
                }
                else
                {
                    Debug.Log("Correct");
                    ChooseIngredientUI.SetActive(false);
                    
                    
                    if (!isSpawned)
                    {
                        StartBalanceCooking();
                        isSpawned = true;
                    }
                    
                    _cameraManager.SetCameraToCookingMode();
                }
            }
        }
        else
        {
            Warning($" pilih bahan terlebih dahulu !!");
        }

    }

    public void BurgerCheck()
    {
        if (plateValue.value == GameFlow.instance.orderValue)
        {
            Debug.Log("Correct");
            ResultUI.SetActive(true);
            _scoreManager.GenerateBalanceCookingScore(balanceCookingResultText);
            DisplayPerfectCookingScore();
            // DisplayBalanceCookingScore();
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

        RecipStaging.Clear();
        currentSlot = 0;
        currentPattySlot = 0;
    }

    public void ResetBurger()
    {
        plateValue.value = null;
        isSpawned = false;
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

    public void SpawnIngredientItemUI(int index)
    {
        Instantiate(ingredientItems[index], itemContainer.transform);
    }

    #region Initiate Cooking

    public void StartBalanceCooking()
    {
        Instantiate(balanceCookingPrefab, FindObjectOfType<Canvas>().transform);
    }

    #endregion


}
