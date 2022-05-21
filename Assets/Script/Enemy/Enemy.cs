using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    public float superTime ;

    public GameObject FloatPoint;

    private PlayerHealth playerHealth;

    private Collider2D PlayerCollider;

    // Start is called before the first frame update
    public void Start()
    {
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    public void Update()
    {

        // 怪物死亡
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        superTime -= Time.deltaTime;

        if (superTime <= 0.5f)
        {
            PlayerCollider.enabled = true;
        }

        if (superTime <= 0)
        {
            superTime = 0;
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
                PlayerCollider.enabled = false;
                superTime = playerHealth.SuperTime;
                
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