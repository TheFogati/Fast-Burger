using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComanda : MonoBehaviour
{
    public GameObject comanda;
    public NewOrder order;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            SpawnOrder();
        }
    }

    public void SpawnOrder()
    {
        order = Instantiate(comanda, transform.position, Quaternion.identity, transform.parent).GetComponent<NewOrder>();
    }
}
