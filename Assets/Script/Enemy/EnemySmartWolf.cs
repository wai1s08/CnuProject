using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartWolf : Enemy
{
    public float speed;
    public float radius;

    public float waitTime;
    public Transform[] moveSpots;

    private int i = 0;
    private bool movingRight = true;
    private float wait;

    private Transform playerTransform;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();

        // 如果玩家座標不為空
        if (playerTransform != null)
        {
            // 局內變數 距離 = 當前座標 - 玩家座標 | sqrMagnitude 返回平方數
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            //如果 距離小於偵測範圍radius
            if (distance < radius)
            {
                // 當前座標 = Vector2.MoveTowards(Vector3 起點, Vector3 終點, float 距離)
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);


                Debug.Log(distance);

            }
            else
            {
                // 當前座標 = Vector2.MoveTowards(Vector3 起點, Vector3 終點, float 距離)
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);

                //Vector2.Distance 返回兩點間的距離 < 0.1f
                if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.1f)
                {
                    // 等待時間 小於等於 0
                    if (waitTime <= 0)
                    {

                        if (movingRight == true)
                        {
                            // eulerAngles的角度是不能隨時變化的，是一個定值，而rotation的角度是可以增加的，eulerAngles用vector3來賦值，而rotation用Quaternion來賦值。
                            //當前歐拉角 = new Vector3(0, 180, 0)
                            transform.eulerAngles = new Vector3(0, 180, 0);

                            movingRight = false;
                            i = 1;
                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            movingRight = true;

                            i = 0;
                        }

                        waitTime = wait;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
        }
    }
}
