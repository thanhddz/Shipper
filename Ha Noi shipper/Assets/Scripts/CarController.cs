using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector2 direction;
    public Transform top;
    public Transform bot;

    private Vector2 position;
    public float speech;
    
    public float rotationz = 0;
    public int checkDirection = 0;

    private Vector3 begin;
    private Vector3 final;
    public Vector3 mouse;
    public GameObject player;

    public float angle;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerProfile>().player.prefab;
        position = transform.position;
        direction = top.position - bot.position;
    }

    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerProfile>().player.prefab;
        position += direction * Time.deltaTime * speech;
        this.transform.position = position;
        direction = top.position - bot.position;
        if(Input.GetKeyDown(KeyCode.Space))
            print(transform.localEulerAngles);
        //TurnCar();
        DirectionController();           
    }

    void DirectionController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            begin = Input.mousePosition;
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            final = Input.mousePosition;
            mouse = final - begin;
        }

        if (checkDirection == 0)
        {
            if (Mathf.Abs(mouse.x) > Mathf.Abs(mouse.y))
            {
                if (mouse.x > 0)
                {
                    StopCoroutine(TurnUp1());
                    StartCoroutine(TurnRight0());
                    checkDirection = 1;
                }
                if (mouse.x < 0)
                {
                    StopCoroutine(TurnUp3());
                    StartCoroutine(TurnLeft0());
                    checkDirection = 3;
                }
            }
        }

        if (checkDirection == 1)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x))
            {
                if (mouse.y > 0)
                {
                    StopCoroutine(TurnRight0());
                    StartCoroutine(TurnUp1());
                    checkDirection = 0;
                }
                if (mouse.y < 0)
                {
                    StopCoroutine(TurnRight2());
                    StartCoroutine(TurnDown1());
                    checkDirection = 2;
                }
            }
        }

        if (checkDirection == 2)
        {
            if (Mathf.Abs(mouse.x) > Mathf.Abs(mouse.y))
            {
                if (mouse.x > 0)
                {
                    StopCoroutine(TurnDown1());
                    StartCoroutine(TurnRight2());
                    checkDirection = 1;
                    
                }
                if (mouse.x < 0)
                {
                    StopCoroutine(TurnDown3());
                    StartCoroutine(TurnLeft2());
                    checkDirection = 3;                   
                }
            }
        }

        if (checkDirection == 3)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x))
            {
                if (mouse.y > 0)
                {
                    StopCoroutine(TurnLeft0());
                    StartCoroutine(TurnUp3());
                    checkDirection = 0;
                   
                }
                if (mouse.y < 0)
                {
                    StopCoroutine(TurnLeft2());
                    StartCoroutine(TurnDown3());
                    checkDirection = 2;
                    
                }
            }
        }
    }

    IEnumerator TurnRight0()
    {
        float t = transform.localEulerAngles.z;
        
        while(t > -90)
        {
            t -= 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3( 0, 0, t);
            transform.rotation =  Quaternion.Euler(temp);
            yield return null;
        }
    }

    IEnumerator TurnLeft0()  
    {
        float t = transform.localEulerAngles.z;
        while (t < 90)
        {
            t += 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }

    IEnumerator TurnRight2()
    {
        float t = transform.localEulerAngles.z -360;
        while (t < -90)
        {
            t += 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }

    IEnumerator TurnLeft2()
    {
        float t = transform.localEulerAngles.z;
        while (t > 90)
        {
            t -= 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }

    IEnumerator TurnUp1()
    {
        float t = transform.localEulerAngles.z - 360;
        while (t < 0)
        {
            t += 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }

    IEnumerator TurnDown1()
    {
        float t = transform.localEulerAngles.z - 360;
        while (t > -180)
        {
            t -= 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }
    IEnumerator TurnUp3()
    {
        float t = transform.localEulerAngles.z;
        while (t > 0)
        {
            t -= 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }

    IEnumerator TurnDown3()
    {
        float t = transform.localEulerAngles.z -360;
        while (t < -180)
        {
            t += 10;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
    }

    //void TurnCar()
    //{
    //    if (checkDirection == 0 || checkDirection == 1 || checkDirection == 3)
    //    {
    //        //turn right
    //        if (Input.GetKey(KeyCode.RightArrow))
    //        {
    //            if (rotationz > -60)
    //            {
    //                rotationz += -5;
    //                this.transform.Rotate(0, 0, -5);
    //            }
    //            speech = 8;
    //        }
    //        if (Input.GetKeyUp(KeyCode.RightArrow))
    //        {
    //            this.transform.Rotate(0, 0, -rotationz);
    //            rotationz = 0;
    //            speech = 5;
    //        }

    //        //turn left
    //        if (Input.GetKey(KeyCode.LeftArrow))
    //        {
    //            if (rotationz < 60)
    //            {
    //                rotationz += 5;
    //                this.transform.Rotate(0, 0, 5);
    //            }
    //            speech = 8;
    //        }
    //        if (Input.GetKeyUp(KeyCode.LeftArrow))
    //        {
    //            this.transform.Rotate(0, 0, -rotationz);
    //            rotationz = 0;
    //            speech = 5;
    //        }
    //    }

    //    if (checkDirection == 2)
    //    {
    //        //turn left
    //        if (Input.GetKey(KeyCode.LeftArrow))
    //        {
    //            if (rotationz > -60)
    //            {
    //                rotationz += -5;
    //                this.transform.Rotate(0, 0, -5);
    //            }
    //            speech = 8;
    //        }
    //        if (Input.GetKeyUp(KeyCode.LeftArrow))
    //        {
    //            this.transform.Rotate(0, 0, -rotationz);
    //            rotationz = 0;
    //            speech = 5;
    //        }

    //        //turn right
    //        if (Input.GetKey(KeyCode.RightArrow))
    //        {
    //            if (rotationz < 60)
    //            {
    //                rotationz += 5;
    //                this.transform.Rotate(0, 0, 5);
    //            }
    //            speech = 8;
    //        }
    //        if (Input.GetKeyUp(KeyCode.RightArrow))
    //        {
    //            this.transform.Rotate(0, 0, -rotationz);
    //            rotationz = 0;
    //            speech = 5;
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "map")
        {
            print("abc");
        }
        print("ab");
    }
}
