using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefSelection : MonoBehaviour
{
    public ScriptableValue plateValue;
    public bool isInteractable;
    public bool isMaked;
    public bool isCooked;
    
    public enum FoodParts
    {
       Beef
    }
    
    [Header("Object Transform")]
    public Transform cloneObj;
    [SerializeField] Transform spawnPosition;
    [SerializeField] Transform cookPosition;
    [SerializeField] Transform makePattyPostion;
    
    [Header("Value")]
    public string foodValue;
    public FoodParts foodParts;

    [Header("UI Components")]
    [SerializeField] UIHandler uiHandler;

    private void Awake()
    {
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        makePattyPostion = GameObject.FindGameObjectWithTag("MakePatty").transform;
        uiHandler = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIHandler>();
    }
    
    private void Start()
    {
        isCooked = false;
        isMaked = false;
    }

    private void OnMouseDown()
    {
        if (isInteractable)
        {
            if (foodParts == FoodParts.Beef)
            {
                if (!isMaked)
                {
                    cloneObj.position = makePattyPostion.position;
                    uiHandler.ActivateBalanceCookingUI();
                    DeactivateInteraction();
                }
                else
                {
                    cloneObj.position = spawnPosition.position;
                    DeactivateInteraction();
                    SetFoodValue();
                }
            }
        }
    }
    
    void DeactivateInteraction()
    {
        isInteractable = false;
    }
    
    void SetFoodValue()
    {
        plateValue.value += foodValue;
        Debug.Log(plateValue.value + " " + GameFlow.instance.orderValue);
    }
}
