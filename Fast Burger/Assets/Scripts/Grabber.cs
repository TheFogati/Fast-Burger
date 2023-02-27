using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public float grabHeight;

    GameObject selectedObject;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Draggable"))
                        return;

                    selectedObject = hit.collider.gameObject;
                    selectedObject.GetComponent<Positioning>().grab = true;

                    if (selectedObject.GetComponent<Positioning>().GrabType == Positioning.Grabbable.Patty)
                        selectedObject.GetComponent<PattyScript>().cooking = false;
                    if (selectedObject.GetComponent<Positioning>().GrabType == Positioning.Grabbable.SodaCup)
                    {
                        selectedObject.GetComponent<SodaScript>().filling = false;
                        if(selectedObject.GetComponentInParent<SodaFountainScript>())
                            selectedObject.GetComponentInParent<SodaFountainScript>().StopFill();
                    }
                    if (selectedObject.GetComponent<Positioning>().GrabType == Positioning.Grabbable.Fries)
                        selectedObject.GetComponent<FriesScript>().frying = false;
                        
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(selectedObject != null)
            {
                selectedObject.GetComponent<Positioning>().grab = false;
                selectedObject = null;
            }
        }

        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            Vector3 velocity = Vector3.zero;
            selectedObject.transform.position = Vector3.SmoothDamp(selectedObject.transform.position, new Vector3(worldPosition.x, grabHeight, worldPosition.z), ref velocity, 2.5f * Time.deltaTime);
        }
    }

    RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;

        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
