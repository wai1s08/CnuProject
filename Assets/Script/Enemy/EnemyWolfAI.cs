using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolfAI : Enemy
{
    public enum Status { idle, walk, patrol , Death , Attack};

    public Status status;

    private Transform myTransform;

    public Transform PlayerTransform;
    private SpriteRenderer spr;

    public Transform[] moveSpots;

    public int i = 0;

    public float Distance;

    private float wait;
    public float waitTime = 5;
    private bool movingRight = true;
    private BoxCollider2D box2D;

    private Animator anim;

    private PolygonCollider2D AttackColl;

    public float time;


    public enum Face { Right, Left }
    public Face face;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();

        status = Status.idle;

        spr = this.transform.GetComponent<SpriteRenderer>();

        anim = this.GetComponent<Animator>();

        box2D = GetComponent<BoxCollider2D>();

        AttackColl = GetComponent<PolygonCollider2D>();

        wait = waitTime;
        if (spr.flipX)
        {
            face = Face.Left;
        }
        else
        {
            face = Face.Right;

        }
        myTransform = this.transform;
        if (GameObject.Find("player") != null)
        {
            PlayerTransform = GameObject.Find("player").transform;
        }

    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();

        if (health <= 0)
        {
            status = Status.Death;
        }
        //Debug.Log(status);

        switch (status)
        {
            case Status.idle:
                if (myTransform)
                {
                    if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) < Distance)
                    {
                        status = Status.walk;
                    }
                    else
                    {
                        status = Status.patrol;
                    }
                    if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) <= 1.2)
                    {
                        status = Status.idle;
                    }

                    AttackColl.enabled = false;



                }
                break;

            case Status.walk:
                anim.SetBool("Run", true);

                if (PlayerTransform)
                {
                    if (myTransform.position.x >= PlayerTransform.position.x)
                    {
                        //spr.flipX = true;
                        transform.localRotation = Quaternion.Euler(0, 0, 0);
                        face = Face.Left;
                    }
                    else
                    {
                        //spr.flipX = false;
                        transform.localRotation = Quaternion.Euler(0, 180, 0);
                        face = Face.Right;
                    }
                }
                switch (face)
                {
                    case Face.Right:
                        myTransform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                        break;
                }

                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) > Distance)
                {
                    status = Status.patrol;
                    if (movingRight == true)
                    {
                        spr.flipX = false;
                        //movingRight = true;
                    }
                    else
                    {
                        spr.flipX = true;
                       // movingRight = false;
                    }
                }
                if(Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) <= 1.3)
                {
                    status = Status.Attack;
                }

 

                break;

            case Status.patrol:
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);
                anim.SetBool("Run", true);

                if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
                {
                    if (waitTime <= 0)
                    {
                        
                        if (movingRight == true)
                        {
                            //spr.flipX = false;
                            transform.localRotation = Quaternion.Euler(0, 180, 0);
                            movingRight = false;
                        }
                        else
                        {
                            //spr.flipX = true;
                            transform.localRotation = Quaternion.Euler(0, 0, 0);
                            movingRight = true;
                        }

                        if (i == 0)
                        {

                            i = 1;
                        }
                        else
                        {

                            i = 0;
                        }

                        waitTime = wait;
                    }
                    else
                    {
                        anim.SetBool("Run", false);
                        waitTime -= Time.deltaTime;
                    }
                    if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) < Distance)
                    {
                        status = Status.walk;
                    }

                    
                }


                break;

            case Status.Death:
                box2D.enabled = false;
                anim.SetTrigger("Death");
                break;

            case Status.Attack:
                anim.SetBool("Attack", true);

                AnimatorStateInfo animatorInfo;
                animatorInfo = anim.GetCurrentAnimatorStateInfo(0);
                if ((animatorInfo.normalizedTime > 0.6f) && (animatorInfo.IsName("Wolf_Attack")))//normalizedTime: 範圍0 -- 1,  0是動作開始，1是動作結束
                {
                    AttackColl.enabled = true;
                }

                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) >= 1.3)
                {
                    anim.SetBool("Attack", false);
                    status = Status.idle;
                }
                break;
        }

    }

    
}