using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSFX : MonoBehaviour
{
    public AudioSource sound;

    bool isPlaying;

    void Update()
    {
        if(GetComponent<PattyScript>().cooking)
        {
            if(!isPlaying)
            {
                sound.Play();
                isPlaying = true;
            }

            if (sound.volume < .8f)
                sound.volume += Time.deltaTime * 2;
        }
        else
        {
            sound.volume -= Time.deltaTime;
            isPlaying = false;
        }
    }
}
