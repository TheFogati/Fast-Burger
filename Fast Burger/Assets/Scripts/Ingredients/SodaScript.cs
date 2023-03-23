using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SodaScript : MonoBehaviour
{
    public Renderer cup;
    public Renderer liquid;
    public ParticleSystem particle;
    [Space]
    public bool filling;
    public float fill;

    public GameObject fillingBar;
    public Slider slider;

    float openCup;

    public bool coolKoalaFilled;
    public bool ranpaFilled;
    public bool perkiFilled;

    void Start()
    {
        liquid.material.SetFloat("_Filling", 0);
        cup.material.SetFloat("_Half", 1);

        openCup = 1;
    }

    void Update()
    {
        if (filling)
        {
            fillingBar.transform.localScale = new Vector3(Mathf.Lerp(fillingBar.transform.localScale.x, .7f, .5f), Mathf.Lerp(fillingBar.transform.localScale.y, .7f, .5f), Mathf.Lerp(fillingBar.transform.localScale.z, .7f, .5f));

            fill += (Time.deltaTime * .3f);
            liquid.material.SetFloat("_Filling", fill);

            if(fill >= 1)
                particle.enableEmission = true;
            else
                particle.enableEmission = false;

            if(openCup > 0)
            {
                openCup -= (Time.deltaTime * 5);
                cup.material.SetFloat("_Half", openCup);
            }
        }
        else
        {
            fillingBar.transform.localScale = new Vector3(Mathf.Lerp(fillingBar.transform.localScale.x, 0f, .5f), Mathf.Lerp(fillingBar.transform.localScale.y, 0f, .5f), Mathf.Lerp(fillingBar.transform.localScale.z, 0f, .5f));

            particle.enableEmission = false;

            if(openCup < 1)
            {
                openCup += (Time.deltaTime * 5);
                cup.material.SetFloat("_Half", openCup);
            }
        }

        slider.value = fill;
    }

    public void CoolKoala()
    {
        coolKoalaFilled = true;

        liquid.material.SetColor("_Liquid_Color", new Color(.1f, 0f, 0f, 1f));
        particle.startColor = new Color(.25f, 0f, 0f, .9f);
    }

    public void Ranpa()
    {
        ranpaFilled = true;

        liquid.material.SetColor("_Liquid_Color", new Color(.27f, 0f, .55f, 1f));
        particle.startColor = new Color(.3f, 0f, .4f, .9f);
    }

    public void Perki()
    {
        perkiFilled = true;

        liquid.material.SetColor("_Liquid_Color", new Color(.6f, .1f, 0f, 1f));
        particle.startColor = new Color(.7f, .3f, 0f, .9f);
    }
}
