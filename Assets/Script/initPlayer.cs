using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initPlayer : MonoBehaviour
{
    public static int PlayerSpawnScene = 2;



    // Start is called before the first frame update
    void Start()
    {



        if (CheckInit.debugSceneName == null)
        {
            SceneManager.LoadScene(PlayerSpawnScene);

        }
        else
        {
            SceneManager.LoadScene(CheckInit.debugSceneName);
            CheckInit.debugSceneName = null;

        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
