using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaSFX : MonoBehaviour
{
    public AudioSource sound;

    bool isPlaying;

    void Update()
    {
        if(GetComponent<SodaScript>().filling)
        {
            if(!isPlaying)
            {
                sound.volume = .4f;
                sound.Play();
                isPlaying = true;
            }
        }
        else
        {
            sound.volume -= Time.deltaTime * 2;
            isPlaying = false;
        }
    }
}
