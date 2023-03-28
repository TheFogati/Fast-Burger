using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorScript : MonoBehaviour
{
    Projector projector;

    public Material no;
    public Material yes;


    void Start()
    {
        projector = GetComponent<Projector>();
        projector.material = no;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(90,0,180);


        if (GetComponentInParent<Positioning>().grab)
        {
            projector.enabled = true;

            RaycastHit hit;
            bool hitit = Physics.Raycast(transform.position, Vector3.down * 2, out hit);

            if (hitit)
            {
                if(GetComponentInParent<Positioning>().GrabType == Positioning.Grabbable.TopBread)
                {
                    if(hit.collider.GetComponent<Positioning>().hasMeat)
                    {
                        if (hit.collider.GetComponent<Positioner>() || hit.collider.GetComponent<Stacker>())
                            projector.material = yes;
                        else
                            projector.material = no;
                    }
                    else
                        projector.material = no;
                }
                else if(GetComponentInParent<Positioning>().GrabType == Positioning.Grabbable.SodaCup)
                {
                    if(hit.collider.CompareTag("SodaPlate"))
                    {
                        if(GetComponentInParent<SodaScript>().fill > 0)
                        {
                            if (hit.collider.GetComponent<Positioner>() || hit.collider.GetComponent<Stacker>())
                                projector.material = yes;
                            else
                                projector.material = no;
                        }
                    }
                    else
                    {
                        if (hit.collider.GetComponent<Positioner>() || hit.collider.GetComponent<Stacker>())
                            projector.material = yes;
                        else
                            projector.material = no;
                    }
                }
                else
                {
                    if (hit.collider.GetComponent<Positioner>() || hit.collider.GetComponent<Stacker>())
                        projector.material = yes;
                    else
                        projector.material = no;
                }
            }
        }
        else
            projector.enabled = false;

        }
}
