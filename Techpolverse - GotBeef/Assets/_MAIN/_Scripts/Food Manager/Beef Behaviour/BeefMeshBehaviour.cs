using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefMeshBehaviour : MonoBehaviour
{
    public static BeefMeshBehaviour instance;
    
    public GameObject beefPrefab;
    public GameObject chickenBeefPrefab;
    Animator beefAnim;
    
    [HideInInspector]
    public bool isSpawning;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isSpawning = false;
    }

    public void SetBeef()
    {
        Debug.Log("test");
        RawMeet rawBeef = FindObjectOfType<RawMeet>();

        if (!isSpawning)
        {
            if (rawBeef.parts == RawMeet.BurgerParts.Beef)
            {
                Instantiate(beefPrefab, rawBeef.transform.position, Quaternion.identity);
                Destroy(rawBeef.gameObject);
                isSpawning = true;
            }
            else if (rawBeef.parts == RawMeet.BurgerParts.ChickenBeef)
            {
                Instantiate(chickenBeefPrefab, rawBeef.transform.position, Quaternion.identity);
                Destroy(rawBeef.gameObject);
                isSpawning = true;
            }
        }
    }

    public void PlayBeefAnimation()
    {
        beefAnim = GameObject.FindGameObjectWithTag("Beef").GetComponent<Animator>();
        beefAnim.Play("cooking_beef_anim");
    }
}
