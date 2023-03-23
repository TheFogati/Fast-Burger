using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayPositioning : MonoBehaviour
{
    public Transform lastPosition;
    Transform trashPosition;
    [Space]
    public int position;

    float posSpeed;

    void Start()
    {
        posSpeed = 5;

        trashPosition = GameObject.Find("Tray Trash").transform;
    }

    void Update()
    {
        switch(position)
        {
            case 0:
                break;
            case 1:
                lastPosition = GameObject.Find("Tray Client").transform;
                transform.SetParent(lastPosition);
                break;
            case 2:
                lastPosition = trashPosition;
                break;
        }


        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, trashPosition.position) <= .1f)
        {
            

            Destroy(gameObject);
        }
    }
}
