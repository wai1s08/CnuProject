using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public int PlayerDamage;

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
