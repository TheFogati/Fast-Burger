using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public ClientSpawner clientSpawner;
    public SpawnComanda comandaSpawner;
    int clientsNum;
    bool servingClient;
    bool comandaSpawned;
    bool clientJudge;

    void Start()
    {
        clientsNum = Random.Range(4, 7);
    }

    void Update()
    {
        print(clientsNum);

        if(clientsNum > 0)
        {
            if(!servingClient)
            {
                clientSpawner.SpawnClient();
                servingClient = true;
                clientsNum--;
            }
            else
            {
                if(!comandaSpawned)
                {
                    if (clientSpawner.clientObject.GetComponent<ClientScript>().thinking)
                    {
                        comandaSpawner.SpawnOrder();
                        comandaSpawned = true;
                    }
                }
                if (comandaSpawner.order.prepare)
                {
                    clientJudge = clientSpawner.clientObject.GetComponent<ClientScript>().judging;

                    if (clientJudge)
                    {
                        clientSpawner.clientObject.GetComponent<ClientScript>().behaviour = ClientScript.Behaviour.Judge;
                    }
                    else
                        clientSpawner.clientObject.GetComponent<ClientScript>().behaviour = ClientScript.Behaviour.Wait;
                }
            }
        }
    }
}
