using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideWall : MonoBehaviour
{

    public GameObject Tile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GetComponent<SpriteRenderer>().enabled = false;

            GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GetComponent<SpriteRenderer>().enabled = true;

            GetComponent<TilemapRenderer>().maskInteraction = SpriteMaskInteraction.None;
        }
    }
}
