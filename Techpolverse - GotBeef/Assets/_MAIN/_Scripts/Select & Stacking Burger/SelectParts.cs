using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour
{
   public ScriptableValue plateValue;
   public bool isInteractable;
   
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
   
   [Header("Value")]
   public string foodValue;


   public FoodParts foodParts;
   
   private void Awake()
   {
      spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
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
               break;
            case FoodParts.Meat:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               break;
            case  FoodParts.Cheese:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               break;
            case FoodParts.Cucumber:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               break;
            case FoodParts.Tomato:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               break;
            case FoodParts.TopBun:
               cloneObj.position = spawnPosition.position;
               DeactivateInteraction();
               break;
            
         }
         plateValue.value += foodValue;
         Debug.Log(plateValue.value + " " + GameFlow.instance.orderValue);
      }
   }

   void DeactivateInteraction()
   {
      isInteractable = false;
   }
}
