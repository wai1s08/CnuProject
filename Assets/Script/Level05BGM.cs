using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level05BGM : MonoBehaviour
{
    public Vector3 A;
    public Vector3 B;
    public GameObject closeda;
    public GameObject closedb;
    bool Pin = false;
    Vector3 T3 = new Vector3(111.89f, 28.85f, 0);
    Vector3 T1 = new Vector3(111.89f, 25.71f, 0);
    Vector3 T4 = new Vector3(142.2f, 28.85f, 0);
    Vector3 T2 = new Vector3(141.99f, 25.56f, 0);
    bool alive = true;
    public GameObject BOSSalive;





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


        for (int i = 0; i < 1 && Pin == true; i++)
        {
            V1();
        }

        if (BOSSalive)
        {

        }
        else
        {
            V2();
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
        closeda.transform.position = Vector3.MoveTowards(closeda.transform.position, T1, 2f * Time.deltaTime);
        closedb.transform.position = Vector3.MoveTowards(closedb.transform.position, T2, 2f * Time.deltaTime);
    }

    void V2()
    {
        closeda.transform.position = Vector3.MoveTowards(closeda.transform.position, T3, 50 * Time.deltaTime);
        closedb.transform.position = Vector3.MoveTowards(closedb.transform.position, T4, 50 * Time.deltaTime);


    }




    void FindBoss()
    {
        if (!GameObject.Find("Boss_Mage") && Boss == true)
        {
            GetComponent<AudioSource>().volume = 0;
            GetComponent<AudioSource>().clip = audios[0];
            GetComponent<AudioSource>().Play();
            Boss = false;
        }
    }


}
