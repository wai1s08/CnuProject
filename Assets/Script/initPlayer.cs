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
        SceneManager.LoadScene(PlayerSpawnScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
