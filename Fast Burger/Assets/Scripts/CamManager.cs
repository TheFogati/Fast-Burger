using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public GameObject cookingCam;
    public GameObject assemblyCam;
    public GameObject fryingCam;
    public GameObject fillingCam;
    public GameObject servingCam;

    public static CamManager manager;

    private void Start()
    {
        manager = this;

        SetServing();
    }

    public void SetCooking()
    {
        TurnAllOff();
        cookingCam.SetActive(true);
    }
    public void SetAssembly()
    {
        TurnAllOff();
        assemblyCam.SetActive(true);
    }
    public void SetFrying()
    {
        TurnAllOff();
        fryingCam.SetActive(true);

    }
    public void SetFilling()
    {
        TurnAllOff();
        fillingCam.SetActive(true);
    }
    public void SetServing()
    {
        TurnAllOff();
        servingCam.SetActive(true);
    }

    void TurnAllOff()
    {
        cookingCam.SetActive(false);
        assemblyCam.SetActive(false);
        fryingCam.SetActive(false);
        fillingCam.SetActive(false);
        servingCam.SetActive(false);
    }
}
