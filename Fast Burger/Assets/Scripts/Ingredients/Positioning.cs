using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour
{
    public enum Ingredient
    {
        Patty,
        Cheese,
        Cabbage,
        Tomato,
        TopBread,
    }
    public Ingredient ingredientType;

    public Transform lastPosition;

    public bool grab;

    bool breaded;

    float posSpeed;

    private void Start()
    {
        posSpeed = 5;
    }

    void Update()
    {
        if (!grab)
        {
            switch(ingredientType)
            {
                case Ingredient.Patty:
                    CheckPattyPosition();
                    break;
                case Ingredient.Cheese:
                    CheckCheesePosition();
                    break;
                case Ingredient.Cabbage:
                    CheckCabbagePosition();
                    break;
                case Ingredient.Tomato:
                    CheckTomatoPosition();
                    break;
                case Ingredient.TopBread:
                    CheckTopBreadPosition();
                    break;
            }
        }

        if(breaded)
            gameObject.GetComponent<Collider>().enabled = false;
    }

    void CheckPattyPosition()
    {
        if(!breaded)
        {
            RaycastHit hit;
            bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

            if(hitit)
            {
                Grillable(hit);
                Plateable(hit);
                Breadable(hit, .0055f, .0055f);
            }
            
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
    }

    void CheckCheesePosition()
    {
        if(!breaded)
        {
            RaycastHit hit;
            bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

            if(hitit)
                Breadable(hit, 0, .0044f);

            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
    }
    void CheckCabbagePosition()
    {
        if (!breaded)
        {
            RaycastHit hit;
            bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

            if(hitit)
                Breadable(hit, .0005f, .0005f);

            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
    }
    void CheckTomatoPosition()
    {
        if (!breaded)
        {
            RaycastHit hit;
            bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

            if(hitit)
                Breadable(hit, .0013f, .0013f);

            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
    }

    void CheckTopBreadPosition()
    {
        if(!breaded)
        {
            RaycastHit hit;
            bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

            if(hitit)
                Breadable(hit, .011f, 0);

            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
    }




    void Grillable(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Grill"))
        {
            lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;
            transform.GetComponent<PattyScript>().cooking = true;
        }
    }
    void Plateable(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Plate"))
        {
            lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;
            CamManager.manager.SetAssembly();
        }
            
    }
    void Breadable(RaycastHit hit, float offset1, float offset2)
    {
        if (hit.collider.CompareTag("Bread") && !breaded)
        {
            if (lastPosition.GetComponent<IngredientSpawner>())
                lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

            lastPosition = hit.collider.gameObject.GetComponent<Stacker>().currentSlot.transform;
            hit.collider.gameObject.GetComponent<Stacker>().NextIngredient(offset1, offset2);

            transform.SetParent(hit.collider.transform);

            breaded = true;
        }
    }
}
