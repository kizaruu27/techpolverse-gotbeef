using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFood : MonoBehaviour
{
    [Header("Spawn Points")]
    public Transform[] spawnPoints;
    public Transform[] pattyPosition;
    
    [Header("Food Prefabs")]
    public GameObject[] foodPartsPrefabs;

    public ScriptableValue plateValue;

    int spawnIndex;
    int pattySpawnIndex;


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

    public void onClickSelectPatty(int index)
    {
        if (pattySpawnIndex < pattyPosition.Length)
        {
            Instantiate(foodPartsPrefabs[index], pattyPosition[pattySpawnIndex].position, Quaternion.identity);
            pattySpawnIndex++;
        }
        else
        {
            Debug.Log("Slot Patty Full!!");
        }
    }

    public void onClickReset()
    {
        plateValue.value = null;
        spawnIndex = 0;
        pattySpawnIndex = 0;
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
        foreach (GameObject food in foods)
        {
            Destroy(food);
        }

        Ingredientitem[] items = FindObjectsOfType<Ingredientitem>();
        foreach (var ingredientitem in items)
        {
            Destroy(ingredientitem.gameObject);
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
