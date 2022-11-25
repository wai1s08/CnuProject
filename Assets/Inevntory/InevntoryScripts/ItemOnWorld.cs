using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//物品與遊戲中的互動，掛在每個物品上

public class ItemOnWorld : MonoBehaviour
{
    [Header("物品的數據(Inventory)")]
    public Item thisItem;

    [Header("玩家的背包(Inventory)")]
    public Inevntory playerInevntory;


    //玩家碰到物品將物品放到背包裡
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    //新增物品的方法
    public void AddNewItem()
    {
        //如果背包裡沒有這個物品
        if (!playerInevntory.itemList.Contains(thisItem))
        {
            //將物品添加到這個背包裡
            //playerInevntory.itemList.Add(thisItem);
            for (int i = 0; i < playerInevntory.itemList.Count; i++)
            {
                if (playerInevntory.itemList[i] == null)
                {
                    playerInevntory.itemList[i] = thisItem;
                    thisItem.itemHeld = 1;
                    break;
                }
            }
        }
        else //如果背包裡有經有這個物品，將物品數量+1
        {
            thisItem.itemHeld += 1;
        }


        //刷新背包
        InevntoryManager.RefreshItem();
    }

}
