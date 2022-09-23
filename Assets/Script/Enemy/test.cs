using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : Enemy
{
    public bool mustPartrol;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        mustPartrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPartrol)
        {
            Patrol();
        }   
    }

    void Patrol()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPartrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPartrol = true;
    }
}
