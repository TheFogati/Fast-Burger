using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewOrder : MonoBehaviour
{
    [Header("Burger")]
    public Text lettuceTxt;
    public Text cheeseTxt;
    public Text tomatoTxt;
    public Text pickleTxt;
    public Text onionTxt;
    [Space]
    public int lettuceQtd;
    public int cheeseQtd;
    public int tomatoQtd;
    public int pickleQtd;
    public int onionQtd;

    [Header("Fries")]
    public ToggleGroup doesItHave;
    public bool hasFries;

    [Header("Soda")]
    public ToggleGroup whichSize;
    public Image showImage;
    public Sprite[] sodasImages;
    [Space]
    [Range(0, 2)]public int sodaType;
    [Range(0, 2)]public int sodaSize;

    Vector3 newOrder = new Vector3(300, 460, 0);
    Vector3 discart = new Vector3(-630, 460, 0);

    public bool done;
    public bool prepare;

    void Start()
    {
        lettuceQtd = Random.Range(0, 3);
        cheeseQtd = Random.Range(1, 3);
        tomatoQtd = Random.Range(0, 3);
        pickleQtd = Random.Range(0, 3);
        onionQtd = Random.Range(0, 3);

        int rndFries = Random.Range(0, 2);
        if (rndFries == 0)
            hasFries = false;
        else
            hasFries = true;

        sodaType = Random.Range(0, 3);
        sodaSize = Random.Range(0, 3);

    }

    void Update()
    {
        BurgerIngredients();
        HasFries();
        WhichSoda();

        Vector3 velocity = Vector3.zero;
        if(!done)
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, newOrder, ref velocity, Time.deltaTime);
        else
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, discart, ref velocity, Time.deltaTime);

        if (Vector3.Distance(transform.position, discart) <= .5f)
        {
            Destroy(gameObject);
        }
            
    }

    void BurgerIngredients()
    {
        lettuceTxt.text = "x" + lettuceQtd.ToString();
        cheeseTxt.text = "x" + cheeseQtd.ToString();
        tomatoTxt.text = "x" + tomatoQtd.ToString();
        pickleTxt.text = "x" + pickleQtd.ToString();
        onionTxt.text = "x" + onionQtd.ToString();
    }

    void HasFries()
    {
        Toggle[] toggles = doesItHave.GetComponentsInChildren<Toggle>();

        if (hasFries)
            toggles[0].isOn = true;
        else
            toggles[1].isOn = true;
    }

    void WhichSoda()
    {
        Toggle[] toggles = whichSize.GetComponentsInChildren<Toggle>();

        showImage.sprite = sodasImages[sodaType];
        toggles[sodaSize].isOn = true;

    }

    void MakeMeASandwich()
    {
        CamManager.manager.SetCooking();
        prepare = true;
    }
}
