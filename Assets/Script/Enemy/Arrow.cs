using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public int damage;
    public float destroyDistance;

    private Rigidbody2D rb2d;
    private Vector3 startPos;

    public PlayerHealth playerHealth;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        rb2d = GetComponent<Rigidbody2D>();


        



        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = transform.right * speed;
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        float distance = (transform.position - startPos).sqrMagnitude;
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Defense"))
        {
            if (other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                if (playerHealth != null)
                {
                    playerHealth.DamagePlayer(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
