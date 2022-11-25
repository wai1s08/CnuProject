using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spr;

    private bool isPlayerInBox;

    private bool BoxOpen = false;

    public float waitTime;

    public GameObject item;

    public Transform itemSpawn;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerInBox && BoxOpen == false)
        {
            anim.SetTrigger("Open");
            BoxOpen = true;       
        }
        if (BoxOpen == true)
        {
            waitTime -= Time.deltaTime;
            
            if ( waitTime <= 1f)
            {
                anim.SetBool("FeadOut", true);
                Destroy(gameObject , 1.5f);
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInBox = true;
            //warn.SetActive(true);       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInBox = false;
            //warn.SetActive(true);       
        }
    }

    void DropItem()
    {
        Instantiate(item, itemSpawn.position, itemSpawn.rotation);
    }
}
