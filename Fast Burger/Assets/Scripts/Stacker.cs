using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    public GameObject currentSlot;
    float height;

    void Start()
    {
        height = .011f;
        currentSlot = new GameObject("Posição " + height);
        currentSlot.transform.SetParent(transform);
        currentSlot.transform.localPosition = Vector3.zero + new Vector3(0, height, 0);
    }

    void Update()
    {
        
    }

    public void NextIngredient(float offset1, float offset2)
    {
        height += offset1;
        currentSlot.transform.localPosition = Vector3.zero + new Vector3(0, height, 0);

        height += offset2;
        currentSlot = new GameObject("Posição " + height);
        currentSlot.transform.SetParent(transform);
        currentSlot.transform.localPosition = Vector3.zero + new Vector3(0, height, 0);
    }
}
