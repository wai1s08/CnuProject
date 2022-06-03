using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    private Animator myAnim;

    public static bool DefenseS;

    private float waitTime;

    void Start()
    {
        myAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        DefenseS = false;
    }

    void Update()
    {
        if(DefenseS == true)
        {
            if(waitTime <= 0f)
            {
                DefenseS = false;
                waitTime = 1f;
            }
            waitTime -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            myAnim.SetTrigger("DefenseS");
            DefenseS = true;

        }
    }

}
