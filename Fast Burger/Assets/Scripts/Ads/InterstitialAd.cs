using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterstitialAd : MonoBehaviour
{
    void Update()
    {
        if (GameManager.manager.adsCounter >= 3)
            PlayAd();

    }

    void PlayAd()
    {
        GameManager.manager.adsCounter = 0;

        if (SayKit.isInterstitialAvailable())
            SayKit.showInterstitial();
    }
}
