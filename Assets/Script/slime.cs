using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    // 玩家物件
    public GameObject player;

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


    void Update()
    {
        // 如果已經碰到玩家，則不再追擊
        if (isCollided == true)
        {
           
            return;
        }

        // 计算怪物与玩家的距离
        Vector3 distance = player.transform.position - transform.position;
        
        // 若距離大於追擊範圍，則停止追擊
        if (distance.magnitude > chaseRange)
        {
            return;
        }

        // 根据距离调整怪物的移动速度
        Vector3 velocity = distance.normalized * chaseSpeed * Time.deltaTime;

        // 移动怪物
        transform.position += velocity;

        // 如果距离小于一定值，则视为碰到了玩家
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

        // 生成爆炸效果
        Instantiate(enemtDied1, transform.position, Quaternion.identity);

        // 销毁怪物
        Destroy(gameObject, enemyDiedtime1);
    }
}
