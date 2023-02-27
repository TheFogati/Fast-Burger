using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject Ingredient;
    public Vector3 offset;
    public bool hasFresh;
    [Space]
    public bool randomRotation;

    void Update()
    {
        if(!hasFresh)
        {
            if(randomRotation)
            {
                GameObject fresh = Instantiate(Ingredient, transform.position + offset, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
                fresh.GetComponent<Positioning>().lastPosition = transform;
                hasFresh = true;
            }
            else
            {
                GameObject fresh = Instantiate(Ingredient, transform.position + offset, Quaternion.identity);
                fresh.GetComponent<Positioning>().lastPosition = transform;
                hasFresh = true;
            }
        }
    }
}
