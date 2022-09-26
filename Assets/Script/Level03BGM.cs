using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03BGM : MonoBehaviour
{
    public AudioClip[] audios;
    private bool Boss = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = 0;
        GetComponent<AudioSource>().clip = audios[0];
        GetComponent<AudioSource>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        FindBoss();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<AudioSource>().volume = 0;
        GetComponent<AudioSource>().clip = audios[1];
        GetComponent<AudioSource>().Play();
        GetComponent<BoxCollider2D>().enabled = false;

    }

    void FindBoss()
    {
        if (!GameObject.Find("Boss01") && Boss == true)
        {
            GetComponent<AudioSource>().volume = 0;
            GetComponent<AudioSource>().clip = audios[0];
            GetComponent<AudioSource>().Play();
            Boss = false;
        }
    }

    
}
