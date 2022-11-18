using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int PlayerDamage;

    private Animator anim;
    private PolygonCollider2D Attackcoll_1;
    private PolygonCollider2D Attackcoll_2;
    private PolygonCollider2D Attackcoll_3;


    public float time;

    public float AttackwaitTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Attackcoll_1 = GameObject.Find("PlayerAttack1").GetComponent<PolygonCollider2D>();
        Attackcoll_2 = GameObject.Find("PlayerAttack2").GetComponent<PolygonCollider2D>();
        Attackcoll_3 = GameObject.Find("PlayerAttack3").GetComponent<PolygonCollider2D>();
        anim.SetBool("CanAttack1", true);

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
        if (Input.GetKey(KeyCode.Mouse0) && waitTime <= 0 && PlayerState.IsDefense ==false && !PlayerController.isOpen && anim.GetBool("CanAttack1") == true)
        {
            SoundManager.PlaySword_sound();
            Attackcoll_1.enabled = true;
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox1());
            waitTime = AttackwaitTime;

        }

        if (Input.GetKey(KeyCode.Mouse0) && waitTime <= 0 && PlayerState.IsDefense == false && !PlayerController.isOpen && anim.GetBool("CanAttack2") == true)
        {
            SoundManager.PlaySword_sound();
            Attackcoll_2.enabled = true;
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox2());
            waitTime = AttackwaitTime;

        }

        if (Input.GetKey(KeyCode.Mouse0) && waitTime <= 0 && PlayerState.IsDefense == false && !PlayerController.isOpen && anim.GetBool("CanAttack3") == true)
        {
            SoundManager.PlaySword_sound();
            Attackcoll_3.enabled = true;
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox3());
            waitTime = AttackwaitTime;

        }
    }

    void switchAttack1()
    {
        anim.SetBool("CanAttack1", false);
        anim.SetBool("CanAttack2", true);
    }
    void switchAttack2()
    {
        anim.SetBool("CanAttack2", false);
        anim.SetBool("CanAttack3", true);
    }
    void switchAttack3()
    {
        anim.SetBool("CanAttack3", false);
        anim.SetBool("CanAttack1", true);
    }


    IEnumerator disableHitBox1()
    {
        yield return new WaitForSeconds(time);
        Attackcoll_1.enabled = false;
    }

    IEnumerator disableHitBox2()
    {
        yield return new WaitForSeconds(time);
        Attackcoll_2.enabled = false;
    }

    IEnumerator disableHitBox3()
    {
        yield return new WaitForSeconds(time);
        Attackcoll_3.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        int value = Random.Range(PlayerDamage * 1, PlayerDamage * 2);

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(value);

            //UnityEngine.PolygonCollider2D
        }

    }

}
