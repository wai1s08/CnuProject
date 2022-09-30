using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform goToPos;
    //前往位置
    private Transform platerPos;
    //角色位置

    // Start is called before the first frame update
    void Start()
    {
        platerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //碰撞後按W
         if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
            platerPos.transform.position = goToPos.transform.position;
        }
    }
}
