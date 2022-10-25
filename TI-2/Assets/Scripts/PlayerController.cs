using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    enum PlayerPos { Left, Right, Middle };

    PlayerPos currentPos;

    public Slider sanitySlider;

    private Vector3 jump;
    public float jumpForce = 0.5f;
    Rigidbody rb;
    public float groundPos;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    bool canMove = true;

    int health = 3;
    int sanity = 20;

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
    }

    void Update()
    {
        Invoke("LooseSanity", 10);
        Debug.Log(sanity);
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

        void OnCollisionEnter(Collision col)
        {

            if (col.gameObject.CompareTag("Pill"))
            {
                sanity++;
            }
            else if (col.gameObject.CompareTag("Enemy"))
            {
                health--;
            }
            else if (col.gameObject.CompareTag("Heal"))
            {
                health++;
            }

        }
    }


    public void LooseSanity()
    {
        sanity--;
    }


}
