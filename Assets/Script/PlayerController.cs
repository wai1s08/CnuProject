using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("玩家速度")]
    public float runSpeed;

    [Header("跳躍力道")]
    public float jumpspeed;
    public float doulbJumpSpeed;

    [Header("爬梯子速度")]
    public float climbSpeed;

    [Header("單向平台恢復速住")]
    public float restoreTime;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    

    public GameObject MyBag;
    public static bool isOpen;

    private bool IsPortal, isLadder, isClimbing, isJumping, isOneWayPlatform;

    private float playerGravity;


    public bool isGround , isJump, isFall;
    public Transform groundCheck;
    public LayerMask ground;

    bool jumpPressed;
    int jumpCount;




    // Start is called before the first frame update
    void Start()
    {
        // 遊戲開始後取得組件
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        playerGravity = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }

        CheckAirStatus(); 
        Climb();
        checkGround();
        CheckLadder();
        OpenMyBag();
        Portal();

        //Defense();

        OneWayPlatformCheck();

        Debug.Log(isGround);
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);

        Run();
        Jump();
        Flip();
        switchAnim();
    }

    void checkGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }

    void CheckLadder()
    {
        isLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
        //Debug.Log("isLadder:" + isLadder);
    }

    void Run()
    {
        if (PlayerState.IsDefense == false && !isOpen )
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            myRigidbody.velocity = new Vector2(horizontalMove * runSpeed, myRigidbody.velocity.y);
        }
        else
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            myRigidbody.velocity = new Vector2(horizontalMove * 0, myRigidbody.velocity.y);

        }

    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }

        if(jumpPressed && isGround )
        {
            SoundManager.PlayJump_sound();
            isJump = true;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpspeed);
            jumpCount--;
            jumpPressed = false;
        }
        else if(jumpPressed && jumpCount > 0 && isJump )
        {
            SoundManager.PlayJump_sound();
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpspeed);
            jumpCount--;
            jumpPressed = false;
        }
    }

    void switchAnim()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        myAnim.SetBool("Run", playerHasXAxisSpeed);

        if (isGround)
        {
            myAnim.SetBool("Jump", false);
            myAnim.SetBool("Fall", false);
        }
        else if(!isGround && myRigidbody.velocity.y > 0 && !isLadder)
        {
            myAnim.SetBool("Jump", true);
        }
        else if(myRigidbody.velocity.y < 0 && !isLadder) 
        {
            myAnim.SetBool("Jump", false);
            myAnim.SetBool("Fall", true);
        }
    }

    void Climb()
    {
        float moveY = Input.GetAxis("Vertical");

        if (isClimbing)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
        }

        if (isLadder)
        {
            if (moveY > 0.5f || moveY < -0.5f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Climb", true);
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
                myRigidbody.gravityScale = 0.0f;
                myAnim.enabled = true;
            }
            else
            {
                if (isJumping || isFall)
                {
                    myAnim.SetBool("Climb", false);
                    myRigidbody.gravityScale = playerGravity;
                }
                else
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);
                    if(myRigidbody.velocity.x == 0.0f && isClimbing)
                    {
                        myAnim.enabled = false;
                    }
                    else
                    {
                        myAnim.enabled = true;
                    }

                }
            }
        }
        else
        {
            myAnim.SetBool("Climb", false);
            myRigidbody.gravityScale = playerGravity;
        }

        if (isLadder && isGround)
        {
            myRigidbody.gravityScale = playerGravity;
            myAnim.SetBool("Climb", false);
        }
    }

    void CheckAirStatus()
    {
        isJumping = myAnim.GetBool("Jump");
        isFall = myAnim.GetBool("Fall");

        isClimbing = myAnim.GetBool("Climb");
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            MyBag.SetActive(isOpen);
            myAnim.SetBool("Run", false);
        }
    }

    void Portal()
    {
        //Debug.Log(IsPortal);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) )
        {
            IsPortal = true;
        }
        else
        {
            IsPortal = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal") && IsPortal == true)
        {
            collision.gameObject.transform.GetComponent<Portal>().ChangeScene();
        }
    }

    void OneWayPlatformCheck()
    {
        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
   

        float moveY = Input.GetAxis("Vertical");
        //Debug.Log(moveY);
        if (isOneWayPlatform && moveY < -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");

            Invoke("RestorePlayerLayer", restoreTime);
        }


    }

    void RestorePlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }


}
