using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTelepor : MonoBehaviour
{
    public static bool playerIsLeft;

    private void Update()
    {
        Debug.Log(playerIsLeft);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsLeft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsLeft = false;
        }  
    }
}
