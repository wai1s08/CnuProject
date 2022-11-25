using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level03BGM : MonoBehaviour
{
    public Vector3 A;
    public Vector3 B;
    public GameObject closeda;
    public GameObject closedb;
    bool Pin = false;
    Vector3 T1 = new Vector3(62.59f,6.4f);
    Vector3 T2 = new Vector3(87.64f, 6.46f);
    Vector3 T3;
    Vector3 T4;


    
    public AudioClip[] audios;
    private bool Boss = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = 0;
        GetComponent<AudioSource>().clip = audios[0];
        GetComponent<AudioSource>().Play();
        A = new Vector3(62,6, 0);
        T3 = closeda.transform.position;
        T4 = closedb.transform.position;
        



    }

    // Update is called once per frame
    void Update()
    {
        FindBoss();

        if (Pin == true)
        {
            V1();
        } 

        
        
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
        Pin = true;

    }


    void V1()
    {
        closeda.transform.position = Vector3.MoveTowards(closeda.transform.position, T1, 5 * Time.deltaTime);
        closedb.transform.position = Vector3.MoveTowards(closedb.transform.position, T2, 5 * Time.deltaTime);
    }

    void V2()
    {
        closeda.transform.position = Vector3.MoveTowards(closeda.transform.position, T3, 5 * Time.deltaTime);
        closedb.transform.position = Vector3.MoveTowards(closedb.transform.position, T4, 5 * Time.deltaTime);
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
