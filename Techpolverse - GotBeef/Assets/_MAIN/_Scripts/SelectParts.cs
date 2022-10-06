using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour
{
   [Header("Object Transform")]
   public Transform cloneObj;
   [SerializeField] Transform spawnPosition;
   
   [Header("Value")]
   public string foodValue;

   private void Awake()
   {
      spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
   }

   private void OnMouseDown()
   {
      if (gameObject.name == "Bottom Bun(Clone)")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);
      
      if (gameObject.name == "Top Bun(Clone)")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);
      
      if (gameObject.name == "Cheese(Clone)")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);
      
      if (gameObject.name == "Meat(Clone)")
         Instantiate(cloneObj, spawnPosition.position, cloneObj.rotation);

      GameFlow.instance.plateValue += foodValue;
      Debug.Log(GameFlow.instance.plateValue + " " + GameFlow.instance.orderValue);
   }
}
