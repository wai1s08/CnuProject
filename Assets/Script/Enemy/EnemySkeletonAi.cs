using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAi : Enemy
{
    public enum Status { idle, Chase, Walk, Death, Attack };

    public Status status;

    private BoxCollider2D box2D;

    public GameObject Arrow;
    public Transform ArrowPoint;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        status = Status.idle;

        box2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (IsSuperTime == true)
        {
            superTime -= Time.deltaTime;
        }

        if (superTime <= 0.5f)
        {
            IsSuperTime = false;
        }

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
                    //if (myTransform.position.x == moveSpots[0].position.x)
                    //{
                    //    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    //}
                    //else
                    //{
                    //    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    //}



                    status = Status.idle;
                }
                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) <= 7)
                {
                    status = Status.Attack;
                }
                break;

            case Status.Attack:

                anim.SetBool("Attack", true);

                //Attack();

                if (Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) >= 7)
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

    void Attack()
    {
        Instantiate(Arrow, ArrowPoint.position, ArrowPoint.rotation);
    }
}
