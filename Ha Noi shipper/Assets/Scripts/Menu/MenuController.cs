using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject shop;
    public GameObject startButton;
    public GameObject shopButton;
    public GameObject outShopButton;
    public GameObject car;
    public GameObject storeController;
    public GameObject indexcar;
    public GameObject playergold;
    public GameObject buyButton;
    public GameObject leftButton;
    public GameObject rightButton;

    public Text indexCar;
    public Text playerGold;

	void Start () {
		
	}

	void Update () {
        Display();
    }

    private void Display()
    {
        indexCar.text = "" + storeController.GetComponent<StoreController>().disPlayCar.nameCar + "\n"
            + "Price " + storeController.GetComponent<StoreController>().disPlayCar.price;
        car.GetComponent<SpriteRenderer>().sprite = storeController.GetComponent<StoreController>().disPlayCar.menu;
        playerGold.text = GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.gold + "";
    }

    public void OnShop()
    {
        shop.SetActive(true);
        outShopButton.SetActive(true);
        indexcar.SetActive(true);
        playergold.SetActive(true);
        buyButton.SetActive(true);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        startButton.SetActive(false);
        shopButton.SetActive(false);
    }

    public void OutShop()
    {
        shop.SetActive(false);
        outShopButton.SetActive(false);
        indexcar.SetActive(false);
        playergold.SetActive(false);
        buyButton.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        startButton.SetActive(true);
        shopButton.SetActive(true);
        if (Random.Range(0,3) == 1)
        {
            GameObject.FindGameObjectWithTag("admobmanage").GetComponent<GoogleAdmobView>().ShowInterstitialAds();
            GameObject.FindGameObjectWithTag("admobmanage").GetComponent<GoogleAdmobView>().RequestBanner();
        }
            
    }

    public void Left()
    {
        storeController.GetComponent<StoreController>().i -= 1; 
    }

    public void Right()
    {
        storeController.GetComponent<StoreController>().i += 1;
    }
}
