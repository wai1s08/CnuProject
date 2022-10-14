using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01AI : Enemy
{

    public enum Status { idle, Chase, Walk, Death, Attack };

    public Status status;

    public BoxCollider2D box2D;

    public PolygonCollider2D Attackcoll1;

    public PolygonCollider2D Attackcoll2;

    public GameObject Arrow;
    public Transform ArrowPoint;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();


        box2D = GetComponent<BoxCollider2D>();

        Attackcoll1 = GameObject.Find("Boss01_Attack01_Collider").GetComponent<PolygonCollider2D>();
        Attackcoll2 = GameObject.Find("Boss01_Attack02_Collider").GetComponent<PolygonCollider2D>();


    }

    // Update is called once per frame
   new void Update()
    {
        base.Update();

        //if (IsSuperTime == true)
        //{
        //    superTime -= Time.deltaTime;
        //}

        //if (superTime <= 0.5f)
        //{
        //    IsSuperTime = false;
        //}

        if (health <= 0)
        {
            status = Status.Death;
        }

        switch (status)
        {
            case Status.idle:

                anim.SetBool("Run", false);
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
                anim.SetBool("Run", true);
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
                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) <= 3)
                {
                    status = Status.Attack;
                }
                break;

            case Status.Attack:

                anim.SetBool("Attack", true);

                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) >= 4)
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

    void Attack1()
    {
        Attackcoll1.enabled = true;
    }

    void Attack2()
    {
        Attackcoll1.enabled = false;
        Attackcoll2.enabled = true;
    }

    void AttackEnd()
    {
        Attackcoll1.enabled = false;
        Attackcoll2.enabled = false;
    }

    void AttackArrow()
    {
        Instantiate(Arrow, ArrowPoint.position, ArrowPoint.rotation);
    }
}
