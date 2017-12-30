using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text playerGoldDisplay;
    public Text highScore;
    public Text score;

    public GameObject carController;
    public GameObject gameMenu;
    public bool gameOver;

    public int paidGold = 0;

    void Start () {
        Time.timeScale = 1;
        gameOver = false;
        GameObject.FindGameObjectWithTag("admobmanage").GetComponent<GoogleAdmobView>().OnDisableBaner();

    }
	
	void Update () {
        playerGoldDisplay.text = "" + paidGold;
        score.text = "" + paidGold;
        highScore.text = "" + PlayerPrefs.GetInt("highscore");
        if (gameOver == true)
        {
            if (Random.Range(0, 4) == 1)
                GameObject.FindGameObjectWithTag("admobmanage").GetComponent<GoogleAdmobView>().ShowInterstitialAds();
            if (paidGold > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", paidGold);
            }
            StartCoroutine(GameMenuDown());
            Time.timeScale = 0;
            GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.gold += paidGold;
            GameObject.FindGameObjectWithTag("admobmanage").GetComponent<GoogleAdmobView>().RequestBanner();
        }
    }

    IEnumerator GameMenuDown()
    {
        gameOver = false;
        while(gameMenu.transform.localPosition.y > 0)
        {
            gameMenu.transform.localPosition -= new Vector3(0, 8, 0);
            yield return null;
        }     
    }


}
