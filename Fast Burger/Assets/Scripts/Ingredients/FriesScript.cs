using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriesScript : MonoBehaviour
{
    Renderer[] rends;

    public bool frying;
    public bool isFrying;

    public Transform friesTransform;
    public GameObject fryingBar;
    public Slider slider;

    float timeFrying;

    public float fryingValue;

    int ponto;

    float slowDown = .2f;

    void Start()
    {
        rends = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        if(frying)
        {
            fryingBar.transform.localScale = new Vector3(Mathf.Lerp(fryingBar.transform.localScale.x, .15f, .5f), Mathf.Lerp(fryingBar.transform.localScale.y, .15f, .5f), Mathf.Lerp(fryingBar.transform.localScale.z, .15f, .5f));

            friesTransform.localRotation = Quaternion.Slerp(friesTransform.localRotation, Quaternion.Euler(0, 0, 0), .5f);

            if(isFrying)
                Frying();
        }
        else
        {
            fryingBar.transform.localScale = new Vector3(Mathf.Lerp(fryingBar.transform.localScale.x, 0f, .5f), Mathf.Lerp(fryingBar.transform.localScale.y, 0f, .5f), Mathf.Lerp(fryingBar.transform.localScale.z, 0f, .5f));

            friesTransform.localRotation = Quaternion.Slerp(friesTransform.localRotation, Quaternion.Euler(90, 0, 0), .5f);
        }
            
        slider.value = fryingValue;
    }

    void Frying()
    {
        if (timeFrying < 1)
            timeFrying += Time.deltaTime * slowDown;

        switch(ponto)
        {
            case 0:
                foreach (var r in rends)
                    r.material.SetFloat("_Uncooked_Fried", timeFrying);
                if(timeFrying >= 1)
                {
                    timeFrying = 0;
                    ponto = 1;
                }
                break;
            case 1:
                foreach (var r in rends)
                    r.material.SetFloat("_Fried_Burnt", timeFrying);
                break;
        }

        if (fryingValue < 2)
            fryingValue += Time.deltaTime * slowDown;
        else
            fryingValue = 2;
    }
}
