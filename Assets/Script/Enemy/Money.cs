using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Transform player;

    public float destroyDistance;

    private Vector3 startPos;

    public float speed;

    private static int money;

    public Text MoneyNum;

    public 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        startPos = transform.position;

        MoneyNum = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        float distance = (transform.position - startPos).sqrMagnitude;
        //if (distance > destroyDistance)
        //{
        //    Destroy(gameObject);
        //}
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                money += Enemy.money;
                Destroy(gameObject);

                MoneyNum.text = money.ToString();
            
                
        }

        Debug.Log("trigger");
    }


}
