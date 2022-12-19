using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
        Debug.Log("true");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
        Debug.Log("false");
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
             talkUI.SetActive(true);
        }
    }

}
