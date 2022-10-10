using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFood : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform[] spawnPoints;
    
    [Header("Food Prefabs")]
    public GameObject[] foodPartsPrefabs;

    int spawnIndex;


    public void onClickSelectFood(int index)
    {
        if (spawnIndex < spawnPoints.Length)
        {
            Instantiate(foodPartsPrefabs[index], spawnPoints[spawnIndex].position, Quaternion.identity);
            spawnIndex++;
        }
        else
        {
            Debug.Log("Slot Full!!");
        }
    }

    public void onClickReset()
    {
        GameFlow.instance.plateValue = null;
        spawnIndex = 0;
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        foreach (GameObject food in foods)
        {
            Destroy(food);
        }
    }

    public void onClickResetBurger()
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        for (int i = 0; i < foods.Length; i++)
        {
            foods[i].transform.position = spawnPoints[i].position;
        }
    }

    public void OnClickSetFood(string food)
    {
        GameFlow.instance.foodName = food;
    }

    public void OnClickSetOrderValue(string value)
    {
        GameFlow.instance.orderValue = value;
    }
}
