using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource audioOsurce;
    public AudioClip[] clips;
    
    void Awake()
    {
        instance = this;
    }

    public void playSound(int index)
    {
        audioOsurce.PlayOneShot(clips[index]);
    }
    
}
