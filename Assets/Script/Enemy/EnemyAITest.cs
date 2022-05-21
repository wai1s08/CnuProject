using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITest : Enemy
{
    public enum Status { idle , walk };

    public Status status;

    private Transform myTransform;

    public Transform PlayerTransform;
    private SpriteRenderer spr;

    public float Distance;

    public enum Face { Right , Left}
    public Face face;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();

        status = Status.idle;

        spr = this.transform.GetComponent<SpriteRenderer>();

        if (spr.flipX)
        {
            face = Face.Left;
        }
        else
        {
            face = Face.Right;
            
        }
        myTransform = this.transform;
        if(GameObject.Find("player") != null)
        {
            PlayerTransform = GameObject.Find("player").transform;
        }
        
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        switch (status)
        {
            case Status.idle:
                if (myTransform)
                {
                    if(Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) < Distance)
                    {
                        status = Status.walk;
                    }
                }
                break;

            case Status.walk:
                if (PlayerTransform)
                {
                    if (myTransform.position.x >= PlayerTransform.position.x)
                    {
                        spr.flipX = true;
                        face = Face.Left;
                    }
                    else
                    {
                        spr.flipX = false;
                        face = Face.Right;
                    }          
                }
                switch (face)
                {
                    case Face.Right:
                        myTransform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                        break;
                }
                if(Mathf.Abs(myTransform.position.x - PlayerTransform.position.x) >= Distance)
                {
                    status = Status.idle;
                }
                break;
        }
        
    }
}