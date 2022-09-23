using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInit : MonoBehaviour
{
    public static string debugSceneName;

    public static int StartPlayerNumber;

    public GameObject PlayerObject;
    // Start is called before the first frame update
    void Start()
    {

        PlayerObject = GameObject.Find("player");

        if (!GameObject.Find("player"))
        {
            SceneManager.LoadScene("initPlayer");
            debugSceneName = SceneManager.GetActiveScene().name;
        }

        if (StartPlayerNumber != 0)
        {
            GameObject g = GameObject.Find(StartPlayerNumber.ToString()) as GameObject;

            if (g != null)
            {
                PlayerObject.transform.position = g.transform.position;
            }
            StartPlayerNumber = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
