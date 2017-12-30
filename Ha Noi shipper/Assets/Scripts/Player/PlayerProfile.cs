using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour {

    public PlayerIndex player;
    public static PlayerProfile Instance;
    public CarIndex[] car;
    private int[] checkBuySave = new int[4];
    private int[] checkUseSave = new int[4];
    private float x = 0;
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        if (PlayerPrefs.GetFloat("3") == 0)
        {            
            player.carUsing = car[0];
            PlayerPrefs.SetInt("goldplayer", 600);
            PlayerPrefs.SetInt("checkusecar0", 1);
            PlayerPrefs.SetInt("checkbuycar0", 1);
            PlayerPrefs.SetInt("checkbuycar1", 0);
            PlayerPrefs.SetInt("checkbuycar2", 0);
            x += 1;
            PlayerPrefs.SetFloat("3", x);
            print("a");
        }
        LoadData();
        //PlayerPrefs.SetFloat("2", 0);
    }	
	void Update () {
        SaveData();
        for(int j = 0; j < 3; j++)
        {
            if (car[j].checkUse == true)
                {
                    player.carUsing = car[j];
                }               
        }
    }

    public void SaveData()
    {       
        for (int j = 0; j < 3; j++)
        {
            if (car[j].checkBuy == true)
                checkBuySave[j] = 1;
            else checkBuySave[j] = 0;

            if (car[j].checkUse == true)
                checkUseSave[j] = 1;
            else checkUseSave[j] = 0;
        }

        PlayerPrefs.SetInt("goldplayer", player.gold);

        PlayerPrefs.SetInt("checkusecar0", checkUseSave[0]);
        PlayerPrefs.SetInt("checkusecar1", checkUseSave[1]);
        PlayerPrefs.SetInt("checkusecar2", checkUseSave[2]);

        PlayerPrefs.SetInt("checkbuycar0", checkBuySave[0]);
        PlayerPrefs.SetInt("checkbuycar1", checkBuySave[1]);
        PlayerPrefs.SetInt("checkbuycar2", checkBuySave[2]);
    }

    public void LoadData()
    {
        if (PlayerPrefs.GetInt("checkusecar0") == 1)
            car[0].checkUse = true;
        else
            car[0].checkUse = false;

        if (PlayerPrefs.GetInt("checkusecar1") == 1)
            car[1].checkUse = true;
        else
            car[1].checkUse = false;

        if (PlayerPrefs.GetInt("checkusecar2") == 1)
            car[2].checkUse = true;
        else
            car[2].checkUse = false;

        if (PlayerPrefs.GetInt("checkbuycar0") == 1)
            car[0].checkBuy = true;
        else
            car[0].checkBuy = false;

        if (PlayerPrefs.GetInt("checkbuycar1") == 1)
            car[1].checkBuy = true;
        else
            car[1].checkBuy = false;

        if (PlayerPrefs.GetInt("checkbuycar2") == 1)
            car[2].checkBuy = true;
        else
            car[2].checkBuy = false;

        player.gold = PlayerPrefs.GetInt("goldplayer");
    }
}
