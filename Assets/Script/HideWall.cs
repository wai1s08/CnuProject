using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideWall : MonoBehaviour
{
    public GameObject Fire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            Fire_t(Fire);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
            Fire_f(Fire);
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
