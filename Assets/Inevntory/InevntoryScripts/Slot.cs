using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//生成物品圖片、數據至背包
public class Slot : MonoBehaviour
{
    //宣告一個類的變數，就可以直接使用裡面的數據
    public int slotID;// 空格ID = 物品ID

    public Item slotItem;


    public Image slotImage;
    public Text slotNum;

    public GameObject itemInSlot;

    public string slotInfo;

    public void ItemOnClicker()
    {
        InevntoryManager.UpdateItemInfo(slotInfo);
    }

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemimage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}
