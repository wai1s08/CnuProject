using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;

    private Animator anim;
    private PolygonCollider2D coll;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("attack"))
        {
            coll.enabled = true;
            anim.SetTrigger("testAtt");
            Debug.Log("123");
            StartCoroutine(disableHitBox());
        }
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
