using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//儲存物品的所有訊息

[CreateAssetMenu(fileName = "New Item ",menuName = "Inventory/new Item")]
public class Item : ScriptableObject
{
    [Header("物品名稱")]
    public string itemName;

    [Header("物品圖片")]
    public Sprite itemimage;

    [Header("物品數量")]
    public int itemHeld;


    [Header("物品說明")]
    [TextArea]
    public string itemInfo;

    [Header("物品是否可以裝備")]
    public bool equip;
}
