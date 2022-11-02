using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefMeshBehaviour : MonoBehaviour
{
    public GameObject beefPrefab;
    public GameObject chickenBeefPrefab;
    Animator beefAnim;
    
    private bool isSpawning;

    private void Start()
    {
        isSpawning = false;
    }

    public void SetBeef()
    {
        RawMeet rawBeef = GameObject.FindGameObjectWithTag("Beef").GetComponent<RawMeet>();

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
