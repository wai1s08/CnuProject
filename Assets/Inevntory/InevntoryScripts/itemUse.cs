using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemUse : MonoBehaviour
{
    [Header("物品的數據(Inventory)")]
    public Item thisItem;

    [Header("玩家的背包(Inventory)")]
    public Inevntory playerInevntory;

    private PlayerHealth playerHealth;

    public string type;

    public int ID;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }
    public void Use()
    {
        type = GetComponent<Slot>().itemtype;

        ID = GetComponent<Slot>().slotID;

        Debug.Log(type);

        if(type == "hp")
        {
            //Debug.Log("喝藥水");
            playerHealth.UseHpPotion(10);
            thisItem.itemHeld -= 1;

            if (playerInevntory.itemList.Contains(thisItem) && thisItem.itemHeld <= 0)
            {
                playerInevntory.itemList[ID] = null;
            }
        }

        InevntoryManager.RefreshItem();

        
    }
}
