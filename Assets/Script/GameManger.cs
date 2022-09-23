using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject character;
    public GameObject HP;

    public Transform spawn;

    public GameObject PlayerCamera;
    public GameObject TestCamera;

    public GameObject Chnemachine;

    public int score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.Scene = score;

        PlayerCamera.SetActive(true);
        TestCamera.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(character, spawn.position, spawn.rotation);

            Chnemachine.SetActive(true);

        }

        /*if (!GameObject.FindGameObjectWithTag("Hp"))
        {
            Instantiate(HP, spawn.position, spawn.rotation);
        }*/
    }


}
