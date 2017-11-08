using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour {

    public PlayerIndex player;

    public Sprite[] carOfPlayer;

    void Start () {
        player.prefab = carOfPlayer[0];       
    }	
	void Update () {        

	}
}
