using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour
{
   public ScriptableValue plateValue;
   
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
      if (foodParts == FoodParts.BottomBun)
         cloneObj.position = spawnPosition.position;
      
      if (foodParts == FoodParts.Meat)
         cloneObj.position = spawnPosition.position;
      
      if (foodParts == FoodParts.Cheese)
         cloneObj.position = spawnPosition.position;
      
      if (foodParts == FoodParts.Cucumber)
         cloneObj.position = spawnPosition.position;

      if (foodParts == FoodParts.Tomato)
         cloneObj.position = spawnPosition.position;
      
      if (foodParts == FoodParts.TopBun)
         cloneObj.position = spawnPosition.position;


      plateValue.value += foodValue;
      Debug.Log(plateValue.value + " " + GameFlow.instance.orderValue);
   }
}
