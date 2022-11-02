using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefSelection : MonoBehaviour
{
    public ScriptableValue plateValue;
    public bool isInteractable;

    public enum FoodParts
    {
       Beef,
       ChickenBeef
    }
    
    [Header("Object Transform")]
    public Transform cloneObj;
    [SerializeField] Transform spawnPosition;
    [SerializeField] Transform cookPosition;
    [SerializeField] Transform makePattyPostion;
    
    [Header("Value")]
    public string foodValue;
    public FoodParts foodParts;
    

    private void Awake()
    {
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
    }
    
    private void Start()
    {
        isInteractable = false;
    }

    private void OnMouseDown()
    {
        if (isInteractable)
        {
            if (foodParts == FoodParts.Beef)
            {
                cloneObj.position = spawnPosition.position;
                DeactivateInteraction();
                SetFoodValue();
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
