using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStop : MonoBehaviour {

    public GameObject car;
    public int checkDirection;
    public Vector2 vectorDistance;
    public GameObject sensorCar;

	void Update () {
        this.transform.position = car.transform.position;
        //di chuyen theo vi tri
        checkDirection = car.GetComponent<MoveCarBot>().checkDirection;
        // quay theo vi tri
        Vector3 temp = transform.rotation.eulerAngles;
        temp = car.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(temp);
    }
}
