using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour {

    public CarIndex[] car;
    public CarIndex disPlayCar;
    public Text textBuy;

    public GameObject carDisplay;

    public int i = 0;

    void Start () {

    }
	
	void Update () {
        Display();
        for(int j = 0; j < 3; j++)
        {
            car[j] = GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().car[j];
        }

        if (car[i].checkUse == true)
        {
            for (int j = 0; j < 3; j++)
                if (j != i)
                    GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().car[j].checkUse = false;
        }                            
    }

    public void Display()
    {
        if (i < 0)
            i = 2;
        if (i > 2)
            i = 0;
        disPlayCar = car[i];

        if (GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.gold < car[i].price && car[i].checkBuy == false)
            carDisplay.GetComponent<SpriteRenderer>().color = Color.black;
        else carDisplay.GetComponent<SpriteRenderer>().color = Color.white;

        if (car[i].checkBuy == false)
        {
            textBuy.text = "buy";
        }

        if (car[i].checkBuy == true)
        {
            if (car[i].checkUse == false)
                textBuy.text = "use";
            if (car[i].checkUse == true)
                textBuy.text = "used";
        }
    }

    public void BuyButton()
    {
        if (car[i].checkBuy == true)
        {
            GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().car[i].checkUse = true;                                                  
        }
        if (car[i].checkBuy == false)
        {
            if(GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.gold >= car[i].price)
            {
                GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().car[i].checkBuy = true;
                GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.gold -= car[i].price;
            }           
        }
    }
}
