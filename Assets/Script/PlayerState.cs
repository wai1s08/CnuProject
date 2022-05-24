using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum Status { Normal, SuperTime, Defense };

    public Status status;

    private Animator myAnim;

    public static bool IsDefense = false;

    private CapsuleCollider2D PlayerCollider;

    private CapsuleCollider2D DefenseCollider;

    private float SuperTime;


    // Start is called before the first frame update
    void Start()
    {
        status = Status.Normal;
        myAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        DefenseCollider = GameObject.FindGameObjectWithTag("Defense").GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            IsDefense = true;
        }
        else
        {
            IsDefense = false;
        }

        

        Debug.Log(status);
        switch (status)
        {
            case Status.Normal:

                if (IsDefense == true)
                {
                    status = Status.Defense;
                }

                if (Enemy.IsSuperTime == true)
                {
                    status = Status.SuperTime;
                }

                break;

            case Status.SuperTime:

                if(Enemy.IsSuperTime == true)
                {
                    PlayerCollider.enabled = false;
                }
                else
                {
                    PlayerCollider.enabled = true;
                    status = Status.Normal;
                }

                if(IsDefense == true)
                {
                    status = Status.Defense;
                }

                

                break;

            case Status.Defense:

                if (IsDefense == true)
                {
                    myAnim.SetTrigger("Defense");
                    PlayerCollider.enabled = false;
                    DefenseCollider.enabled = true;
                    if (Enemy.IsSuperTime == true)
                    {
                        DefenseCollider.enabled = false;
                    }
                    else
                    {
                        DefenseCollider.enabled = true;
                    }
                }
                else
                {
                    status = Status.Normal;
                    PlayerCollider.enabled = true;
                    DefenseCollider.enabled = false;
                }

                break;
        }
    }

}
