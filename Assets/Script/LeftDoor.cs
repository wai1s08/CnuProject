using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftDoor : MonoBehaviour
{
    public int Scene;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.tag = "LeftDoor";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(Scene);

    }
}
