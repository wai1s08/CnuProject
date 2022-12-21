using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageAI : Enemy
{
    public enum Status { idle, Chase, Walk, /*patrol ,*/ Death, Attack };

    [Header("目前狀態")]
    public Status status;

    private float wait;

    [Header("巡邏等待時間")]
    public float waitTime = 5;

    private BoxCollider2D box2D;

    [Header("火球(普通攻擊)")]
    public GameObject FireBall;
    public Transform FirePoint;

    [Header("普通攻擊冷卻時間")]
    public float NoramlAttackCD;
   
    private float normalAttackCD ;

    private PolygonCollider2D AttackColl;

    // public float time;


    // public float turnSpeed = 0.1f;


    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();

        status = Status.Chase;



        box2D = GetComponent<BoxCollider2D>();

        AttackColl = GetComponent<PolygonCollider2D>();

        wait = waitTime;

        transform.localRotation = Quaternion.Euler(0, 180, 0);




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

                
                //anim.SetBool("Attack", false);
                if (myTransform)
                {
                    if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) < Distance)
                    {
                        status = Status.Chase;
                    }
                }
                break;

            case Status.Chase:
                
                if (PlayerTransform)
                {
                    if (myTransform.position.x >= PlayerTransform.position.x)
                    {
                        transform.localRotation = Quaternion.Euler(0, 180, 0);
                        face = Face.Left;
                    }
                    else
                    {
                        transform.localRotation = Quaternion.Euler(0, 0, 0);
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
                    status = Status.idle;
                }
                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) <= 8)
                {
                    status = Status.Attack;
                }
                break;

            case Status.Attack:

                if(normalAttackCD <= 0)
                {
                    anim.SetTrigger("Attack");
                    normalAttackCD = NoramlAttackCD;
                }

                Debug.Log(normalAttackCD);
                normalAttackCD -= Time.deltaTime;

                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) >= 8)
                {
                    anim.SetBool("Attack", false);
                    status = Status.idle;
                }
                break;

            case Status.Death:
                box2D.enabled = false;
                anim.SetTrigger("Death");
                break;
        }
    }


    void FireAttack()
    {
        Instantiate(FireBall, FirePoint.position, FirePoint.rotation);
    }
}