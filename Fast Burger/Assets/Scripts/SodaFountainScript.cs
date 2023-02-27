using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaFountainScript : MonoBehaviour
{
    public Transform largeSodaPoint;
    public Transform mediumSodaPoint;
    public Transform smallSodaPoint;
    [Space]
    public ParticleSystem perki;
    public ParticleSystem ranpa;
    public ParticleSystem coolKoala;
    [Space]
    public bool filling;


    void Start()
    {
        StopFill();
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (!filling)
        {
            largeSodaPoint.position = Vector3.SmoothDamp(largeSodaPoint.position, new Vector3(.11f, 1.39f, -.23f), ref velocity, 2 * Time.deltaTime);
            mediumSodaPoint.position = Vector3.SmoothDamp(mediumSodaPoint.position, new Vector3(0, 1.39f, -.23f), ref velocity, 2 * Time.deltaTime);
            smallSodaPoint.position = Vector3.SmoothDamp(smallSodaPoint.position, new Vector3(-.11f, 1.39f, -.23f), ref velocity, 2 * Time.deltaTime);
        }
        else
        {
            largeSodaPoint.position = Vector3.SmoothDamp(largeSodaPoint.position, new Vector3(.11f, 1.39f, .23f), ref velocity, 2 * Time.deltaTime);
            mediumSodaPoint.position = Vector3.SmoothDamp(mediumSodaPoint.position, new Vector3(0, 1.39f, .23f), ref velocity, 2 * Time.deltaTime);
            smallSodaPoint.position = Vector3.SmoothDamp(smallSodaPoint.position, new Vector3(-.11f, 1.39f, .23f), ref velocity, 2 * Time.deltaTime);
        }
    }

    public void FillPerki()
    {
        perki.enableEmission = true;
        filling = true;
    }
    public void FillRanpa()
    {
        ranpa.enableEmission = true;
        filling = true;
    }
    public void FillCoolKoala()
    {
        coolKoala.enableEmission = true;
        filling = true;
    }
    public void StopFill()
    {
        perki.enableEmission = false;
        ranpa.enableEmission = false;
        coolKoala.enableEmission = false;
    }

}
