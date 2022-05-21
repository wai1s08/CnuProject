using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int PlayerDamage;

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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            coll.enabled = true;
            //anim.SetTrigger("testAtt");
            //Debug.Log("123");
            StartCoroutine(disableHitBox());
        }
    }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(PlayerDamage);

            //UnityEngine.PolygonCollider2D
        }

    }

}
