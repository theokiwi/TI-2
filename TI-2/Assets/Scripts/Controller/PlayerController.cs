using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    enum PlayerPos { Left, Right, Middle };

    PlayerPos currentPos;

    public Animator animar;

    private Vector3 jump;
    public float jumpForce = 2f;
    public bool canJump = false;
    Rigidbody rb;
    public float groundPos;
    bool powerUp = false;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    private Touch cheat;
    public string cena;

    bool canMove = true;

    static public int health = 1;
    static public int sanity = 15;
    static public int mirror = 0;
    public BoxCollider boxCollider;

    public bool isGrounded()
    {
        if (transform.position.y <= groundPos)
        {
            print("grounded");
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        currentPos = PlayerPos.Middle;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        groundPos = transform.position.y;
        InvokeRepeating("LooseSanity", 1.0f, 5.0f);
        animar = GetComponent<Animator>();
    }

    void Update()
    {
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
                            this.gameObject.transform.position = new Vector3(-3, transform.position.y, transform.position.z);
                            currentPos = PlayerPos.Left;
                        }
                        canMove = false;
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
                            this.gameObject.transform.position = new Vector3(3, transform.position.y, transform.position.z);
                            currentPos = PlayerPos.Right;
                        }
                        canMove = false;
                    }
                }
                else
                {
                    if (y > 0 && isGrounded())
                    {
                        Debug.Log("pular");
                        rb.AddForce(jump * jumpForce, ForceMode.VelocityChange); //ForceMode.Impulse
                        canJump = false;
                        //ativar animação do pulo com is kinematic
                        animar.SetTrigger("Jump");
                        //animar.SetBool("IsJump", true);
                        //animar.SetBool("IsSlide", false);
                    }
                    else if (y < 0 && isGrounded() && canMove)
                    {
                        canMove = false;
                        Vector3 newSize = boxCollider.size;
                        Vector3 newCenter = boxCollider.center;
                        newSize.y = newSize.y / 3;
                        newCenter.y = 0.35f;
                        boxCollider.size = newSize;
                        boxCollider.center = newCenter;
                        Debug.Log("sliding");
                        Debug.Log(newSize);
                        Invoke("BoxReset", 0.5f);
                        //ativar animação do slide com is kinematic
                        animar.SetTrigger("Slide");
                        //animar.SetBool("IsSlide", true);
                        //animar.SetBool("IsJump", false);
                    }
                }
            }
        } 
        if (theTouch.phase == TouchPhase.Ended)
        canMove = true;
       
        if (powerUp == true)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        if(powerUp == false)
        {
            GetComponent<MeshRenderer>().material.color = Color.clear;
        }

        if (Input.touchCount > 5)
        {
            theTouch = Input.GetTouch(5);
            health = int.MaxValue;

        }
        if (Input.touchCount > 4)
        {
            theTouch = Input.GetTouch(4);
            SceneManager.LoadScene(cena);
        }
    }

    void BoxReset()
    {
        Vector3 newSize = boxCollider.size;
        Vector3 newCenter = boxCollider.center;
        newCenter.y = 1.055571f;
        newSize.y = newSize.y * 3;
        boxCollider.size = newSize;
        boxCollider.center = newCenter;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health--;
            animar.SetTrigger("IsDead");
        }

        if (other.gameObject.CompareTag("Glass"))
        {
            sanity = sanity + 2;
        }

        if (other.gameObject.CompareTag("Bird"))
        {
            powerUp = true;
            other.GetComponent<BoxCollider>().enabled = false;
            Invoke("PowerUpDisable", 0.5f);
        }
    }

    void PowerUpDisable()
    {
        GetComponent<BoxCollider>().enabled = true;
        powerUp = false;
    }
   
    void LooseSanity()
    {
            sanity--;
    }
}
