using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour {

    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    public bool checkRed;
    public bool checkYellow;
    public bool checkGreen;

    void Start () {
        if (transform.localPosition.x == 1)
        {
            checkGreen = true;
            checkYellow = false;
            checkRed = false;
            StartCoroutine(A());
        }

        if (transform.localPosition.x == 0)
        {
            checkGreen = false;
            checkYellow = false;
            checkRed = true;
            StartCoroutine(B());
        }
    }

    void Update () {
        Light();
	}

    IEnumerator Green()
    {
        yield return new WaitForSeconds(3);
        checkGreen = false;
        checkYellow = true;
    }

    IEnumerator Yellow()
    {
        yield return new WaitForSeconds(1.5f);
        checkYellow = false;
        checkRed = true;
    }

    IEnumerator Red()
    {
        yield return new WaitForSeconds(4.5f);
        checkRed = false;
        checkGreen = true;
    }

    IEnumerator A()
    {
        while (true)
        {
            yield return StartCoroutine(Green());
            yield return StartCoroutine(Yellow());
            yield return StartCoroutine(Red());
        }      
    }

    IEnumerator B()
    {
        while (true)
        {
            yield return StartCoroutine(Red());
            yield return StartCoroutine(Green());
            yield return StartCoroutine(Yellow());            
        }
    }

    private void Light()
    {
        if (checkGreen == true)
            greenLight.SetActive(true);
        else greenLight.SetActive(false);

        if (checkYellow == true)
            yellowLight.SetActive(true);
        else yellowLight.SetActive(false);

        if (checkRed == true)
            redLight.SetActive(true);
        else redLight.SetActive(false);
    }
}
