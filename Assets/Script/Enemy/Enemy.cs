using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("怪物傷害")]
    public int damage;
    [Header("怪物血量")]
    public int health;
    [Header("怪物速度")]
    public float speed;

    [Header("死亡延遲")]
    public float DeathDelay;

    [Header("傷害顯示")]
    public GameObject FloatPoint;


    public  static float superTime;

    private PlayerHealth playerHealth;

    private Collider2D PlayerCollider;

    public static bool IsSuperTime = false;

    [Header("怪物的位子(不用放)")]
    public Transform myTransform;

    [Header("玩家的位子(不用放)")]
    public Transform PlayerTransform;

    [Header("怪物巡邏(不用改)")]
    public int i = 0;

    [Header("怪物視野距離")]
    public float Distance;

    public enum Face { Right, Left }

    [Header("怪物面向")]
    public Face face;

    [Header("怪物巡邏點")]
    public Transform[] moveSpots;

    public Animator anim;

    [Header("怪物金錢物件")]
    public GameObject Money;

    [Header("把自己拉進來")]
    public Transform Monster;

    
    public static int money;

    [Header("怪物掉多少錢")]
    public int Moeneyint;

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

        money = Moeneyint;

    }

    // Update is called once per frame
    public void Update()
    {

        // 怪物死亡
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (health <= 0)
        {
            Destroy(gameObject, DeathDelay);
            Instantiate(Money, Monster.position  , Monster.rotation);

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