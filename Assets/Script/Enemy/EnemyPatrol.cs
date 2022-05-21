using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightDownPos;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        //movePos.position = ;
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandowPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    Vector2 GetRandowPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightDownPos.position.x), Random.Range(leftDownPos.position.y, rightDownPos.position.y));
        return rndPos;
    }

}
