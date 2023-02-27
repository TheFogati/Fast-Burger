using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    public GameObject clientPrefab;
    public GameObject clientObject;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnClient();
        }
    }

    public void SpawnClient()
    {
        clientObject = Instantiate(clientPrefab, transform.position, Quaternion.Euler(0, 90, 0));
    }
}
