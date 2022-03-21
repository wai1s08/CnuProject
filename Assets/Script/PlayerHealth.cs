using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int Scene;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
            SceneManager.LoadScene(0);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Portal")
        {
            Debug.Log("123");
            collision.gameObject.transform.GetComponent<Portal>().ChangeScene();

        }
    }
}
