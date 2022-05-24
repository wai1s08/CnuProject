using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    public enum Status { Normal, SuperTime, Defense };

    public Status status;

    private Animator myAnim;

    private bool IsDefense = false;

    private CapsuleCollider2D PlayerCollider;

    // Start is called before the first frame update
    void Start()
    {
        status = Status.Normal;

        myAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        // DefenseCapsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
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

                break;

            case Status.SuperTime:

                break;

            case Status.Defense:

                if (IsDefense == true)
                {
                    myAnim.SetTrigger("Defense");
                }
                else
                {
                    status = Status.Normal;
                }

                break;
        }
    }

}
