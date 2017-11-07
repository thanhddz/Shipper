using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfile : MonoBehaviour {

    public PlayerIndex player;
    public Sprite[] playCar;

	void Start () {
        this.GetComponent<SpriteRenderer>().sprite = player.prefab;
    }	
	void Update () {        
	}
}
