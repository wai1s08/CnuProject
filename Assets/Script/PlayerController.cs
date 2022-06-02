using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpspeed;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;

    private BoxCollider2D myFeet;
    private bool isGround;

    public GameObject MyBag;
    private bool isOpen;
    private bool IsPortal;
    // Start is called before the first frame update
    void Start()
    {
        // 遊戲開始後取得組件
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 在遊戲進行當中不斷取得Run的數值
        Run();
        Flip();
        Jump();
        checkGround();
        OpenMyBag();
        Portal();
        //Defense();
    }

    void checkGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));

    }

    void Run()
    {
        if (PlayerState.IsDefense == false)
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
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            Vector2 jumpVal = new Vector2(0, jumpspeed);
            myRigidbody.velocity = Vector2.up * jumpVal;
        }
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            MyBag.SetActive(isOpen);
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



}
