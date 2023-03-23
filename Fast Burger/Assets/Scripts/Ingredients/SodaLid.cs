using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaLid : MonoBehaviour
{
    SodaScript soda;

    public Transform closedPos;
    public Transform openPos;

    public GameObject straw;

    public bool closed;

    void Start()
    {
        soda = GetComponentInParent<SodaScript>();
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (!soda.filling)
        {
            transform.position = Vector3.SmoothDamp(transform.position, closedPos.position, ref velocity, 2 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, closedPos.transform.rotation, .1f);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, openPos.position, ref velocity, 2 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, openPos.transform.rotation, .1f);
        }

        if(closed)
            straw.transform.localPosition = Vector3.SmoothDamp(straw.transform.localPosition, new Vector3(0, 0, -.012f), ref velocity, 2 * Time.deltaTime);
    }
}
