using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float enemyDiedtime1;
    public GameObject enemtDied1;
    public float chasingSpeed;//追逐速度
    new Transform playerTransform;
    
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D a)
    {
        if(a.gameObject.tag == "Player")
        {
            Destroy(gameObject, enemyDiedtime1);
            Instantiate(enemtDied1, transform.position, Quaternion.identity);
        }
       

    }
    private void Update()
    {
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if(distance < 15)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chasingSpeed * Time.deltaTime);

            }

        }

    }


}
