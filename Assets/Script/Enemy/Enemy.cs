using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;

    public float DeathDelay;

    public GameObject FloatPoint;

    private float superTime;
    private PlayerHealth playerHealth;

    private Collider2D PlayerCollider;

    public static bool IsSuperTime = false;
    private Animator anim;

    private BoxCollider2D box2D;

    // Start is called before the first frame update
    public void Start()
    {
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = this.GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    public void Update()
    {

        // 怪物死亡
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (health <= 0)
        {
            Destroy(gameObject, DeathDelay);

        }

        if (IsSuperTime == true)
        {
            superTime -= Time.deltaTime;
        }


        Debug.Log(superTime);


        if (superTime <= 0.5f)
        {
            IsSuperTime = false;
        }
    }


    // 玩家碰到怪物
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Defense"))
        {
            if(other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                if (playerHealth != null)
                {
                    playerHealth.DamagePlayer(damage);
                    Debug.Log(damage);

                    superTime = playerHealth.SuperTime;

                    IsSuperTime = true;

                }
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