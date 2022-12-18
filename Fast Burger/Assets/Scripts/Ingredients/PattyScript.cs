using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PattyScript : MonoBehaviour
{
    public Renderer rend;

    public bool cooking;
    public bool sideOneCooking;

    public GameObject cookingBar;
    public Slider upSide;
    public Slider downSide;

    float sideOneTimer;
    float sideTwoTimer;

    public float upSideValue;
    public float downSideValue;

    int pontoOne;
    int pontoTwo;

    float slowDown = .2f;

    Vector2 startTouch;
    Vector2 endTouch;

    void Update()
    {
        if (cooking)
        {
            cookingBar.transform.localScale = new Vector3(Mathf.Lerp(cookingBar.transform.localScale.x, .1f, .1f), Mathf.Lerp(cookingBar.transform.localScale.y, .1f, .1f), Mathf.Lerp(cookingBar.transform.localScale.z, .1f, .1f));

            if (sideOneCooking)
                SideOne();
            else
                SideTwo();

            Flip();
        }
        else
        {
            cookingBar.transform.localScale = new Vector3(Mathf.Lerp(cookingBar.transform.localScale.x, 0f, .1f), Mathf.Lerp(cookingBar.transform.localScale.y, 0f, .1f), Mathf.Lerp(cookingBar.transform.localScale.z, 0f, .1f));
        }

        upSide.value = upSideValue;
        downSide.value = downSideValue;
    }

    void SideOne()
    {
        rend.gameObject.transform.rotation = Quaternion.Slerp(rend.gameObject.transform.rotation, Quaternion.Euler(90, 0, 0), .1f);

        if (sideOneTimer < 1)
            sideOneTimer += Time.deltaTime * slowDown;

        switch (pontoOne)
        {
            case 0:
                rend.materials[0].SetFloat("_Raw_Rare", sideOneTimer);
                if (sideOneTimer >= 1)
                {
                    sideOneTimer = 0;
                    pontoOne = 1;
                }
                break;
            case 1:
                rend.materials[0].SetFloat("_Rare_Well", sideOneTimer);
                if (sideOneTimer >= 1)
                {
                    sideOneTimer = 0;
                    pontoOne = 2;
                }
                break;
            case 2:
                rend.materials[0].SetFloat("_Well_Burnt", sideOneTimer);
                break;
        }

        upSideValue += Time.deltaTime * slowDown;
    }

    void SideTwo()
    {
        rend.gameObject.transform.rotation = Quaternion.Slerp(rend.gameObject.transform.rotation, Quaternion.Euler(-90, 0, 0f), .1f);

        if (sideTwoTimer < 1)
            sideTwoTimer += Time.deltaTime * slowDown;

        switch (pontoTwo)
        {
            case 0:
                rend.materials[1].SetFloat("_Raw_Rare", sideTwoTimer);
                if (sideTwoTimer >= 1)
                {
                    sideTwoTimer = 0;
                    pontoTwo = 1;
                }
                break;
            case 1:
                rend.materials[1].SetFloat("_Rare_Well", sideTwoTimer);
                if (sideTwoTimer >= 1)
                {
                    sideTwoTimer = 0;
                    pontoTwo = 2;
                }
                break;
            case 2:
                rend.materials[1].SetFloat("_Well_Burnt", sideTwoTimer);
                break;
        }

        downSideValue += Time.deltaTime * slowDown;
    }

    void Flip()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouch = Input.GetTouch(0).position;

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouch = Input.GetTouch(0).position;

            if(endTouch.y > startTouch.y)
                sideOneCooking = !sideOneCooking;
        }

        //PC Testing
        if(Input.GetKeyDown(KeyCode.F))
            sideOneCooking = !sideOneCooking;

    }
}
