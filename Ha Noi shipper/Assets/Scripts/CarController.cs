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
    
    private float rotationz = 0;
    public int checkDirection = 0;

    private Vector3 begin;
    private Vector3 final;
    public Vector3 mouse;
    public GameObject player;

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

        TurnCar();
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
                    if (rotationz != -90)
                    {
                        rotationz += -10;
                        this.transform.Rotate(0, 0, -10);
                    }
                    if (rotationz == -90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 1;
                    }
                }
                if (mouse.x < 0)
                {
                    if (rotationz != 90)
                    {
                        rotationz += 10;
                        this.transform.Rotate(0, 0, 10);
                    }
                    if (rotationz == 90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 3;
                    }
                }
            }
        }

        if (checkDirection == 1)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x))
            {
                if (mouse.y > 0)
                {
                    if (rotationz != 90)
                    {
                        rotationz += 10;
                        this.transform.Rotate(0, 0, 10);
                    }
                    if (rotationz == 90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 0;
                    }
                }
                if (mouse.y < 0)
                {
                    if (rotationz != -90)
                    {
                        rotationz += -10;
                        this.transform.Rotate(0, 0, -10);
                    }
                    if (rotationz == -90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 2;
                    }
                }
            }
        }

        if (checkDirection == 2)
        {
            if (Mathf.Abs(mouse.x) > Mathf.Abs(mouse.y))
            {
                if (mouse.x > 0)
                {
                    if (rotationz != 90)
                    {
                        rotationz += 10;
                        this.transform.Rotate(0, 0, 10);
                    }
                    if (rotationz == 90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 1;
                    }
                }
                if (mouse.x < 0)
                {
                    if (rotationz != -90)
                    {
                        rotationz += -10;
                        this.transform.Rotate(0, 0, -10);
                    }
                    if (rotationz == -90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 3;
                    }
                }
            }
        }

        if (checkDirection == 3)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x))
            {
                if (mouse.y > 0)
                {
                    if (rotationz != -90)
                    {
                        rotationz += -10;
                        this.transform.Rotate(0, 0, -10);
                    }
                    if (rotationz == -90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 0;
                    }
                }
                if (mouse.y < 0)
                {
                    if (rotationz != 90)
                    {
                        rotationz += 10;
                        this.transform.Rotate(0, 0, 10);
                    }
                    if (rotationz == 90)
                    {
                        rotationz = 0;
                        mouse = new Vector3(0, 0, 0);
                        checkDirection = 2;
                    }
                }
            }
        }
    }

    void TurnCar()
    {
        if (checkDirection == 0 || checkDirection == 1 || checkDirection == 3)
        {
            //turn right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (rotationz > -60)
                {
                    rotationz += -5;
                    this.transform.Rotate(0, 0, -5);
                }
                speech = 8;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.transform.Rotate(0, 0, -rotationz);
                rotationz = 0;
                speech = 5;
            }

            //turn left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rotationz < 60)
                {
                    rotationz += 5;
                    this.transform.Rotate(0, 0, 5);
                }
                speech = 8;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                this.transform.Rotate(0, 0, -rotationz);
                rotationz = 0;
                speech = 5;
            }
        }

        if (checkDirection == 2)
        {
            //turn left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (rotationz > -60)
                {
                    rotationz += -5;
                    this.transform.Rotate(0, 0, -5);
                }
                speech = 8;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                this.transform.Rotate(0, 0, -rotationz);
                rotationz = 0;
                speech = 5;
            }

            //turn right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (rotationz < 60)
                {
                    rotationz += 5;
                    this.transform.Rotate(0, 0, 5);
                }
                speech = 8;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.transform.Rotate(0, 0, -rotationz);
                rotationz = 0;
                speech = 5;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "map")
        {
            print("abc");
        }
        print("ab");
    }
}
