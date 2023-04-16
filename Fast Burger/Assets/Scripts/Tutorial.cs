using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject dragBurgTut;
    public GameObject flipBurgTut;
    public GameObject friePotTut;

    public void DragBurger(bool activation)
    {
        dragBurgTut.SetActive(activation);
    }

    public void FlipBurger(bool activation)
    {
        flipBurgTut.SetActive(activation);
    }

    public void FriePotato(bool activation)
    {
        friePotTut.SetActive(activation);
    }

    public void EndTutorial()
    {
        Destroy(gameObject);
    }
}
