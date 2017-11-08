using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed;

    public GameObject carController;

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;

        if (carController.GetComponent<CarController>().checkDirection == 0)
        {
            offset = new Vector3(0, 3, -10);
            
        }
            
        if (carController.GetComponent<CarController>().checkDirection == 2)
        {
            offset = new Vector3(0, -3, -10);
        }

        if (carController.GetComponent<CarController>().checkDirection == 1 || carController.GetComponent<CarController>().checkDirection == 3)
        {
            offset = new Vector3(0, 0, -10);
        }

        if (transform.position == desiredPosition)
            transform.position = target.position + offset;
        else transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
