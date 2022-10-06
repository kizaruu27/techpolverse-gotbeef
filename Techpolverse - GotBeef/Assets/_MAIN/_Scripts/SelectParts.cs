using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour
{
   public Transform cloneObj;
   public Transform spawnPosition;
   public string foodValue; 

   private void OnMouseDown()
   {
      if (gameObject.name == "Bottom Bun")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);
      
      if (gameObject.name == "Top Bun")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);
      
      if (gameObject.name == "Cheese")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);
      
      if (gameObject.name == "Meat")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);

      GameFlow.instance.plateValue += foodValue;
      Debug.Log(GameFlow.instance.plateValue + " " + GameFlow.instance.orderValue);
   }
}
