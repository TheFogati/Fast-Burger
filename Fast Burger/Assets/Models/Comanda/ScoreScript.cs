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


    NewOrder order;
    static bool checkOrder;

    void Start()
    {
        
    }

    void Update()
    {
        print("Patty Side Up = " + pattySide1 + "; Patty Side Down = " + pattySide2);
        print("Cheese = " + cheeseQtd + "; Lettuce = " + lettuceQtd + "; Tomato = " + tomatoQtd + "; Onion = " + onionQtd + "; Pickle = " + pickleQtd);
        if (hasFries) { print("Fries frieness = " + friesFrieness); } else { print("No Fries"); }
        print("Cup size = " + cupSize + "; Brand = " + sodaBrand + "; Filling = " + sodaFilling);
        

        if(order)
        {
            if (checkOrder)
            {
                //Check Order
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
            3 - Onion
            4 - Pickle
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
                onionQtd++;
                break;
            case 4:
                pickleQtd++;
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

        checkOrder = true;
    }

    public static void ResetAll()
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
    }
}
