using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private int speed = 5;

	void Start () {
        Time.timeScale = 1;
	}
	
	void Update () {
        this.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        if (this.transform.position.x >= 14)
            this.transform.position = new Vector3(-15, this.transform.position.y, 0);
    }
}
