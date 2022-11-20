using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GameObject.Find("B-HP").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        GameObject.Find("B-HP1").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        GameObject.Find("B_HPText").GetComponent<Text>().color = new Color(255, 255, 255, 255);

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
