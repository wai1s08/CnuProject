using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;

    public GameObject FloatPoint;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    public void Update()
    {

        // 玩家死亡
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    
    // 玩家碰到怪物
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //Debug.Log("touch");
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
                Debug.Log(damage);
            }
        }
    }

    //怪物受傷
    public void TakeDamage(int damage)
    {
        GameObject gb = Instantiate(FloatPoint, transform.position, Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
        Instantiate(FloatPoint, transform.position, Quaternion.identity);
        health -= damage;
    }
}