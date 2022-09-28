using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("玩家速度")]
    public float runSpeed;

    [Header("跳躍力道")]
    public float jumpspeed;

    [Header("爬梯子速度")]
    public float climbSpeed;

    [Header("單向平台恢復速住")]
    public float restoreTime;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;

    private BoxCollider2D myFeet;
    public bool isGround;

    public GameObject MyBag;
    public static bool isOpen;
    private bool IsPortal;

    private bool isLadder;
    private bool isClimbing;
    private bool isJumping;

    private float playerGravity;

    private bool isOneWayPlatform;


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
        // 在遊戲進行當中不斷取得Run的數值

        CheckAirStatus();
        Run();
        Flip();
        Jump();
        Climb();
        checkGround();
        CheckLadder();
        OpenMyBag();
        Portal();
        //Defense();

        OneWayPlatformCheck();
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
            // Input.GetAxis是Unity內建偵測輸入的函式 | Horizontal = 水平 | 偵測玩家按的按鍵取的方向
            float moveDir = Input.GetAxis("Horizontal");

            // Vector2 = 2D向量和點的表示形式，用於表示2D位置，只有兩個軸x＆y | 將取得的方向乘上玩家的速度進行移動
            Vector2 playerVal = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);

            // 回傳結果
            myRigidbody.velocity = playerVal;

            bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

            myAnim.SetBool("Run", playerHasXAxisSpeed);
        }
        else
        {
            float moveDir = Input.GetAxis("Horizontal");
            Vector2 playerVal = new Vector2(moveDir * 0, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVal;

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
        if (Input.GetButtonDown("Jump") && isGround == true && !isOpen)
        {
            Vector2 jumpVal = new Vector2(0, jumpspeed);
            myRigidbody.velocity = Vector2.up * jumpVal;

            myAnim.SetBool("Jump",true);
        }
        else
        {
            myAnim.SetBool("Jump", false);
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
                if (isJumping)
                {
                    myAnim.SetBool("Climb", false);
                }
                else
                {
                    //myAnim.SetBool("Climb", false);
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
        }

        //Debug.Log("myRigidbody.gravityScale:"+ myRigidbody.gravityScale);
    }

    void CheckAirStatus()
    {
        isJumping = myAnim.GetBool("Jump");
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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
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
            //Debug.Log("Portal");
            collision.gameObject.transform.GetComponent<Portal>().ChangeScene();
            //Vector3 move = gameObject.transform.position;
            //move = new Vector2(move.x = -10, move.y = -4);

            //move = new Vector2(move.x = Portal.moveX, move.y = Portal.moveY);
            //gameObject.transform.position = move;


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
