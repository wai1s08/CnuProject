using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideWall : MonoBehaviour
{

    
    public GameObject Fire1;
    public GameObject Fire2;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            Fire_t(Fire1);
            Fire_t(Fire2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
            Fire_f(Fire1);
            Fire_f(Fire2);
        }
    }
    GameObject Fire_t(GameObject A)
    {
        A.SetActive(true);
        return A;
    }
    GameObject Fire_f(GameObject B)
    {
        B.SetActive(false);
        return B;
    }
}