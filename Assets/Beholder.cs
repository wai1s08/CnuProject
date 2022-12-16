using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beholder : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

   

    public GameObject playerObject;

    // 追擊距離限制
    public float chaseRange = 10f;

    // 追擊速度
    public float chaseSpeed = 5.0f;

    // 是否已經碰到玩家
    private bool isChasingPlayer = false;




    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        playerObject = GameObject.Find("player");
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public new void Update()
    {
        //调用父类的Update()方法
        base.Update();

        float distanceToPlayer = Vector2.Distance(transform.position, playerObject.transform.position);

        if (distanceToPlayer < chaseRange)
        {
            isChasingPlayer = true;
            // 追擊玩家
            Vector2 chaseDirection = (playerObject.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, chaseSpeed * Time.deltaTime);
        }
        else
        {
            if (isChasingPlayer)
            {
                // 重置變量
                isChasingPlayer = false;
                waitTime = startWaitTime;
                movePos.position = GetRandomPos();
            }

            // 隨機移動
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
            {
                if (waitTime <= 0)
                {
                    movePos.position = GetRandomPos();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }




    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

}
