using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarBot : MonoBehaviour
{
    public float speed;
    public int checkDirection;
    public Vector2 triggerPosition;

    public Vector3 direction;
    public Transform bot;
    public Transform top;
    public float angle;
    public bool checkTurn = false;  

    public bool checkPolice = false;

    private void Start()
    {
        speed = 4.5f;
        angle = 3;  
        if (this.transform.localPosition.z == 1)
            checkPolice = true;
    }
    private void Update()
    {    
        direction = top.position - bot.position;
        this.transform.position += direction * Time.deltaTime * speed;  
        CheckDirection();
    }

    void CheckDirection()
    {
        if (direction.x > 0.3 && direction.y > -0.0001 && direction.y< 0.0001)
            checkDirection = 1;
        else if (direction.x < -0.3 && direction.y > -0.0001 && direction.y < 0.0001)
            checkDirection = 3;
        else if (direction.y > 0.3 && direction.x > -0.0001 && direction.x < 0.0001)
            checkDirection = 0;
        else if (direction.y < -0.3 && direction.x > -0.0001 && direction.x < 0.0001)
            checkDirection = 2;
        else checkDirection = -1;
    }

    IEnumerator TurnLeft0()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t < 1 || t > 359)
        {
            t = 0;
        }
        while (t < 89)
        {            
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnRight0()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t < 1 || t > 359)
        {
            t = 360;
        }
        while (t > 271)
        {            
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnRight2()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t > 179 && t < 181)
        {
            t = 180;
        }

        while (t < 269)
        {
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnLeft2()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t > 179 && t < 181)
        {
            t = 180;
        }

        while (t > 91)
        {
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnUp1()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t > 269 && t < 271)
        {
            t = 270;
        }

        while (t < 359)
        {
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnDown1()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t > 269 && t < 271)
        {
            t = 270;
        }

        while (t > 181)
        {
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnUp3()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t > 89 && t < 91)
        {
            t = 90;
        }

        while (t > 1)
        {
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnDown3()
    {
        checkTurn = true;
        StartCoroutine(ResetCheckTurn());
        float t = transform.localEulerAngles.z;
        if (t > 89 && t < 91)
        {
            t = 90;
        }

        while (t < 179)
        {
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    } 

    IEnumerator ResetCheckTurn()
    {
        yield return new WaitForSeconds(3);
        checkTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if(checkPolice == false)
        {
            if (collision.tag == "3" && checkTurn == false)
            {
                if (checkDirection == 1)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnDown1());
                if (checkDirection == 3)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnDown3());
            }

            if (collision.tag == "1" && checkTurn == false)
            {
                if (checkDirection == 1)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnUp1());
                if (checkDirection == 3)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnUp3());
            }

            if (collision.tag == "2" && checkTurn == false)
            {
                if (checkDirection == 0)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnRight0());
                if (checkDirection == 2)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnRight2());
            }

            if (collision.tag == "0" && checkTurn == false)
            {
                if (checkDirection == 0)
                    if (Random.Range(0, 2) == 0)
                        StartCoroutine(TurnLeft0());
                if (checkDirection == 2)
                    if (Random.Range(0, 2   ) == 0)
                        StartCoroutine(TurnLeft2());
            }

            if (collision.tag == "3'" && checkTurn == false)
            {
                if (checkDirection == 1)
                    StartCoroutine(TurnDown1());
                if (checkDirection == 3)
                    StartCoroutine(TurnDown3());
            }

            if (collision.tag == "2'" && checkTurn == false)
            {
                if (checkDirection == 0)
                    StartCoroutine(TurnRight0());
                if (checkDirection == 2)
                    StartCoroutine(TurnRight2());
            }

            if (collision.tag == "0'" && checkTurn == false)
            {
                if (checkDirection == 0)
                    StartCoroutine(TurnLeft0());
                if (checkDirection == 2)
                    StartCoroutine(TurnLeft2());
            }

            if (collision.tag == "1'" && checkTurn == false)
            {
                if (checkDirection == 1)
                    StartCoroutine(TurnUp1());
                if (checkDirection == 3)
                    StartCoroutine(TurnUp3());
            }
        }
        else
        {
            if (collision.tag == "3_police" && checkTurn == false)
            {
                if (checkDirection == 1)
                    StartCoroutine(TurnDown1());
                if (checkDirection == 3)
                    StartCoroutine(TurnDown3());
            }

            if (collision.tag == "2_police" && checkTurn == false)
            {
                if (checkDirection == 0)
                    StartCoroutine(TurnRight0());
                if (checkDirection == 2)
                    StartCoroutine(TurnRight2());
            }

            if (collision.tag == "0_police" && checkTurn == false)
            {
                if (checkDirection == 0)
                    StartCoroutine(TurnLeft0());
                if (checkDirection == 2)
                    StartCoroutine(TurnLeft2());
            }

            if (collision.tag == "1_police" && checkTurn == false)
            {
                if (checkDirection == 1)
                    StartCoroutine(TurnUp1());
                if (checkDirection == 3)
                    StartCoroutine(TurnUp3());
            }
        }
    }
}
