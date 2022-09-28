using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : Enemy
{
    public int damge;
    private PlayerHealth playerHealth;

    //public static float superTime;

    //public static bool IsSuperTime = false;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsSuperTime == true)
        {
            superTime -= Time.deltaTime;
        }


        //Debug.Log(superTime);


        if (superTime <= 0.5f)
        {
            IsSuperTime = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            if (other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                if (playerHealth != null)
                {
                    playerHealth.DamagePlayer(damge);

                    superTime = playerHealth.SuperTime;

                    IsSuperTime = true;
                }
            }
        }
    }

}
