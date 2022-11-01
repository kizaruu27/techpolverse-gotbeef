using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefMeshBehaviour : MonoBehaviour
{
    public GameObject beefPrefab;
    public GameObject chickenBeefPrefab;
    public Transform spawnPoint;
    Animator beefAnim;
    
    private bool isSpawning;

    private void Start()
    {
        isSpawning = false;
    }

    public void SetBeef()
    {
        GameObject rawBeef = GameObject.FindGameObjectWithTag("Beef");

        if (!isSpawning)
        {
            Instantiate(beefPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(rawBeef);
            isSpawning = true;
        }
    }

    public void PlayBeefAnimation()
    {
        beefAnim = GameObject.FindGameObjectWithTag("Beef").GetComponent<Animator>();
        beefAnim.Play("cooking_beef_anim");
    }
}
