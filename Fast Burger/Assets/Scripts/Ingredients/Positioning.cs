using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioning : MonoBehaviour
{
    public enum Grabbable
    {
        Patty,
        Cheese,
        Cabbage,
        Tomato,
        TopBread,
        BottomBread,
        SodaCup,
        Fries,
    }
    public Grabbable GrabType;

    public Transform lastPosition;

    public bool grab;

    bool breaded;
    public bool hasMeat;

    float posSpeed;

    [Range(0,2)]public int sodaSize;
    int sodaBrand = -1;

    private void Start()
    {
        posSpeed = 5;
    }

    void Update()
    {
        if (!grab)
        {
            switch(GrabType)
            {
                case Grabbable.Patty:
                    CheckPattyPosition();
                    break;
                case Grabbable.Cheese:
                    CheckCheesePosition();
                    break;
                case Grabbable.Cabbage:
                    CheckCabbagePosition();
                    break;
                case Grabbable.Tomato:
                    CheckTomatoPosition();
                    break;
                case Grabbable.TopBread:
                    CheckTopBreadPosition();
                    break;
                case Grabbable.BottomBread:
                    CheckBottomBreadPosition();
                    break;
                case Grabbable.SodaCup:
                    CheckSodaCupPosition();
                    break;
                case Grabbable.Fries:
                    CheckFriesPosition();
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
                Breadable(hit, .0055f, .0055f, -1);
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
                Breadable(hit, 0, .0044f, 0);

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
                Breadable(hit, .0005f, .0005f, 1);

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
                Breadable(hit, .0013f, .0013f, 2);

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
                Breadable(hit, .011f, 0, -1);

            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
        }
    }
    void CheckBottomBreadPosition()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
    }

    void CheckSodaCupPosition()
    {
        RaycastHit hit;
        bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

        Fillable(hit);

        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
    }
    void CheckFriesPosition()
    {
        RaycastHit hit;
        bool hitit = Physics.Raycast(transform.position, Vector3.down, out hit);

        Fryable(hit);

        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, lastPosition.position, ref velocity, posSpeed * Time.deltaTime);
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

            ScoreScript.PattyValue(GetComponent<PattyScript>().upSideValue, 0);
            ScoreScript.PattyValue(GetComponent<PattyScript>().downSideValue, 1);

            CamManager.manager.SetAssembly();
        }
            
    }
    void Breadable(RaycastHit hit, float offset1, float offset2, int id)
    {
        if (hit.collider.CompareTag("Bread") && !breaded)
        {
            if (GrabType == Grabbable.Patty)
                hit.collider.GetComponent<Positioning>().hasMeat = true;

            if (GrabType == Grabbable.TopBread)
            {
                if (!hit.collider.GetComponent<Positioning>().hasMeat)
                    return;

                hit.collider.GetComponent<Stacker>().tag = "Untagged";
                hit.collider.GetComponent<Positioning>().lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

                Transform burgerPoint = GameObject.FindGameObjectWithTag("Burger Point").transform;

                hit.collider.GetComponent<Positioning>().lastPosition = burgerPoint;
                hit.collider.transform.SetParent(burgerPoint);


                if (FindObjectOfType<NewOrder>().hasFries)
                {
                    CamManager.manager.SetFrying();
                    ScoreScript.hasFries = true;
                }
                else
                {
                    CamManager.manager.SetFilling();
                    ScoreScript.hasFries = false;
                }
            }

            if (lastPosition.GetComponent<IngredientSpawner>())
                lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

            lastPosition = hit.collider.gameObject.GetComponent<Stacker>().currentSlot.transform;
            hit.collider.gameObject.GetComponent<Stacker>().NextIngredient(offset1, offset2);

            ScoreScript.AddIngredient(id);

            transform.SetParent(hit.collider.transform);

            breaded = true;
        }
    }
    void Fillable(RaycastHit hit)
    {
        if (hit.collider.CompareTag("FillRanpa"))
        {
            if(!transform.GetComponent<SodaScript>().perkiFilled && !transform.GetComponent<SodaScript>().coolKoalaFilled)
            {
                print("Ranpa");

                transform.GetComponent<SodaScript>().Ranpa();
                transform.GetComponent<SodaScript>().filling = true;

                if (lastPosition.GetComponent<IngredientSpawner>())
                    lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

                lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;

                transform.SetParent(hit.transform.parent);
                GetComponentInParent<SodaFountainScript>().FillRanpa();

                sodaBrand = 0;
            }
        }
        else if (hit.collider.CompareTag("FillPerki"))
        {
            if (!transform.GetComponent<SodaScript>().ranpaFilled && !transform.GetComponent<SodaScript>().coolKoalaFilled)
            {
                print("Perki");

                transform.GetComponent<SodaScript>().Perki();
                transform.GetComponent<SodaScript>().filling = true;

                if (lastPosition.GetComponent<IngredientSpawner>())
                    lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

                lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;

                transform.SetParent(hit.transform.parent);
                GetComponentInParent<SodaFountainScript>().FillPerki();

                sodaBrand = 1;
            }
        }
        else if (hit.collider.CompareTag("FillCoolKoala"))
        {
            if (!transform.GetComponent<SodaScript>().ranpaFilled && !transform.GetComponent<SodaScript>().perkiFilled)
            {
                print("Cool Koala");

                transform.GetComponent<SodaScript>().CoolKoala();
                transform.GetComponent<SodaScript>().filling = true;

                if (lastPosition.GetComponent<IngredientSpawner>())
                    lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

                lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;

                transform.SetParent(hit.transform.parent);
                GetComponentInParent<SodaFountainScript>().FillCoolKoala();

                sodaBrand = 2;
            }
        }
        else if(hit.collider.CompareTag("SodaPlate"))
        {
            if(GetComponent<SodaScript>().coolKoalaFilled || GetComponent<SodaScript>().perkiFilled || GetComponent<SodaScript>().ranpaFilled)
            {
                if (GetComponentInParent<SodaFountainScript>())
                {
                    transform.GetComponentInChildren<SodaLid>().closed = true;
                    GetComponentInParent<SodaFountainScript>().filling = false;

                    transform.SetParent(null);
                    CamManager.manager.SetServing();
                }

                lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;

                ScoreScript.SodaFill(GetComponent<SodaScript>().fill, sodaSize, sodaBrand);
                FindObjectOfType<ClientScript>().judging = true;

                transform.SetParent(lastPosition);

                breaded = true;
            }
        }
    }
    void Fryable(RaycastHit hit)
    {
        if(hit.collider.CompareTag("Fryer"))
        {
            lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;
            transform.GetComponent<FriesScript>().frying = true;
            transform.SetParent(hit.collider.transform);
        }
        if(hit.collider.CompareTag("FryBox"))
        {
            lastPosition = hit.collider.gameObject.GetComponent<Positioner>().slot.transform;
            transform.SetParent(hit.collider.transform);

            Transform friesPoint = GameObject.FindGameObjectWithTag("Fries Point").transform;

            if(hit.collider.GetComponent<Positioning>().lastPosition.GetComponent<IngredientSpawner>())
                hit.collider.GetComponent<Positioning>().lastPosition.GetComponent<IngredientSpawner>().hasFresh = false;

            hit.collider.GetComponent<Positioning>().lastPosition = friesPoint;
            hit.collider.transform.SetParent(friesPoint);

            ScoreScript.FriesValue(GetComponent<FriesScript>().fryingValue);

            CamManager.manager.SetFilling();

            breaded = true;
        }
    }
}
