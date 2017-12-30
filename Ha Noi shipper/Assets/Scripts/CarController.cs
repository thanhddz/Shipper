using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private Vector2 direction;
    public Transform top;
    public Transform bot;

    private Vector2 position;
    
    public float rotationz = 0;
    public float checkDirection = 0;
    public bool checkTurn;

    private Vector3 begin;
    private Vector3 final;
    public Vector3 mouse;
    public GameObject player;
    public GameObject sprite;
    public GameObject playerProfile;
    public GameObject gameController;
    public Transform colli;


    public float speedUp;
    public Sprite carUsing;
    public float angle;
    public Text messageText;

    public Vector3 firstTouch;

    void Start()
    {
        position = transform.position;
        direction = top.position - bot.position;
        IndexController();
    }

    void Update()
    {
        position += direction * Time.deltaTime * speedUp;
        this.transform.position = position;
        direction = top.position - bot.position;

        colli.position = this.transform.position;
        Vector3 temp = transform.rotation.eulerAngles;
        temp = this.transform.rotation.eulerAngles;
        colli.rotation = Quaternion.Euler(temp);

        DirectionController();
        MouseController();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Up();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Down();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Right();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Left();
    }

    void IndexController()
    {        
        carUsing = GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.carUsing.game;
        speedUp = GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.carUsing.speedUp;        
        angle = GameObject.FindGameObjectWithTag("playerprofile").GetComponent<PlayerProfile>().player.carUsing.rotate;
        sprite.GetComponent<SpriteRenderer>().sprite = carUsing;
    }

    void DirectionController()
    {       
        if (checkDirection == 0)
        {
                if (mouse == new Vector3(1,0,0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnRight0());
                    
                }
                if (mouse == new Vector3(-1, 0, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnLeft0());
                    
                }            
        }

        if (checkDirection == 1)
        {
                if (mouse == new Vector3(0, 1, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnUp1());
                    
                }
                if (mouse == new Vector3(0, -1, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnDown1());
                    
                }
        }

        if (checkDirection == 2)
        {
                if (mouse == new Vector3(1, 0, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnRight2());
                                      
                }
                if (mouse == new Vector3(-1, 0, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnLeft2());
                                      
                }
        }

        if (checkDirection == 3)
        {
                if (mouse == new Vector3(0, 1, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnUp3());
                                       
                }
                if (mouse == new Vector3(0, -1, 0))
                {
                    checkDirection = -1;
                    StartCoroutine(TurnDown3());                                       
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
         if(collision.tag == "map")
         {
            gameController.GetComponent<GameController>().gameOver = true;
            messageText.text = "Phá đường phá xóm";
         }

        if (collision.tag == "police")
        {
            gameController.GetComponent<GameController>().gameOver = true;
            messageText.text = "Lên đồn trình bày";
        }

        if (collision.tag == "spirit")
        {
            gameController.GetComponent<GameController>().gameOver = true;
            messageText.text = "đâm vỡ đầu ô tô";
        }

        if ((collision.tag == "stoplight2" && checkDirection == 2) || (collision.tag == "stoplight0" && checkDirection == 0)
            || (collision.tag == "stoplight1" && checkDirection == 1) || (collision.tag == "stoplight3" && checkDirection == 3)|| collision.tag == "policepoint")
        {
            gameController.GetComponent<GameController>().paidGold++;
        }
    }

    public void Up()
    {
        mouse = new Vector3(0, 1, 0);
    }

    public void Down()
    {
        mouse = new Vector3(0, -1, 0);
    }

    public void Left()
    {
        mouse = new Vector3(-1, 0, 0);
    }

    public void Right()
    {
        mouse = new Vector3(1, 0, 0);
    }

    public void MouseController()
    {
        if (Input.GetMouseButtonDown(0))
            firstTouch = Input.mousePosition;
        if (Input.GetMouseButtonUp(0))
        {
            mouse = Input.mousePosition - firstTouch;
        }
        if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x) && mouse.y > 0)
        {
            mouse = new Vector3(0, 1, 0);
        }
        if (Mathf.Abs(mouse.y) > Mathf.Abs(mouse.x) && mouse.y < 0)
        {
            mouse = new Vector3(0, -1, 0);
        }
        if (Mathf.Abs(mouse.y) < Mathf.Abs(mouse.x) && mouse.x > 0)
        {
            mouse = new Vector3(1, 0, 0);
        }
        if (Mathf.Abs(mouse.y) < Mathf.Abs(mouse.x) && mouse.x < 0)
        {
            mouse = new Vector3(-1, 0, 0);
        }
    }
}
