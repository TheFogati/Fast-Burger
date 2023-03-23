using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    //Patty
    static float pattySide1; //up
    static float pattySide2; //down

    //Burger
    static int cheeseQtd;
    static int lettuceQtd;
    static int tomatoQtd;
    static int onionQtd;
    static int pickleQtd;

    //Fries
    static float friesFrieness;
    public static bool hasFries;

    //Soda
    static float sodaFilling;
    static int cupSize;
    static int sodaBrand;

    float score;

    NewOrder order;
    public bool checkOrder;
    [Space]
    public IngredientSpawner burgerSpawn;
    public IngredientSpawner friesSpawn;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        print("Patty Side Up = " + pattySide1 + "; Patty Side Down = " + pattySide2);
        print("Cheese = " + cheeseQtd + "; Lettuce = " + lettuceQtd + "; Tomato = " + tomatoQtd + "; Pickle = " + pickleQtd + "; Onion = " + onionQtd);
        if (hasFries) { print("Fries frieness = " + friesFrieness); } else { print("No Fries"); }
        print("Cup size = " + cupSize + "; Brand = " + sodaBrand + "; Filling = " + sodaFilling);
        */

        if(order)
        {
            if (checkOrder)
            {
                checkOrder = false;
                StartCoroutine(CheckOrder());
            }
        }
        else
            order = FindObjectOfType<NewOrder>();
    }

    public static void PattyValue(float value, int side)
    {
        if(side == 0)
            pattySide1 = value;
        else
            pattySide2 = value;
    }

    public static void AddIngredient(int ingredientId)
    {
        /*Ingredients IDs
            0 - Cheese
            1 - Lettuce
            2 - Tomato
            3 - Pickle
            4 - Onion
        */

        switch(ingredientId)
        {
            case 0:
                cheeseQtd++;
                break;
            case 1:
                lettuceQtd++;
                break;
            case 2:
                tomatoQtd++;
                break;
            case 3:
                pickleQtd++;
                break;
            case 4:
                onionQtd++;
                break;
        }
    }

    public static void FriesValue(float value)
    {
        friesFrieness = value;
    }

    public static void SodaFill(float filling, int size, int brand)
    {
        /*Soda Brands
            0 - Ranpa
            1 - Perki
            2 - Cool Koala
        */

        sodaFilling = filling;
        cupSize = size;
        sodaBrand = brand;
    }

    void ResetAll()
    {
        pattySide1 = 0;
        pattySide2 = 0;

        cheeseQtd = 0;
        lettuceQtd = 0;
        tomatoQtd = 0;
        onionQtd = 0;
        pickleQtd = 0;

        friesFrieness = 0;
        hasFries = false;

        sodaFilling = 0;
        cupSize = 0;
        sodaBrand = 0;

        score = 0;
    }

    IEnumerator CheckOrder()
    {
        score += CalculatePatty(pattySide1);
        score += CalculatePatty(pattySide2);
        score += CalculateFries(friesFrieness);
        score += CalculateSoda(sodaFilling);
        score += CalculateIngredients();

        print("total = " + score);

        yield return new WaitForSeconds(3);

        ClientScript client = FindObjectOfType<ClientScript>();
        print(client.name);

        if (score >= 0 && score <= 20)
            client.satisfaction = 1; //Very Angry
        else if (score > 20 && score <= 40)
            client.satisfaction = 2; //Angry
        else if (score > 40 && score <= 60)
            client.satisfaction = 3; //Neutral
        else if (score > 60 && score <= 80)
            client.satisfaction = 4; //Happy
        else if (score > 80 && score <= 100)
            client.satisfaction = 5; //Very Happy

        
        client.judging = false;
        client.behaviour = ClientScript.Behaviour.React;

        burgerSpawn.hasFresh = false;
        friesSpawn.hasFresh = false;

        ResetAll();

        print("Checked");
    }

    float CalculatePatty(float sideScore)
    {
        float result;

        if (sideScore <= 2)
            result = 35 * sideScore / 2;
        else
            result = ((35 * sideScore / 3) - 35) / -.33333f;

        return result;
    }

    float CalculateFries(float frieness)
    {
        float result;

        if (frieness <= 1)
            result = 20 * frieness;
        else
            result = ((20 * frieness / 2) - 20) / -.5f;


        if (hasFries)
            return result;
        else
            return 20;
    }

    float CalculateSoda(float fillness)
    {
        float result = 0;

        if(fillness <= .8f)
            result = 3 * fillness/ .8f;
        else
            result = (3 * fillness - 3)/ -.2f;

        NewOrder order = FindObjectOfType<NewOrder>();

        if (cupSize == order.sodaSize)
            result++;
        if (sodaBrand == order.sodaType)
            result++;

        return result;
    }

    float CalculateIngredients()
    {
        NewOrder order = FindObjectOfType<NewOrder>();
        int finalCalculation = 0;

        if (cheeseQtd == order.cheeseQtd)
            finalCalculation++;
        if (lettuceQtd == order.lettuceQtd)
            finalCalculation++;
        if (tomatoQtd == order.tomatoQtd)
            finalCalculation++;
        if (pickleQtd == order.pickleQtd)
            finalCalculation++;
        if (onionQtd == order.onionQtd)
            finalCalculation++;

        return finalCalculation;
    }


}
