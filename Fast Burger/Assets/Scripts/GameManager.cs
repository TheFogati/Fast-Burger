using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    public int adsCounter = 0;

    #region Don't Destroy
    public static GameManager manager;
    void Awake()
    {
        if (!manager)
            manager = this;
        else if (manager)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
    #endregion
}
