using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAnimScript : MonoBehaviour
{
    public void GoAway()
    {
        GetComponentInParent<ClientScript>().behaviour = ClientScript.Behaviour.GetOut;

        FindObjectOfType<NewOrder>().done = true;
    }
}
