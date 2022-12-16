using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : Enemy
{

    // 爆炸效果
    public GameObject enemtDied1;

    // 追擊速度
    public float chaseSpeed = 5.0f;

    // 是否已經碰到玩家
    private bool isCollided = false;

    public float enemyDiedtime1;

    // 追擊距離限制
    public float chaseRange = 10f;


    // 閃爍次數
    public int flashCount = 3;

    // 閃爍頻率
    public float flashFrequency = 0.5f;

    public GameObject playerObject;

    public PlayerHealth playerHPScript;

    public int damage;



    void Start()
    {
        playerObject = GameObject.Find("player");
        playerHPScript = playerObject.GetComponent<PlayerHealth>();

    }
    void Update()
    {
        
        // 如果已經碰到玩家，則不再追擊
        if (isCollided == true)
        {
            
            return;
        }

        // 計算怪物與玩家的距離
        Vector3 distance = playerObject.transform.position - transform.position;
        
        // 若距離大於追擊範圍，則停止追擊
        if (distance.magnitude > chaseRange)
        {
            return;
        }

        // 根據距離調整怪物的移動速度
        Vector3 velocity = distance.normalized * chaseSpeed * Time.deltaTime;

        // 移動怪物
        transform.position += velocity;

        // 如果距離小於一定值，則視為碰到了玩家
        if (distance.magnitude < 1.8f)
        {
            isCollided = true;

            // 爆炸前閃爍
            StartCoroutine(FlashBeforeExplode());
        }
    }

    IEnumerator FlashBeforeExplode()
    {
        // 閃爍次數
        int count = flashCount;

        // 每隔一段時間改變材質球顏色
        while (count > 0)
        {
            // 改變顏色
            GetComponent<SpriteRenderer>().color = Color.red;

            // 等待一段時間
            yield return new WaitForSeconds(flashFrequency);

            // 改回顏色
            GetComponent<SpriteRenderer>().color = Color.white;

            // 等待一段時間
            yield return new WaitForSeconds(flashFrequency);

            // 閃爍次數 - 1
            count--;
        }


        Vector3 distance = playerObject.transform.position - transform.position;

        if (distance.magnitude < 5f)
        {
            //扣血
            playerHPScript.health -= damage;

            HealthBar.HealthCurrent -= damage;

        }

        // 生成爆炸效果
        Instantiate(enemtDied1, transform.position, Quaternion.identity);

        // 銷毀怪物
        Destroy(gameObject, enemyDiedtime1);

       
    }
   
}
