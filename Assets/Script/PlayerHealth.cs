using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.HealthCurrent = health;
        HealthBar.HealthMax = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int Damage)
    {
        health -= Damage;
        HealthBar.HealthCurrent = health;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
