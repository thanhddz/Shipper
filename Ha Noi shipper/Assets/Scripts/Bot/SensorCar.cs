using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCar : MonoBehaviour {

    public GameObject car;
    public int checkDirection;
    public Vector2 vectorDistance;
    public int collisionDirection;

    void Start () {

    }
	
	void Update () {
        //di chuyen theo vi tri
        this.transform.position = car.transform.position;
        
        checkDirection = car.GetComponent<MoveCarBot>().checkDirection;

        // quay theo vi tri
        Vector3 temp = transform.rotation.eulerAngles;
        temp = car.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(temp);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "carstop" && checkDirection != collision.GetComponent<CarStop>().checkDirection)
        {
            car.GetComponent<MoveCarBot>().speed = 0;
            car.GetComponent<MoveCarBot>().angle = 0;
            collisionDirection = collision.GetComponent<CarStop>().checkDirection;
            if(checkDirection == -1 && collision.GetComponent<CarStop>().sensorCar.GetComponent<SensorCar>().collisionDirection == -1)
            {
                car.GetComponent<MoveCarBot>().speed = 4.5f;
                car.GetComponent<MoveCarBot>().angle = 3;
            }
            if(checkDirection != -1 && collision.GetComponent<CarStop>().sensorCar.GetComponent<SensorCar>().collisionDirection == checkDirection)
            {
                Vector3 dis = car.transform.position - collision.GetComponent<CarStop>().car.transform.position;
                if (Mathf.Abs(dis.x) > Mathf.Abs(dis.y))
                {
                    if(checkDirection == 0 || checkDirection == 2)
                    {
                        car.GetComponent<MoveCarBot>().speed = 4.5f;
                        car.GetComponent<MoveCarBot>().angle = 3;
                    }
                }
                if(Mathf.Abs(dis.x) < Mathf.Abs(dis.y))
                {
                    if (checkDirection == 1 || checkDirection == 3)
                    {
                        car.GetComponent<MoveCarBot>().speed = 4.5f;
                        car.GetComponent<MoveCarBot>().angle = 3;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "carstop")
        {
            car.GetComponent<MoveCarBot>().speed = 0;
            car.GetComponent<MoveCarBot>().angle = 0;
        }

        if (collision.tag == "stoplight0" && checkDirection == 0)
        {
            car.GetComponent<MoveCarBot>().speed = 0;
            car.GetComponent<MoveCarBot>().angle = 0;
        }
        if (collision.tag == "stoplight1" && checkDirection == 1)
        {
            car.GetComponent<MoveCarBot>().speed = 0;
            car.GetComponent<MoveCarBot>().angle = 0;
        }
        if (collision.tag == "stoplight2" && checkDirection == 2)
        {
            car.GetComponent<MoveCarBot>().speed = 0;
            car.GetComponent<MoveCarBot>().angle = 0;
        }
        if (collision.tag == "stoplight3" && checkDirection == 3)
        {
            car.GetComponent<MoveCarBot>().speed = 0;
            car.GetComponent<MoveCarBot>().angle = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "carstop" || collision.tag == "stoplight0"
            || collision.tag == "stoplight1" || collision.tag == "stoplight2" || collision.tag == "stoplight3")
        {
            car.GetComponent<MoveCarBot>().speed = 4.5f;
            car.GetComponent<MoveCarBot>().angle = 3;
        }
    }
}
