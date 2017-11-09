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
    public float checkDirection = 0;
    public bool checkTurn;

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

        if (Input.GetKeyDown(KeyCode.Space))
            print(transform.localEulerAngles);

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
                    checkDirection = -1;
                    StartCoroutine(TurnRight0());
                    
                }
                if (mouse.x < 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnLeft0());
                    
                }
            }
        }

        if (checkDirection == 1)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x))
            {
                if (mouse.y > 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnUp1());
                    
                }
                if (mouse.y < 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnDown1());
                    
                }
            }
        }

        if (checkDirection == 2)
        {
            if (Mathf.Abs(mouse.x) > Mathf.Abs(mouse.y))
            {
                if (mouse.x > 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnRight2());
                                      
                }
                if (mouse.x < 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnLeft2());
                                      
                }
            }
        }

        if (checkDirection == 3)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x))
            {
                if (mouse.y > 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnUp3());
                                       
                }
                if (mouse.y < 0)
                {
                    checkDirection = -1;
                    StartCoroutine(TurnDown3());                                       
                }
            }
        }
    }

    IEnumerator TurnRight0()
    {
        float t = transform.localEulerAngles.z;
        if (t < 1 || t > 359)
        {
            t = 360;
        }
 
        while (t > 271)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x) && mouse.y > 0)
            {
                checkDirection = 1;
                yield break;
            }                                        
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3( 0, 0, t);
            transform.rotation =  Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 1;
    }

    IEnumerator TurnLeft0()  
    {
        float t = transform.localEulerAngles.z;
        if (t < 1 || t > 359)
        {
            t = 0;
        }

        while (t < 89)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x) && mouse.y > 0)
            {
                checkDirection = 3;
                yield break;
            }                
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 3;
    }

    IEnumerator TurnRight2()
    {
        float t = transform.localEulerAngles.z;
        if (t > 179 && t < 181)
        {
            t = 180;
        }

        while (t < 269)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x) && mouse.y < 0)
            {
                checkDirection = 1;
                yield break;
            }                
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 1;
    }

    IEnumerator TurnLeft2()
    {
        float t = transform.localEulerAngles.z;
        if (t > 179 && t < 181)
        {
            t = 180;
        }

        while (t > 91)
        {
            if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x) && mouse.y < 0)
            {
                checkDirection = 3;
                yield break;
            }                
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 3;
    }

    IEnumerator TurnUp1()
    {
        float t = transform.localEulerAngles.z;
        if (t > 269 && t < 271)
        {
            t = 270;
        }

        while (t < 359)
        {
            if (Mathf.Abs(mouse.y) < Mathf.Abs(mouse.x) && mouse.x > 0)
            {
                checkDirection = 0;
                yield break;
            }               
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 0;
    }

    IEnumerator TurnDown1()
    {
        float t = transform.localEulerAngles.z;
        if (t > 269 && t < 271)
        {
            t = 270;
        }

        while (t > 181)
        {
            if (Mathf.Abs(mouse.y) < Mathf.Abs(mouse.x) && mouse.x > 0)
            {
                checkDirection = 2;
                yield break;
            }
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 2;
    }
    IEnumerator TurnUp3()
    {
        float t = transform.localEulerAngles.z;
        if (t > 89 && t < 91)
        {
            t = 90;
        }

        while (t > 1)
        {
            if (Mathf.Abs(mouse.y) < Mathf.Abs(mouse.x) && mouse.x < 0)
            {
                checkDirection = 0;
                yield break;                
            }              
            t -= angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 0;
    }

    IEnumerator TurnDown3()
    {
        float t = transform.localEulerAngles.z;
        if (t > 89 && t < 91)
        {
            t = 90;
        }

        while (t < 179)
        {
            if (Mathf.Abs(mouse.y) < Mathf.Abs(mouse.x) && mouse.x < 0)
            {
                checkDirection = 2;
                yield break;
            }
            t += angle;
            Vector3 temp = transform.rotation.eulerAngles;
            temp = new Vector3(0, 0, t);
            transform.rotation = Quaternion.Euler(temp);
            yield return null;
        }
        mouse = new Vector3(0, 0, 0);
        checkDirection = 2;
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
