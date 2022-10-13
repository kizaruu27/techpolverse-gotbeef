using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour
{
   public ScriptableValue plateValue;
   public bool isInteractable;
   public bool isMaked;
   public bool isCooked;
   
   public enum FoodParts
   {
      BottomBun,
      Meat,
      Cheese,
      Cucumber,
      Tomato,
      TopBun
   }

   [Header("Object Transform")]
   public Transform cloneObj;
   [SerializeField] Transform spawnPosition;
   [SerializeField] Transform cookPosition;
   [SerializeField] private Transform makePattyPostion;
   
   [Header("Value")]
   public string foodValue;


   public FoodParts foodParts;
   
   private void Awake()
   {
      spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
      makePattyPostion = GameObject.FindGameObjectWithTag("MakePatty").transform;
   }

   private void Start()
   {
      if (foodParts == FoodParts.Meat)
      {
         isCooked = false;
         isMaked = false;
      }
         
   }

   private void OnMouseDown()
   {
      if (isInteractable)
      {
         switch (foodParts)
         {
            case FoodParts.BottomBun:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               SetFoodValue();
               break;
            case FoodParts.Meat:
               
               break;
            case  FoodParts.Cheese:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               SetFoodValue();
               break;
            case FoodParts.Cucumber:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               SetFoodValue();
               break;
            case FoodParts.Tomato:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               SetFoodValue();
               break;
            case FoodParts.TopBun:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               SetFoodValue();
               break;
            
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
