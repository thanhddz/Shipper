using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceHuman : MonoBehaviour {

    public GameObject player;
    public GameObject normal;
    public GameObject annimation;
    public GameObject policePoint;
    public int a;
    public int count = 0;

	// Use this for initialization
	void Start () {
        normal.SetActive(true);
        annimation.SetActive(false);
        policePoint.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Police();
	}

    private void Police()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 20 && count == 0)
        {
            count++;
            a = Random.Range(0, 2);
        }
        if (Vector3.Distance(this.transform.position, player.transform.position) > 20)
        {
            count = 0;
            normal.SetActive(true);
            annimation.SetActive(false);
            policePoint.SetActive(false);
        }
            
        if (Vector3.Distance(this.transform.position, player.transform.position) < 20 
             && a == 0)
        {
            normal.SetActive(false);
            annimation.SetActive(true);
            policePoint.SetActive(true);
        }
    }
}