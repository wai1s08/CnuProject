using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float enemyDiedtime1;
    public GameObject enemtDied1;
    public float chasingSpeed;//追逐速度
    new Vector3 playerPos;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D a)
    {
        Destroy(gameObject, enemyDiedtime1);
    }
    private void Update()
    {
        playerPos = GameObject.Find("player").gameObject.transform.position;
        
        if (Vector2.Distance(gameObject.transform.position,playerPos) > 5)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, playerPos, chasingSpeed * Time.deltaTime);

        }

    }

    

}
