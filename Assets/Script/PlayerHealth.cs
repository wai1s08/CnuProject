﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int Maxhealth;

    public GameObject chin;
    public GameObject Main;

    public Transform spawn;

    public static int Scene;

    private Renderer myRenderer;
    public int Blinks;
    public float BlinksTime;

    public static float SuperTime;

    private float Face;


    public Slot slot;

    public static PlayerHealth Instance;

    private int EquipHp;

    // Start is called before the first frame update
    void Start()
    {

        myRenderer = GetComponent<Renderer>();
        DontDestroyOnLoad(this.gameObject);

        HealthBar.HealthCurrent = health ;
        Maxhealth = health;

        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(SuperTime);
        HealthBar.HealthMax = Maxhealth + EquipManager.Totalhp + DailogSystem.LevelHp;
        Face = GetComponent<Transform>().rotation.y;

        //Debug.Log(EquipHp);
    }

    public void DamagePlayer(int Damage)
    {
        health -= Damage;
        HealthBar.HealthCurrent = health;

        if(health <= 0)
        {
            Destroy(gameObject);
            Destroy(chin);
            Destroy(Main);
            SceneManager.LoadScene(1);     
        }

        BlinkPlayer(Blinks, BlinksTime);

        //if (Face.Equals(0))
        //{

        //    if (PlayerState.IsDefense == true)
        //    {
        //        Vector3 move = gameObject.transform.position;
        //        move = new Vector2(move.x + 0.5f, move.y + 0.3f);
        //        gameObject.transform.position = move;
        //    }
        //    else
        //    {
        //        Vector3 move = gameObject.transform.position;
        //        move = new Vector2(move.x - 0.5f, move.y + 0.3f);
        //        gameObject.transform.position = move;
        //    }
        //}
        //else
        //{

        //    if (PlayerState.IsDefense == true)
        //    {
        //        Vector3 move = gameObject.transform.position;
        //        move = new Vector2(move.x - 0.5f, move.y + 0.3f);
        //        gameObject.transform.position = move;
        //    }
        //    else
        //    {
        //        Vector3 move = gameObject.transform.position;
        //        move = new Vector2(move.x + 0.5f, move.y + 0.3f);
        //        gameObject.transform.position = move;
        //    }
        //}

    }

    void BlinkPlayer(int numBlinks , float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for (int i = 0; i < numBlinks * 2; i++)
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }

    public void TestEquipHP(int value)
    {
        EquipHp += value;
    }

    public void UseHpPotion(int HP)
    {


        health += HP;

        HealthBar.HealthCurrent = health;
    }
}

