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

    public  static float superTime;

    private PlayerHealth playerHealth;

    private Collider2D PlayerCollider;

    public static bool IsSuperTime = false;
    //private Animator anim;
    public float AttackwaitTime;

    public Transform myTransform;
    public Transform PlayerTransform;

    public float Distance;

    public enum Face { Right, Left }
    public Face face;

    public Transform[] moveSpots;

    public int i = 0;

    public Animator anim;

    // Start is called before the first frame update
    public void Start()
    {
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        // anim = this.GetComponent<Animator>();

        myTransform = this.transform;

        anim = GetComponent<Animator>();

        if (GameObject.Find("player") != null)
        {
            PlayerTransform = GameObject.Find("player").transform;
        }

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
                    //Debug.Log(damage);

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