using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject Ingredient;
    public bool hasFresh;

    void Update()
    {
        if(!hasFresh)
        {
            GameObject fresh = Instantiate(Ingredient, transform.position, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            fresh.GetComponent<Positioning>().lastPosition = transform;
            hasFresh = true;
        }
    }
}
