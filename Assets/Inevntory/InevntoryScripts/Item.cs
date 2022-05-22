using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item ",menuName = "Inventory/new Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemimage;
    public int itemHeld;

    [TextArea]
    public string itemInfo;

    public bool equip;
}
