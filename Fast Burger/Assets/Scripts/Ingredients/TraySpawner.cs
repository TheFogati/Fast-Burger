using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraySpawner : MonoBehaviour
{
    public GameObject tray;
    public Vector3 offset;
    public bool hasFresh;


    void Update()
    {
        if(!hasFresh)
        {
            GameObject fresh = Instantiate(tray, transform.position + offset, Quaternion.identity);
            fresh.GetComponent<TrayPositioning>().lastPosition = transform;
            hasFresh = true;
        }
    }
}
