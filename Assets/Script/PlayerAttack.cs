using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int PlayerDamage;

    private Animator anim;
    private PolygonCollider2D coll;


    public float time;

    public float AttackwaitTime;
    private float waitTime;

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

        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) && waitTime <= 0 && PlayerState.IsDefense ==false && !PlayerController.isOpen)
        {
            SoundManager.PlaySword_sound();
            coll.enabled = true;
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox());
            waitTime = AttackwaitTime;

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
