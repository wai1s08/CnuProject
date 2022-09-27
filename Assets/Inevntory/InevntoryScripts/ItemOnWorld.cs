using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inevntory playerInevntory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!playerInevntory.itemList.Contains(thisItem))
        {
            playerInevntory.itemList.Add(thisItem);
            //InevntoryManager.CreateNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InevntoryManager.RefreshItem();
    }
}
