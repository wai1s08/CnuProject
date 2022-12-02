using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public float enemyDiedtime1;
    public GameObject enemtDied1;
    public float chasingSpeed;//追逐速度
  
    private void OnTriggerEnter2D(Collider2D a)
    {
        Destroy(gameObject, enemyDiedtime1);
    }


    void OnDestroy()
    {
        Instantiate(enemtDied1, transform.position, Quaternion.identity);
    }

   
}
