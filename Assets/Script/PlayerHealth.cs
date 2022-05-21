using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public GameObject chin;
    public GameObject Main;

    public Transform spawn;

    public static int Scene;

    private Renderer myRenderer;
    public int Blinks;
    public float BlinksTime;

    public float SuperTime;

    private float Face;





    // Start is called before the first frame update
    void Start()
    {
        
        myRenderer = GetComponent<Renderer>();
        DontDestroyOnLoad(this.gameObject);
        HealthBar.HealthCurrent = health;
        HealthBar.HealthMax = health;

        


    }

    // Update is called once per frame
    void Update()
    {
        Face = GetComponent<Transform>().rotation.y;
        Debug.Log(Face);
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

        if(Face.Equals(0))
        {
            Vector3 move = gameObject.transform.position;
            move = new Vector2(move.x - 0.5f, move.y + 0.3f);
            gameObject.transform.position = move;
        }
        else
        {
            Vector3 move = gameObject.transform.position;
            move = new Vector2(move.x + 0.5f, move.y + 0.3f);
            gameObject.transform.position = move;
        }

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            //Debug.Log("123");
            collision.gameObject.transform.GetComponent<Portal>().ChangeScene();
            Vector3 move = gameObject.transform.position;
            move = new Vector2(move.x = -10, move.y = -4);
            gameObject.transform.position = move;


        }

    }
}
