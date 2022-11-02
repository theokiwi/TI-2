using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    enum PlayerPos { Left, Right, Middle };

    PlayerPos currentPos;

    private Vector3 jump;
    public float jumpForce = 0.5f;
    Rigidbody rb;
    public float groundPos;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    bool canMove = true;

    static public int health = 2;
    static public int sanity = 15;
    static public int mirror = 0;

    public bool isGrounded()
    {
        if (transform.position.y <= groundPos)
            return true;
        else
            return false;
    }


    void Start()
    {
        currentPos = PlayerPos.Middle;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        groundPos = transform.position.y;
        InvokeRepeating("LooseSanity", 1.0f, 5.0f);


    }

    void Update()
    {
        /*if (GameManager.Instance.CurrentGameState() == GameManager.GameState.Jogando)
        {*/
        
            if (Input.touchCount > 0)
            {
                theTouch = Input.GetTouch(0);
                if (theTouch.phase == TouchPhase.Began)
                {
                    touchStartPosition = theTouch.position;
                }
                else if (theTouch.phase == TouchPhase.Moved ||
                    theTouch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = theTouch.position;
                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x < 0 && currentPos != PlayerPos.Left && canMove)
                        {
                            if (currentPos == PlayerPos.Right)
                            {
                                this.gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
                                currentPos = PlayerPos.Middle;
                            }
                            else
                            {
                                this.gameObject.transform.position = new Vector3(-2, transform.position.y, transform.position.z);
                                currentPos = PlayerPos.Left;
                            }
                            canMove = false;
                        }
                        
                        else if(y < 0 && canMove &&isGrounded)
                    {

                    }
                        else if (x > 0 && currentPos != PlayerPos.Right && canMove)
                        {
                            if (currentPos == PlayerPos.Left)
                            {
                                this.gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
                                currentPos = PlayerPos.Middle;
                            }
                            else
                            {
                                this.gameObject.transform.position = new Vector3(2, transform.position.y, transform.position.z);
                                currentPos = PlayerPos.Right;
                            }
                            canMove = false;
                        }
                    }
                    else
                    {
                        if (y > 0 && isGrounded())
                        {
                            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                        }
                    }
                }
            }
        /*}*/
        if (theTouch.phase == TouchPhase.Ended)
            canMove = true;

        /*void CallMenu()
         {
          GameManager.gm.coins += coins; -> coloquei isso porque achei que era importante
         }*/
        Debug.Log(health);
        Debug.Log(sanity);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
        }

        if (other.gameObject.CompareTag("Glass"))
        {
            sanity++;
        }
    }

    void LooseSanity()
    {
            sanity--;
    }

}
