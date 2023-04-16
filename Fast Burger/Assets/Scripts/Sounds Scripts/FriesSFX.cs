using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesSFX : MonoBehaviour
{
    public AudioSource sound;

    bool isPlaying;

    void Update()
    {
        if(GetComponent<FriesScript>().isFrying)
        {
            if(!isPlaying)
            {
                sound.Play();
                isPlaying = true;
            }

            if (sound.volume < 1)
                sound.volume += Time.deltaTime * 2;
        }
        else
        {
            sound.volume -= Time.deltaTime;
            isPlaying = false;
        }
    }
}
