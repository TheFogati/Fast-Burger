using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryerScript : MonoBehaviour
{
    public GameObject basket;

    GameObject selected;

    bool basketUp;

    private void Start()
    {
        basketUp = true;
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            if (selected == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Fryer Handle"))
                        return;

                    if (GetComponentInChildren<FriesScript>())
                    {
                        basketUp = false;
                        GetComponentInChildren<FriesScript>().isFrying = true;
                    }
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            basketUp = true;

            if (GetComponentInChildren<FriesScript>())
                GetComponentInChildren<FriesScript>().isFrying = false;
        }


        if(basketUp)
            basket.transform.localPosition = Vector3.SmoothDamp(basket.transform.localPosition, new Vector3(0, -.0115f, .017f), ref velocity, 2 * Time.deltaTime);
        else
            basket.transform.localPosition = Vector3.SmoothDamp(basket.transform.localPosition, new Vector3(0, -.0115f, .008f), ref velocity, 2 * Time.deltaTime);

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
