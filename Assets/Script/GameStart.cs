using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour
{
    public GameObject HP;
    public GameObject character;
    public Transform spawn;


    public void play()
    {
        SceneManager.LoadScene(2);
        Instantiate(HP);
        //Instantiate(character);
    }
}
